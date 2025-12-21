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

-- =============================================================
-- BƯỚC 3: DỮ LIỆU MẪU (SEED DATA)
-- =============================================================

-- 1. Tạo Tài khoản Admin (User: admin / Pass: 123456)
INSERT INTO [dbo].[Account] ([Username], [PasswordHash])
VALUES ('admin', '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92');

-- 2. Tạo 2 Giải Đấu Mẫu (CẬP NHẬT CỘT FORMAT MỚI)
INSERT INTO [dbo].[Tournaments] 
([NAME], [LOCATION], [STARTDATE], [PRIZE], [SPORT], [TEAM_COUNT], [CreatedBy], [FormatMode], [Stage1Format], [Stage2Format])
VALUES 
-- Giải 1: Champions Cup (Đá nhiều vòng: Vòng bảng -> Knockout)
(N'Champions Cup 2024', N'Châu Âu', '2025-05-01', N'10,000,000', N'Soccer', 4, 1, 'Multi', 'Group Stage', 'Knockout'),

-- Giải 2: V-League (Đá 1 vòng Knockout duy nhất)
(N'V-League Open', N'Việt Nam', '2024-06-15', N'500,000', N'Soccer', 2, 1, 'Single', 'Knockout', NULL);

-- 3. Tạo Đội Bóng
INSERT INTO [dbo].[Teams] ([TournamentID], [TEAMNAME], [COACH]) VALUES
(1, N'Real Madrid', N'Ancelotti'),
(1, N'Man City', N'Pep Guardiola'),
(1, N'Bayern Munich', N'Tuchel'),
(1, N'Barcelona', N'Xavi');

INSERT INTO [dbo].[Teams] ([TournamentID], [TEAMNAME], [COACH]) VALUES
(2, N'Hanoi FC', N'Iwamasa'),
(2, N'Cong An Ha Noi', N'Kiatisuk');

-- 4. Tạo Cầu Thủ Mẫu
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [NUMBER]) VALUES
(1, N'Vinicius Jr', N'FW', 7),
(1, N'Jude Bellingham', N'MF', 5),
(5, N'Nguyen Van Quyet', N'FW', 10);

-- 5. Tạo Lịch Thi Đấu Mẫu
INSERT INTO [dbo].[Matches] ([TournamentID], [Round], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Status])
VALUES
(1, 1, 1, 2, 3, 3, GETDATE(), 2), -- Real vs Man City
(1, 1, 3, 4, NULL, NULL, GETDATE(), 0); -- Bayern vs Barca

INSERT INTO [dbo].[Matches] ([TournamentID], [Round], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Status])
VALUES
(2, 1, 5, 6, 2, 0, GETDATE(), 2); -- Hanoi vs CAHN
GO