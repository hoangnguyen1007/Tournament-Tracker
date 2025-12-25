    USE master;
    GO

    -- =============================================================
    -- 1. XÓA DB CŨ & TẠO LẠI (RESET SẠCH SẼ)
    -- =============================================================
    IF EXISTS (SELECT name FROM sys.databases WHERE name = N'TournamentTracker')
    BEGIN
        ALTER DATABASE [TournamentTracker] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
        DROP DATABASE [TournamentTracker];
    END
    GO

    CREATE DATABASE [TournamentTracker];
    GO
    USE [TournamentTracker];
    GO

    -- =============================================================
    -- 2. TẠO BẢNG (SCHEMA ĐÃ TỐI ƯU)
    -- =============================================================

    -- BẢNG 1: TÀI KHOẢN
    CREATE TABLE [dbo].[Account](
        [ID] INT IDENTITY(1,1) PRIMARY KEY,
        [Username] NVARCHAR(50) NOT NULL UNIQUE,
        [PasswordHash] NVARCHAR(255) NOT NULL, 
        [CreatedAt] DATETIME DEFAULT GETDATE()
    );

    -- BẢNG 2: GIẢI ĐẤU (Đã bỏ cột Format rườm rà)
    CREATE TABLE [dbo].[Tournaments](
        [ID] INT IDENTITY(1,1) PRIMARY KEY,
        [NAME] NVARCHAR(100) NOT NULL,
        [LOCATION] NVARCHAR(100) NULL,
        [STARTDATE] DATE NULL,
        [PRIZE] NVARCHAR(50) NULL,
        [POSTERPATH] NVARCHAR(255) NULL,
        [SPORT] NVARCHAR(50),   
        [TEAM_COUNT] INT DEFAULT 0, -- Số lượng đội dự kiến
        [CreatedBy] INT NULL,       -- Admin nào tạo?
        [GroupCount] INT DEFAULT 1,
        FOREIGN KEY (CreatedBy) REFERENCES Account(ID)
    );

    -- BẢNG 3: ĐỘI BÓNG
    CREATE TABLE [dbo].[Teams](
        [ID] INT IDENTITY(1,1) PRIMARY KEY,
        [TournamentID] INT NOT NULL,
        [TEAMNAME] NVARCHAR(100) NOT NULL,
        [COACH] NVARCHAR(100) NULL,
    
        -- Xóa giải là xóa luôn đội
        FOREIGN KEY (TournamentID) REFERENCES Tournaments(ID) ON DELETE CASCADE 
    );

    -- BẢNG 4: CẦU THỦ
    CREATE TABLE [dbo].[Players](
        [ID] INT IDENTITY(1,1) PRIMARY KEY,
        [IDTEAM] INT NOT NULL,
        [PLAYERNAME] NVARCHAR(100) NOT NULL,
        [POSITION] NVARCHAR(50) NULL, 
        [AGE] INT NULL,
        [NUMBER] INT NULL,
    
        -- Xóa đội là xóa luôn cầu thủ
        FOREIGN KEY (IDTEAM) REFERENCES Teams(ID) ON DELETE CASCADE
    );

    -- BẢNG 5: TRẬN ĐẤU (MATCHES)
    CREATE TABLE [dbo].[Matches](
        [ID] INT IDENTITY(1,1) PRIMARY KEY,
        [TournamentID] INT NOT NULL,
    
        [Round] INT NOT NULL,          -- Vòng mấy (1, 2, 3...)
        [RoundType] INT DEFAULT 0,     -- 0: Vòng bảng, 1: Knockout
        [GroupName] NVARCHAR(10) NULL, -- Tên bảng (A, B, C...)
    
        [HomeTeamID] INT NOT NULL,     
        [AwayTeamID] INT NOT NULL,     
    
        [HomeScore] INT NULL,          -- NULL = Chưa đá
        [AwayScore] INT NULL,
    
        [MatchDate] DATETIME NULL,
        [Location] NVARCHAR(100) NULL,
        [Status] INT DEFAULT 0,        -- 0: Chưa, 1: Đang đá, 2: Xong
        [WinnerID] INT NULL,           -- Đội thắng (dùng cho Knockout)
        [ParentMatchId] INT NULL,      -- Dùng cho cây nhánh đấu

        -- QUAN TRỌNG: ON DELETE CASCADE ĐỂ XÓA GIẢI KHÔNG BỊ LỖI
        FOREIGN KEY (TournamentID) REFERENCES Tournaments(ID) ON DELETE CASCADE, 
        FOREIGN KEY (HomeTeamID) REFERENCES Teams(ID), -- (Không Cascade ở đây để tránh cycle)
        FOREIGN KEY (AwayTeamID) REFERENCES Teams(ID),
        FOREIGN KEY (WinnerID) REFERENCES Teams(ID)
    );
    GO

    -- =============================================================
    -- 3. STORED PROCEDURES (LOGIC CỐT LÕI)
    -- =============================================================

