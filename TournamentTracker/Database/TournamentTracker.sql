USE master;
GO

-- =============================================================
-- BƯỚC 1: RESET DATABASE (Xóa cũ tạo mới sạch sẽ)
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
-- BƯỚC 2: TẠO CẤU TRÚC BẢNG (SCHEMA)
-- =============================================================

-- 1. Bảng ACCOUNT (Tài khoản đăng nhập)
CREATE TABLE [dbo].[Account](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Username] NVARCHAR(50) NOT NULL UNIQUE,
    [PasswordHash] NVARCHAR(255) NOT NULL, -- Mật khẩu (SHA256)
    [CreatedAt] DATETIME DEFAULT GETDATE()
);

-- 2. Bảng TOURNAMENTS (Giải đấu) - [ĐÃ CẬP NHẬT]
CREATE TABLE [dbo].[Tournaments](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [NAME] NVARCHAR(100) NOT NULL,
    [LOCATION] NVARCHAR(100) NULL,
    [STARTDATE] DATE NULL,
    [PRIZE] NVARCHAR(50) NULL,
    [POSTERPATH] NVARCHAR(255) NULL,
    [SPORT] NVARCHAR(50),   
    [TEAM_COUNT] INT,
    [CreatedBy] INT NULL, -- Liên kết: Giải này do ai tạo?
    
    -- [MỚI] 3 CỘT LƯU FORMAT GIẢI ĐẤU
    [FormatMode] NVARCHAR(50) DEFAULT 'Single',    -- 'Single' hoặc 'Multi'
    [Stage1Format] NVARCHAR(50) DEFAULT 'Knockout', -- Vòng 1: 'Knockout', 'Round Robin', 'Group Stage'
    [Stage2Format] NVARCHAR(50) NULL,               -- Vòng 2 (Nếu có): 'Knockout', NULL

    FOREIGN KEY (CreatedBy) REFERENCES Account(ID)
);

-- 3. Bảng TEAMS (Đội bóng)
CREATE TABLE [dbo].[Teams](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [TournamentID] INT NOT NULL, -- Đội thuộc về giải nào
    [TEAMNAME] NVARCHAR(100) NOT NULL,
    [COACH] NVARCHAR(100) NULL,
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(ID) ON DELETE CASCADE
);

-- 4. Bảng PLAYERS (Cầu thủ)
CREATE TABLE [dbo].[Players](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [IDTEAM] INT NOT NULL, -- Cầu thủ thuộc đội nào
    [PLAYERNAME] NVARCHAR(100) NOT NULL,
    [POSITION] NVARCHAR(50) NULL, 
    [AGE] INT NULL,
    [NUMBER] INT NULL,
    FOREIGN KEY (IDTEAM) REFERENCES Teams(ID) ON DELETE CASCADE
);

-- 5. Bảng MATCHES (Trận đấu)
CREATE TABLE [dbo].[Matches](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [TournamentID] INT NOT NULL, -- Trận đấu thuộc giải nào
    [Round] INT NOT NULL,          -- Vòng đấu (1, 2, 3...)
    [RoundType] INT DEFAULT 0,     -- 0: Vòng bảng/Vòng 1, 1: Knockout/Vòng 2
    [GroupName] NVARCHAR(10) NULL, -- Tên bảng đấu (A, B, C...)
    
    [HomeTeamID] INT NOT NULL,     -- Đội nhà
    [AwayTeamID] INT NOT NULL,     -- Đội khách
    
    [HomeScore] INT NULL,          -- Tỷ số (NULL = Chưa đá)
    [AwayScore] INT NULL,
    
    [MatchDate] DATETIME NULL,
    [Location] NVARCHAR(100) NULL,
    [Status] INT DEFAULT 0,        -- 0: Chưa đá, 1: Đang đá, 2: Kết thúc
    [WinnerID] INT NULL,           -- Đội thắng
    [ParentMatchId] INT NULL,      -- Nhánh đấu cha (cho cây knockout)

    FOREIGN KEY (TournamentID) REFERENCES Tournaments(ID), 
    FOREIGN KEY (HomeTeamID) REFERENCES Teams(ID),
    FOREIGN KEY (AwayTeamID) REFERENCES Teams(ID),
    FOREIGN KEY (WinnerID) REFERENCES Teams(ID),
    FOREIGN KEY (ParentMatchId) REFERENCES Matches(ID)
);
GO




