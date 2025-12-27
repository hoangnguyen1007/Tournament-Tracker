  -- BẢNG 1: TÀI KHOẢN
    CREATE TABLE [dbo].[Account](
        [ID] INT IDENTITY(1,1) PRIMARY KEY,
        [Username] NVARCHAR(50) NOT NULL UNIQUE,
        [PasswordHash] NVARCHAR(255) NOT NULL, 
        [CreatedAt] DATETIME DEFAULT GETDATE()
    );

    -- BẢNG 2: GIẢI ĐẤU 
    CREATE TABLE [dbo].[Tournaments](
        [ID] INT IDENTITY(1,1) PRIMARY KEY,
        [NAME] NVARCHAR(100) NOT NULL,
        [LOCATION] NVARCHAR(100) NULL,
        [STARTDATE] DATE NULL,
        [PRIZE] NVARCHAR(50) NULL,
        [POSTERPATH] NVARCHAR(255) NULL,
        [SPORT] NVARCHAR(50),   
        [TEAM_COUNT] INT DEFAULT 0,
        [CreatedBy] INT NULL,      
        [GroupCount] INT DEFAULT 1,
        FOREIGN KEY (CreatedBy) REFERENCES Account(ID)
    );

    -- BẢNG 3: ĐỘI BÓNG
    CREATE TABLE [dbo].[Teams](
        [ID] INT IDENTITY(1,1) PRIMARY KEY,
        [TournamentID] INT NOT NULL,
        [TEAMNAME] NVARCHAR(100) NOT NULL,
        [COACH] NVARCHAR(100) NULL,
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
        FOREIGN KEY (IDTEAM) REFERENCES Teams(ID) ON DELETE CASCADE
    );

    -- BẢNG 5: TRẬN ĐẤU (MATCHES)
    CREATE TABLE [dbo].[Matches](
        [ID] INT IDENTITY(1,1) PRIMARY KEY,
        [TournamentID] INT NOT NULL,
    
        [Round] INT NOT NULL,      
        [RoundType] INT DEFAULT 0,   
        [GroupName] NVARCHAR(10) NULL, 
    
        [HomeTeamID] INT NOT NULL,     
        [AwayTeamID] INT NOT NULL,     
    
        [HomeScore] INT NULL,       
        [AwayScore] INT NULL,
    
        [MatchDate] DATETIME NULL,
        [Location] NVARCHAR(100) NULL,
        [Status] INT DEFAULT 0,        
        [WinnerID] INT NULL,         
        [ParentMatchId] INT NULL,    

        FOREIGN KEY (TournamentID) REFERENCES Tournaments(ID) ON DELETE CASCADE, 
        FOREIGN KEY (HomeTeamID) REFERENCES Teams(ID),
        FOREIGN KEY (AwayTeamID) REFERENCES Teams(ID),
        FOREIGN KEY (WinnerID) REFERENCES Teams(ID)
    );
    GO

    -- 3. STORED PROCEDURES 

CREATE OR ALTER PROCEDURE [dbo].[sp_GenerateGroupStage]
    @TournamentID INT,
    @NumberOfGroups INT
AS
BEGIN
    SET NOCOUNT ON;
--Khai báo biến và lấy thông tin từ bảng Tournaments
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

    -- B. XÓA LỊCH CŨ CỦA GIẢI NÀY
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
-- 2. SP: TÍNH BẢNG XẾP HẠNG (GetStandings)
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
    LEFT JOIN TeamStats S ON T.ID = S.TeamID
    LEFT JOIN (SELECT DISTINCT GroupName, HomeTeamID FROM Matches WHERE TournamentID = @TournamentID AND RoundType = 0
               UNION 
               SELECT DISTINCT GroupName, AwayTeamID FROM Matches WHERE TournamentID = @TournamentID AND RoundType = 0
              ) M ON T.ID = M.HomeTeamID
    WHERE T.TournamentID = @TournamentID
    AND (@GroupName IS NULL OR M.GroupName = @GroupName)
    GROUP BY T.ID, T.TEAMNAME, M.GroupName
    ORDER BY 
        M.GroupName ASC,  
        Points DESC, 
        GD DESC,        
        GF DESC;     
END;
GO