CREATE OR ALTER PROCEDURE [dbo].[sp_GenerateGroupStage]
    @TournamentID INT,
    @NumberOfGroups INT
AS
BEGIN
    SET NOCOUNT ON;
    -- ======================================================================================
    -- [PHẦN THÊM MỚI 1]: Khai báo biến và lấy thông tin từ bảng Tournaments
    -- ======================================================================================
    DECLARE @TourLocation NVARCHAR(100);
    DECLARE @StartDate DATETIME;
    
    -- Lấy địa điểm và ngày bắt đầu của giải đấu để dùng cho bên dưới
    SELECT @TourLocation = LOCATION, @StartDate = STARTDATE 
    FROM Tournaments WHERE ID = @TournamentID;

    -- A. KIỂM TRA INPUT (Validation)
    -- Kiểm tra số lượng đội
    DECLARE @TeamCount INT = (SELECT COUNT(*) FROM Teams WHERE TournamentID = @TournamentID);
    
    IF @NumberOfGroups <= 0
    BEGIN
        RAISERROR(N'Số lượng bảng phải lớn hơn 0.', 16, 1);
        RETURN;
    END

    -- Ít nhất mỗi bảng phải có 2 đội, nên tổng đội phải >= Số bảng * 2
    IF @TeamCount < (@NumberOfGroups * 2)
    BEGIN
        DECLARE @Msg NVARCHAR(200) = N'Không đủ đội (' + CAST(@TeamCount AS NVARCHAR) + N') để chia vào ' + CAST(@NumberOfGroups AS NVARCHAR) + N' bảng (Tối thiểu cần ' + CAST(@NumberOfGroups * 2 AS NVARCHAR) + N' đội).';
        RAISERROR(@Msg, 16, 1);
        RETURN;
    END

    -- B. XÓA LỊCH CŨ CỦA GIẢI NÀY (Để tạo lại từ đầu)
    -- Chỉ xóa các trận vòng bảng (RoundType = 0 hoặc Round = 1) để tránh mất dữ liệu vòng Knockout nếu lỡ tay
    DELETE FROM Matches WHERE TournamentID = @TournamentID;

    -- C. CHIA ĐỘI VÀO BẢNG (Dùng bảng tạm)
    CREATE TABLE #TempGroupMap (TeamID INT, GroupName NVARCHAR(10));

    -- Logic: Random thứ tự -> Chia đều bằng NTILE -> Gán chữ cái A, B, C...
    WITH RandomizedTeams AS (
        SELECT ID, ROW_NUMBER() OVER (ORDER BY NEWID()) as Rnd
        FROM Teams WHERE TournamentID = @TournamentID
    ),
    Grouped AS (
        SELECT ID as TeamID, NTILE(@NumberOfGroups) OVER (ORDER BY Rnd) as GroupNum
        FROM RandomizedTeams
    )
    INSERT INTO #TempGroupMap (TeamID, GroupName)
    SELECT TeamID, CHAR(64 + GroupNum) FROM Grouped; -- 65='A', 66='B'...

    -- D. TẠO LỊCH ĐẤU VÒNG TRÒN (Round Robin)
    -- Ghép cặp tất cả các đội trong cùng bảng với nhau
    INSERT INTO Matches (TournamentID, Round, RoundType, GroupName, HomeTeamID, AwayTeamID, Status, MatchDate, Location)
    SELECT 
        @TournamentID, 
        1,              -- Round 1
        0,              -- RoundType 0 (Group Stage)
        T1.GroupName, 
        T1.TeamID, 
        T2.TeamID, 
        0,              -- Status 0 (Chưa đá)
        DATEADD(HOUR, (ROW_NUMBER() OVER(ORDER BY NEWID()) - 1) * 2, @StartDate),           -- Ngày giờ, mỗi trận cách nhau 2 giờ
        @TourLocation
    FROM #TempGroupMap T1
    JOIN #TempGroupMap T2 ON T1.GroupName = T2.GroupName 
    WHERE T1.TeamID < T2.TeamID; -- Điều kiện T1 < T2 để chỉ tạo 1 trận (A vs B) chứ không tạo thêm (B vs A)

    -- E. LƯU SỐ LƯỢNG BẢNG VÀO DATABASE GIẢI ĐẤU
    -- Để sau này C# biết giải này có mấy bảng mà tính toán vé vào vòng trong
    UPDATE Tournaments SET GroupCount = @NumberOfGroups WHERE ID = @TournamentID;

    DROP TABLE #TempGroupMap;
    
    PRINT N'Đã chia bảng và tạo lịch thi đấu thành công!';