-- ======================================================================================
-- BƯỚC 1: KHAI BÁO BIẾN (Dùng chung cho cả script)
-- ======================================================================================
DECLARE @TourID INT;
DECLARE @T1 INT, @T2 INT, @T3 INT; -- Biến lưu ID đội bóng

PRINT N'=== BẮT ĐẦU TẠO DỮ LIỆU MẪU ===';

-- ======================================================================================
-- KỊCH BẢN 1: GIẢI "MINI CUP 2025" (3 Đội - Đá vòng tròn - Đã đá xong)
-- ======================================================================================
PRINT N'--- Đang tạo giải 1: Mini Cup 2025 ---';

-- 1. Tạo Giải
INSERT INTO [dbo].[Tournaments] 
([NAME], [LOCATION], [STARTDATE], [PRIZE], [POSTERPATH], [SPORT], [TEAM_COUNT], [FormatMode], [Stage1Format]) 
VALUES
(N'Mini Cup 2025', N'Hanoi', '2025-01-10', N'10,000,000 VND', N'/images/mini.jpg', N'Soccer', 3, 'Single', 'Round Robin');

SET @TourID = SCOPE_IDENTITY();

-- 2. Tạo 3 Đội
INSERT INTO [dbo].[Teams] ([TournamentID], [TEAMNAME], [COACH]) VALUES
(@TourID, N'Red Dragon FC', N'Coach Red'),
(@TourID, N'Blue Shark FC', N'Coach Blue'),
(@TourID, N'Green Tiger FC', N'Coach Green');

-- Lấy ID
SELECT @T1 = ID FROM Teams WHERE TournamentID = @TourID AND TEAMNAME = N'Red Dragon FC';
SELECT @T2 = ID FROM Teams WHERE TournamentID = @TourID AND TEAMNAME = N'Blue Shark FC';
SELECT @T3 = ID FROM Teams WHERE TournamentID = @TourID AND TEAMNAME = N'Green Tiger FC';

-- 3. Thêm Cầu thủ (Mỗi đội 1 người đại diện)
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [NUMBER]) VALUES
(@T1, N'Nguyen Van Do', 'FW', 10),
(@T2, N'Tran Van Xanh', 'MF', 8),
(@T3, N'Le Van La', 'DF', 4);

-- 4. Tạo Lịch đấu (3 Round - Tất cả đã kết thúc)
INSERT INTO [dbo].[Matches] 
([TournamentID], [Round], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Status], [WinnerID]) 
VALUES
-- Round 1: Red vs Blue
(@TourID, 1, @T1, @T2, 2, 1, '2025-01-10 18:00:00', 2, @T1),
-- Round 2: Blue vs Green
(@TourID, 2, @T2, @T3, 1, 1, '2025-01-12 18:00:00', 2, NULL), -- Hòa
-- Round 3: Green vs Red
(@TourID, 3, @T3, @T1, 0, 3, '2025-01-14 18:00:00', 2, @T1);


-- ======================================================================================
-- KỊCH BẢN 2: GIẢI "SIÊU CÚP ANH" (2 Đội - Best of 3)
-- ======================================================================================
PRINT N'--- Đang tạo giải 2: Super Cup Series ---';

-- 1. Tạo Giải
INSERT INTO [dbo].[Tournaments] 
([NAME], [LOCATION], [STARTDATE], [PRIZE], [POSTERPATH], [SPORT], [TEAM_COUNT], [FormatMode], [Stage1Format]) 
VALUES
(N'Super Cup Series', N'London', '2025-06-01', N'$1,000,000', N'/images/super.jpg', N'Soccer', 2, 'Single', 'Knockout');