END;
GO

-- =============================================================
-- 2. SP: TÍNH BẢNG XẾP HẠNG (GetStandings) - LOGIC MỚI
-- =============================================================
CREATE OR ALTER PROCEDURE [dbo].[sp_GetStandings]
    @TournamentID INT,
    @GroupName NVARCHAR(10) = NULL -- Nếu NULL thì lấy hết, nếu truyền 'A' thì chỉ lấy bảng A
AS
BEGIN
    SET NOCOUNT ON;

    -- Dùng Common Table Expression (CTE) để tính điểm cho từng đội
    -- Dựa trên các trận ĐÃ KẾT THÚC (Status = 2) và thuộc Vòng bảng (RoundType = 0)
    WITH TeamStats AS (
        -- 1. Tính điểm khi đá SÂN NHÀ
        SELECT 
            HomeTeamID as TeamID,
            1 as Played,
            CASE 
                WHEN HomeScore > AwayScore THEN 3 -- Thắng: 3 điểm
                WHEN HomeScore = AwayScore THEN 1 -- Hòa: 1 điểm
                ELSE 0 END as Points,
            HomeScore as GF, -- Bàn thắng
            AwayScore as GA, -- Bàn thua
            CASE WHEN HomeScore > AwayScore THEN 1 ELSE 0 END as Won,
            CASE WHEN HomeScore = AwayScore THEN 1 ELSE 0 END as Drawn,
            CASE WHEN HomeScore < AwayScore THEN 1 ELSE 0 END as Lost
        FROM Matches 
        WHERE TournamentID = @TournamentID AND Status = 2 AND RoundType = 0
        
        UNION ALL
        
        -- 2. Tính điểm khi đá SÂN KHÁCH
        SELECT 
            AwayTeamID as TeamID,
            1 as Played,
            CASE 
                WHEN AwayScore > HomeScore THEN 3 
                WHEN AwayScore = HomeScore THEN 1 
                ELSE 0 END as Points,
            AwayScore as GF,
            HomeScore as GA,
            CASE WHEN AwayScore > HomeScore THEN 1 ELSE 0 END as Won,
            CASE WHEN AwayScore = HomeScore THEN 1 ELSE 0 END as Drawn,
            CASE WHEN AwayScore < HomeScore THEN 1 ELSE 0 END as Lost
        FROM Matches 
        WHERE TournamentID = @TournamentID AND Status = 2 AND RoundType = 0
    )

    -- 3. Gộp dữ liệu và hiển thị kết quả
    SELECT 
        T.ID as TeamID,
        T.TEAMNAME as Name,
        M.GroupName, -- Lấy tên bảng từ trận đấu (hoặc bảng map nếu cần kỹ hơn)
        ISNULL(SUM(S.Played), 0) as MP, -- Số trận đã đấu
        ISNULL(SUM(S.Won), 0) as W,     -- Thắng
        ISNULL(SUM(S.Drawn), 0) as D,   -- Hòa
        ISNULL(SUM(S.Lost), 0) as L,    -- Thua
        ISNULL(SUM(S.GF), 0) as GF,     -- Bàn thắng
        ISNULL(SUM(S.GA), 0) as GA,     -- Bàn thua
        ISNULL(SUM(S.GF) - SUM(S.GA), 0) as GD, -- Hiệu số
        ISNULL(SUM(S.Points), 0) as Points      -- Tổng điểm
    FROM Teams T
    -- Join lỏng (LEFT JOIN) với bảng tính điểm để đội chưa đá cũng hiện ra (với 0 điểm)
    LEFT JOIN TeamStats S ON T.ID = S.TeamID
    -- Join thêm bảng Matches một lần nữa chỉ để lấy GroupName cho chính xác (Mẹo nhỏ)
    -- (Hoặc có thể lưu GroupName vào bảng Teams, nhưng ở đây ta lấy từ lịch đấu)
    LEFT JOIN (SELECT DISTINCT GroupName, HomeTeamID FROM Matches WHERE TournamentID = @TournamentID AND RoundType = 0
               UNION 
               SELECT DISTINCT GroupName, AwayTeamID FROM Matches WHERE TournamentID = @TournamentID AND RoundType = 0
              ) M ON T.ID = M.HomeTeamID
    WHERE T.TournamentID = @TournamentID
    AND (@GroupName IS NULL OR M.GroupName = @GroupName) -- Lọc theo bảng nếu cần
    GROUP BY T.ID, T.TEAMNAME, M.GroupName
    ORDER BY 
        M.GroupName ASC,  -- Xếp theo tên bảng A, B, C trước
        Points DESC,      -- Điểm cao đứng trên
        GD DESC,          -- Hiệu số cao đứng trên
        GF DESC;          -- Bàn thắng nhiều đứng trên
END;
GO

-- =============================================================
-- 4. DỮ LIỆU MẪU (SEED DATA) - ĐỂ TEST
-- =============================================================

-- 1. Tài khoản Admin (User: admin / Pass: 123456)
INSERT INTO [dbo].[Account] ([Username], [PasswordHash])
VALUES ('admin', '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92');

-- 2. Tạo Giải đấu (Cấu hình: 12 Đội, 3 Bảng)
INSERT INTO [dbo].[Tournaments] 
([NAME], [LOCATION], [STARTDATE], [PRIZE], [SPORT], [TEAM_COUNT], [GroupCount], [CreatedBy])
VALUES 
(N'Vietnam Championship 2025', N'Ho Chi Minh', '2025-08-15', N'50,000,000', N'Soccer', 12, 4, 1);

-- Lấy ID của giải vừa tạo (thường là 1)
DECLARE @TourID INT = SCOPE_IDENTITY();

-- 3. Tạo 12 Đội bóng
INSERT INTO [dbo].[Teams] ([TournamentID], [TEAMNAME], [COACH]) VALUES
(@TourID, N'Ha Noi FC', N'Coach Bozidar'),
(@TourID, N'Cong An Ha Noi', N'Coach Kiatisuk'),
(@TourID, N'The Cong Viettel', N'Coach Duc Thang'),
(@TourID, N'MerryLand Binh Dinh', N'Coach Quang Huy'),
(@TourID, N'LPBank HAGL', N'Coach Vu Tien Thanh'),
(@TourID, N'Becamex Binh Duong', N'Coach Huynh Duc'),   
(@TourID, N'Thep Xanh Nam Dinh', N'Coach Vu Hong Viet'),
(@TourID, N'Hai Phong FC', N'Coach Chu Dinh Nghiem'),
(@TourID, N'Dong A Thanh Hoa', N'Coach Popov'),
(@TourID, N'Song Lam Nghe An', N'Coach Phan Nhu Thuat'),
(@TourID, N'Hong Linh Ha Tinh', N'Coach Thanh Cong'),
(@TourID, N'SHB Da Nang', N'Coach Viet Hoang');
-- =============================================================
-- 5. THÊM DỮ LIỆU CẦU THỦ (PLAYERS SEED DATA)
-- =============================================================