SET @TourID = SCOPE_IDENTITY();

-- 2. Tạo 2 Đội
INSERT INTO [dbo].[Teams] ([TournamentID], [TEAMNAME], [COACH]) VALUES
(@TourID, N'Arsenal', N'Mikel Arteta'),
(@TourID, N'Chelsea', N'Enzo Maresca');

-- Lấy ID
SELECT @T1 = ID FROM Teams WHERE TournamentID = @TourID AND TEAMNAME = N'Arsenal';
SELECT @T2 = ID FROM Teams WHERE TournamentID = @TourID AND TEAMNAME = N'Chelsea';

-- 3. Thêm Cầu thủ
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [NUMBER]) VALUES
(@T1, N'Saka', 'FW', 7),
(@T2, N'Palmer', 'MF', 20);

-- 4. Tạo Lịch đấu (3 Round - 1 trận xong, 1 đang đá, 1 chưa đá)
INSERT INTO [dbo].[Matches] 
([TournamentID], [Round], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Status], [WinnerID]) 
VALUES
-- Round 1: Lượt đi (Xong)
(@TourID, 1, @T1, @T2, 2, 0, GETDATE()-2, 2, @T1), 
-- Round 2: Lượt về (Đang diễn ra)
(@TourID, 2, @T2, @T1, 1, 1, GETDATE(), 1, NULL),
-- Round 3: Chung kết (Chưa đá)
(@TourID, 3, @T1, @T2, NULL, NULL, GETDATE()+7, 0, NULL);


-- ======================================================================================
-- KỊCH BẢN 3: GIẢI "GIAO HỮU MÙA HÈ" (3 Đội - Có 1 đội được miễn vòng 1)
-- ======================================================================================
PRINT N'--- Đang tạo giải 3: Summer Friendly ---';

-- 1. Tạo Giải
INSERT INTO [dbo].[Tournaments] 
([NAME], [LOCATION], [STARTDATE], [PRIZE], [POSTERPATH], [SPORT], [TEAM_COUNT], [FormatMode], [Stage1Format]) 
VALUES
(N'Summer Friendly 2025', N'Da Nang', '2025-07-20', N'Cúp Vàng', N'/images/summer.jpg', N'Soccer', 3, 'Single', 'Knockout');

SET @TourID = SCOPE_IDENTITY();

-- 2. Tạo 3 Đội
INSERT INTO [dbo].[Teams] ([TournamentID], [TEAMNAME], [COACH]) VALUES
(@TourID, N'Hanoi FC', N'Coach HN'),
(@TourID, N'Da Nang FC', N'Coach DN'),
(@TourID, N'Hai Phong FC', N'Coach HP');

-- Lấy ID
SELECT @T1 = ID FROM Teams WHERE TournamentID = @TourID AND TEAMNAME = N'Hanoi FC';
SELECT @T2 = ID FROM Teams WHERE TournamentID = @TourID AND TEAMNAME = N'Da Nang FC';
SELECT @T3 = ID FROM Teams WHERE TournamentID = @TourID AND TEAMNAME = N'Hai Phong FC';

-- 3. Tạo Lịch đấu
-- Giả sử Hanoi FC được đặc cách vào thẳng chung kết (Round 2)
INSERT INTO [dbo].[Matches] 
([TournamentID], [Round], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Status]) 
VALUES
-- Round 1: Da Nang vs Hai Phong (Loại trực tiếp) - Chưa đá
(@TourID, 1, @T2, @T3, NULL, NULL, '2025-07-20 15:00:00', 0),

-- Round 2: Hanoi FC vs (Người thắng cặp trên - Tạm để NULL AwayTeamID hoặc điền tạm ID đội T2 để test)
-- Ở đây mình set tạm là Hanoi vs Da Nang (dự kiến)
(@TourID, 2, @T1, @T2, NULL, NULL, '2025-07-25 15:00:00', 0);

GO
PRINT N'=== HOÀN TẤT TẠO DỮ LIỆU ===';