PRINT N'Đang thêm dữ liệu cầu thủ...';

-- 1. Cầu thủ cho: Ha Noi FC
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER])
SELECT ID, N'Nguyen Van Quyet', N'Tiền đạo', 33, 10 FROM Teams WHERE TEAMNAME = N'Ha Noi FC'
UNION ALL
SELECT ID, N'Do Hung Dung', N'Tiền vệ', 31, 88 FROM Teams WHERE TEAMNAME = N'Ha Noi FC'
UNION ALL
SELECT ID, N'Do Duy Manh', N'Hậu vệ', 28, 2 FROM Teams WHERE TEAMNAME = N'Ha Noi FC'
UNION ALL
SELECT ID, N'Pham Tuan Hai', N'Tiền đạo', 26, 9 FROM Teams WHERE TEAMNAME = N'Ha Noi FC'
UNION ALL
SELECT ID, N'Quan Van Chuan', N'Thủ môn', 23, 1 FROM Teams WHERE TEAMNAME = N'Ha Noi FC';

-- 2. Cầu thủ cho: Cong An Ha Noi (CAHN)
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER])
SELECT ID, N'Nguyen Quang Hai', N'Tiền vệ', 27, 19 FROM Teams WHERE TEAMNAME = N'Cong An Ha Noi'
UNION ALL
SELECT ID, N'Filip Nguyen', N'Thủ môn', 32, 1 FROM Teams WHERE TEAMNAME = N'Cong An Ha Noi'
UNION ALL
SELECT ID, N'Doan Van Hau', N'Hậu vệ', 25, 5 FROM Teams WHERE TEAMNAME = N'Cong An Ha Noi'
UNION ALL
SELECT ID, N'Vu Van Thanh', N'Hậu vệ', 28, 17 FROM Teams WHERE TEAMNAME = N'Cong An Ha Noi'
UNION ALL
SELECT ID, N'Geovane Magno', N'Tiền đạo', 30, 94 FROM Teams WHERE TEAMNAME = N'Cong An Ha Noi';

-- 3. Cầu thủ cho: The Cong Viettel
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER])
SELECT ID, N'Nguyen Hoang Duc', N'Tiền vệ', 26, 28 FROM Teams WHERE TEAMNAME = N'The Cong Viettel'
UNION ALL
SELECT ID, N'Bui Tien Dung', N'Hậu vệ', 29, 4 FROM Teams WHERE TEAMNAME = N'The Cong Viettel'
UNION ALL
SELECT ID, N'Nguyen Duc Chien', N'Tiền vệ', 26, 21 FROM Teams WHERE TEAMNAME = N'The Cong Viettel'
UNION ALL
SELECT ID, N'Phan Tuan Tai', N'Hậu vệ', 23, 12 FROM Teams WHERE TEAMNAME = N'The Cong Viettel'
UNION ALL
SELECT ID, N'Pedro Henrique', N'Tiền đạo', 27, 10 FROM Teams WHERE TEAMNAME = N'The Cong Viettel';

-- 4. Cầu thủ cho: MerryLand Binh Dinh
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER])
SELECT ID, N'Dang Van Lam', N'Thủ môn', 31, 1 FROM Teams WHERE TEAMNAME = N'MerryLand Binh Dinh'
UNION ALL
SELECT ID, N'Cao Van Trien', N'Tiền vệ', 31, 23 FROM Teams WHERE TEAMNAME = N'MerryLand Binh Dinh'
UNION ALL
SELECT ID, N'Leo Artur', N'Tiền đạo', 29, 10 FROM Teams WHERE TEAMNAME = N'MerryLand Binh Dinh'
UNION ALL
SELECT ID, N'Do Thanh Thinh', N'Hậu vệ', 26, 6 FROM Teams WHERE TEAMNAME = N'MerryLand Binh Dinh'
UNION ALL
SELECT ID, N'Adriano Schmidt', N'Hậu vệ', 30, 19 FROM Teams WHERE TEAMNAME = N'MerryLand Binh Dinh';

-- 5. Cầu thủ cho: LPBank HAGL
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER])
SELECT ID, N'Tran Minh Vuong', N'Tiền vệ', 29, 8 FROM Teams WHERE TEAMNAME = N'LPBank HAGL'
UNION ALL
SELECT ID, N'Chau Ngoc Quang', N'Tiền vệ', 28, 24 FROM Teams WHERE TEAMNAME = N'LPBank HAGL'
UNION ALL
SELECT ID, N'Dinh Thanh Binh', N'Tiền đạo', 26, 10 FROM Teams WHERE TEAMNAME = N'LPBank HAGL'
UNION ALL
SELECT ID, N'Jairo Rodrigues', N'Hậu vệ', 31, 33 FROM Teams WHERE TEAMNAME = N'LPBank HAGL'
UNION ALL
SELECT ID, N'Bui Tien Dung', N'Thủ môn', 27, 36 FROM Teams WHERE TEAMNAME = N'LPBank HAGL';

-- 6. Cầu thủ cho: Becamex Binh Duong
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER])
SELECT ID, N'Nguyen Tien Linh', N'Tiền đạo', 27, 22 FROM Teams WHERE TEAMNAME = N'Becamex Binh Duong'
UNION ALL
SELECT ID, N'Que Ngoc Hai', N'Hậu vệ', 31, 3 FROM Teams WHERE TEAMNAME = N'Becamex Binh Duong'
UNION ALL
SELECT ID, N'Nguyen Hai Huy', N'Tiền vệ', 33, 14 FROM Teams WHERE TEAMNAME = N'Becamex Binh Duong'
UNION ALL
SELECT ID, N'Janclesio', N'Hậu vệ', 30, 4 FROM Teams WHERE TEAMNAME = N'Becamex Binh Duong'
UNION ALL
SELECT ID, N'Bui Vi Hao', N'Tiền đạo', 21, 11 FROM Teams WHERE TEAMNAME = N'Becamex Binh Duong';

-- 7. Thep Xanh Nam Dinh
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER])
SELECT ID, N'Tran Nguyen Manh', N'Thủ môn', 32, 26 FROM Teams WHERE TEAMNAME = N'Thep Xanh Nam Dinh' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Nguyen Phong Hong Duy', N'Hậu vệ', 28, 7 FROM Teams WHERE TEAMNAME = N'Thep Xanh Nam Dinh' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Nguyen Van Toan', N'Tiền đạo', 28, 9 FROM Teams WHERE TEAMNAME = N'Thep Xanh Nam Dinh' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Rafaelson', N'Tiền đạo', 27, 10 FROM Teams WHERE TEAMNAME = N'Thep Xanh Nam Dinh' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Hendrio Araujo', N'Tiền vệ', 30, 11 FROM Teams WHERE TEAMNAME = N'Thep Xanh Nam Dinh' AND TournamentID = @TourID;

-- 8. Hai Phong FC
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER])
SELECT ID, N'Nguyen Dinh Trieu', N'Thủ môn', 32, 1 FROM Teams WHERE TEAMNAME = N'Hai Phong FC' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Joseph Mpande', N'Tiền đạo', 29, 7 FROM Teams WHERE TEAMNAME = N'Hai Phong FC' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Trieu Viet Hung', N'Tiền vệ', 27, 97 FROM Teams WHERE TEAMNAME = N'Hai Phong FC' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Bicou Bissainthe', N'Hậu vệ', 25, 66 FROM Teams WHERE TEAMNAME = N'Hai Phong FC' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Luong Hoang Nam', N'Tiền vệ', 26, 30 FROM Teams WHERE TEAMNAME = N'Hai Phong FC' AND TournamentID = @TourID;

-- 9. Dong A Thanh Hoa
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER])
SELECT ID, N'Nguyen Thanh Diep', N'Thủ môn', 32, 25 FROM Teams WHERE TEAMNAME = N'Dong A Thanh Hoa' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Nguyen Thai Son', N'Tiền vệ', 21, 12 FROM Teams WHERE TEAMNAME = N'Dong A Thanh Hoa' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Gustavo Santos', N'Hậu vệ', 29, 95 FROM Teams WHERE TEAMNAME = N'Dong A Thanh Hoa' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Rimario Gordon', N'Tiền đạo', 30, 9 FROM Teams WHERE TEAMNAME = N'Dong A Thanh Hoa' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Lam Ti Phong', N'Tiền đạo', 28, 17 FROM Teams WHERE TEAMNAME = N'Dong A Thanh Hoa' AND TournamentID = @TourID;

-- 10. Song Lam Nghe An (SLNA)
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER])
SELECT ID, N'Nguyen Van Viet', N'Thủ môn', 22, 1 FROM Teams WHERE TEAMNAME = N'Song Lam Nghe An' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Michael Olaha', N'Tiền đạo', 27, 7 FROM Teams WHERE TEAMNAME = N'Song Lam Nghe An' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Tran Dinh Hoang', N'Hậu vệ', 32, 6 FROM Teams WHERE TEAMNAME = N'Song Lam Nghe An' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Dinh Xuan Tien', N'Tiền vệ', 21, 10 FROM Teams WHERE TEAMNAME = N'Song Lam Nghe An' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Mai Sy Hoang', N'Hậu vệ', 25, 23 FROM Teams WHERE TEAMNAME = N'Song Lam Nghe An' AND TournamentID = @TourID;

-- 11. Hong Linh Ha Tinh
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER])
SELECT ID, N'Nguyen Thanh Tung', N'Thủ môn', 25, 1 FROM Teams WHERE TEAMNAME = N'Hong Linh Ha Tinh' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Luong Xuan Truong', N'Tiền vệ', 29, 6 FROM Teams WHERE TEAMNAME = N'Hong Linh Ha Tinh' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Vu Quang Nam', N'Tiền đạo', 32, 18 FROM Teams WHERE TEAMNAME = N'Hong Linh Ha Tinh' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Bruno Ramires', N'Tiền vệ', 30, 8 FROM Teams WHERE TEAMNAME = N'Hong Linh Ha Tinh' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Nguyen Van Hanh', N'Hậu vệ', 26, 4 FROM Teams WHERE TEAMNAME = N'Hong Linh Ha Tinh' AND TournamentID = @TourID;

-- 12. SHB Da Nang
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER])
SELECT ID, N'Phan Van Bieu', N'Thủ môn', 26, 1 FROM Teams WHERE TEAMNAME = N'SHB Da Nang' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Ha Minh Tuan', N'Tiền đạo', 33, 9 FROM Teams WHERE TEAMNAME = N'SHB Da Nang' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Luong Duy Cuong', N'Hậu vệ', 22, 2 FROM Teams WHERE TEAMNAME = N'SHB Da Nang' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Pham Dinh Duy', N'Tiền đạo', 22, 18 FROM Teams WHERE TEAMNAME = N'SHB Da Nang' AND TournamentID = @TourID
UNION ALL SELECT ID, N'Nguyen Phi Hoang', N'Tiền vệ', 21, 21 FROM Teams WHERE TEAMNAME = N'SHB Da Nang' AND TournamentID = @TourID;
PRINT N'Đã thêm dữ liệu cầu thủ thành công!';
GO






