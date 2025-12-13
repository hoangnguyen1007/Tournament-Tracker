USE master;
GO

-- 1. XÓA DB CŨ NẾU TỒN TẠI (Để làm lại cho sạch sẽ, tránh lỗi cột cũ)
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

-- =============================================
-- PHẦN 1: ACCOUNT & TEAMS
-- =============================================

-- 2. Bảng ACCOUNT
CREATE TABLE [dbo].[Account](
    [ID] [int] IDENTITY(1,1) PRIMARY KEY,
    [Username] [nvarchar](50) NOT NULL UNIQUE,
    [PasswordHash] [nvarchar](255) NOT NULL,
    [CreatedAt] [datetime] DEFAULT GETDATE()
);

-- TẠO TÀI KHOẢN MẶC ĐỊNH (Admin / 123456)
-- PasswordHash này là của "123456" (SHA256)
INSERT INTO [dbo].[Account] ([Username], [PasswordHash])
VALUES ('admin', '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92');

-- 3. Bảng Teams 
CREATE TABLE [dbo].[Teams](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [TEAMNAME] NVARCHAR(100) NOT NULL,
    [COACH] NVARCHAR(100) NULL,
);

-- 4. Bảng Players 
CREATE TABLE [dbo].[Players](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [IDTEAM] INT NOT NULL,
    [PLAYERNAME] NVARCHAR(100) NOT NULL,
    [POSITION] NVARCHAR(50) NULL, 
    [AGE] INT NULL,
    [NUMBER] INT NULL,
    FOREIGN KEY (IDTEAM) REFERENCES Teams(ID)
);

-- =============================================
-- PHẦN 2: TOURNAMENTS
-- =============================================

-- 5. Bảng Tournaments
CREATE TABLE [dbo].[Tournaments](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [NAME] NVARCHAR(100) NOT NULL,
    [LOCATION] NVARCHAR(100) NULL,
    [STARTDATE] DATE NULL,
    [PRIZE] NVARCHAR(50) NULL,
    [POSTERPATH] NVARCHAR(255) NULL,
    [SPORT] NVARCHAR(50),   
    [TEAM_COUNT] int,
    [CreatedBy] INT NULL, -- Liên kết với Account
    FOREIGN KEY (CreatedBy) REFERENCES Account(ID)
);

-- =============================================
-- PHẦN 3: MATCHES (Đã Fix cột TournamentID)
-- =============================================

-- 7. Bảng Matches
CREATE TABLE [dbo].[Matches](
    [ID] [int] IDENTITY(1,1) PRIMARY KEY,
    [TournamentID] [int] NOT NULL, -- Cột quan trọng vừa thêm
    [Round] [int] NOT NULL,
    [HomeTeamID] [int] NOT NULL,
    [AwayTeamID] [int] NOT NULL,
    [HomeScore] [int] NULL,
    [AwayScore] [int] NULL,
    [MatchDate] DATETIME NULL,
    [Location] NVARCHAR(100) NULL,
    [Status] INT DEFAULT 0,
    [WinnerID] INT NULL,
    [RoundType] INT NOT NULL DEFAULT 0,   
    [GroupName] NVARCHAR(10) NULL, 
    [ParentMatchId] INT NULL,

    FOREIGN KEY (HomeTeamID) REFERENCES Teams(ID),
    FOREIGN KEY (AwayTeamID) REFERENCES Teams(ID),
    FOREIGN KEY (WinnerID) REFERENCES Teams(ID),
    FOREIGN KEY (ParentMatchId) REFERENCES Matches(ID),
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(ID)
);
GO

-- =============================================
-- PHẦN 4: DỮ LIỆU MẪU (SEED DATA)
-- =============================================


-- ============================================================
-- TESTCASE CỦA TEAM - PLAYER (Thành Nguyên)
-- ============================================================
INSERT INTO [dbo].[Teams] ([TEAMNAME], [COACH]) VALUES
(N'Real Madrid', N'Carlo Ancelotti'),       
(N'Manchester City', N'Pep Guardiola'),     
(N'Manchester United', N'Erik ten Hag'),    
(N'Arsenal', N'Mikel Arteta'),             
(N'Liverpool', N'Jurgen Klopp'),            
(N'Bayern Munich', N'Thomas Tuchel'),       
(N'Barcelona', N'Xavi Hernandez'),          
(N'Paris Saint-Germain', N'Luis Enrique'),  
(N'Chelsea', N'Mauricio Pochettino'),       
(N'Hanoi FC', N'Daiki Iwamasa');            
GO

-- Team 1: Real Madrid
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER]) VALUES
(1, N'Thibaut Courtois', 'GK', 31, 1),
(1, N'David Alaba', 'DF', 31, 4),
(1, N'Luka Modric', 'MF', 38, 10),
(1, N'Jude Bellingham', 'MF', 20, 5),
(1, N'Vinicius Jr', 'FW', 23, 7);

-- Team 2: Manchester City
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER]) VALUES
(2, N'Ederson', 'GK', 30, 31),
(2, N'Ruben Dias', 'DF', 26, 3),
(2, N'Kevin De Bruyne', 'MF', 32, 17),
(2, N'Rodri', 'MF', 27, 16),
(2, N'Erling Haaland', 'FW', 23, 9);

-- Team 3: Manchester United
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER]) VALUES
(3, N'Andre Onana', 'GK', 27, 24),
(3, N'Harry Maguire', 'DF', 30, 5),
(3, N'Bruno Fernandes', 'MF', 29, 8),
(3, N'Marcus Rashford', 'FW', 26, 10),
(3, N'Rasmus Hojlund', 'FW', 21, 11);

-- Team 4: Arsenal
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER]) VALUES
(4, N'David Raya', 'GK', 28, 22),
(4, N'William Saliba', 'DF', 22, 2),
(4, N'Declan Rice', 'MF', 25, 41),
(4, N'Martin Odegaard', 'MF', 25, 8),
(4, N'Bukayo Saka', 'FW', 22, 7);

-- Team 5: Liverpool
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER]) VALUES
(5, N'Alisson Becker', 'GK', 31, 1),
(5, N'Virgil van Dijk', 'DF', 32, 4),
(5, N'Mac Allister', 'MF', 25, 10),
(5, N'Mohamed Salah', 'FW', 31, 11),
(5, N'Darwin Nunez', 'FW', 24, 9);

-- Team 6: Bayern Munich
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER]) VALUES
(6, N'Manuel Neuer', 'GK', 37, 1),
(6, N'Matthijs de Ligt', 'DF', 24, 4),
(6, N'Joshua Kimmich', 'MF', 29, 6),
(6, N'Jamal Musiala', 'MF', 21, 42),
(6, N'Harry Kane', 'FW', 30, 9);

-- Team 7: Barcelona
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER]) VALUES
(7, N'Ter Stegen', 'GK', 31, 1),
(7, N'Ronald Araujo', 'DF', 25, 4),
(7, N'Pedri', 'MF', 21, 8),
(7, N'Frenkie de Jong', 'MF', 26, 21),
(7, N'Robert Lewandowski', 'FW', 35, 9);

-- Team 8: PSG
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER]) VALUES
(8, N'Donnarumma', 'GK', 25, 99),
(8, N'Hakimi', 'DF', 25, 2),
(8, N'Vitinha', 'MF', 24, 17),
(8, N'Ousmane Dembele', 'FW', 26, 10),
(8, N'Mbappe', 'FW', 25, 7);

-- Team 9: Chelsea
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER]) VALUES
(9, N'Robert Sanchez', 'GK', 26, 1),
(9, N'Reece James', 'DF', 24, 24),
(9, N'Enzo Fernandez', 'MF', 23, 8),
(9, N'Cole Palmer', 'MF', 21, 20),
(9, N'Raheem Sterling', 'FW', 29, 7);

-- Team 10: Hanoi FC (Vietnam)
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [AGE], [NUMBER]) VALUES
(10, N'Quan Van Chuan', 'GK', 23, 1),
(10, N'Do Duy Manh', 'DF', 27, 2),
(10, N'Do Hung Dung', 'MF', 30, 88),
(10, N'Nguyen Van Quyet', 'FW', 32, 10),
(10, N'Pham Tuan Hai', 'FW', 25, 9);
GO



-- =============================================
-- 1. DATA BẢNG TOURNAMENTS 
-- =============================================
INSERT INTO [dbo].[Tournaments] 
([NAME], [LOCATION], [STARTDATE], [PRIZE], [POSTERPATH], [SPORT], [TEAM_COUNT]) 
VALUES
(N'Champions Cup 2024', N'Europe', '2024-05-01', N'$10,000,000', N'/images/ucl2024.jpg', N'Soccer', 8),
(N'Premier League Simulation', N'England', '2024-08-12', N'$50,000,000', N'/images/pl.jpg', N'Soccer', 20),
(N'Friendly Asia Tour', N'Vietnam', '2024-06-15', N'$500,000', N'/images/friendly.jpg', N'Soccer', 4);
GO

-- =============================================
-- 2. DATA BẢNG MATCHES
-- =============================================

-- K?CH B?N 1: CHAMPIONS CUP (TournamentID = 1)
INSERT INTO [dbo].[Matches] 
([TournamentID], [Round], [RoundType], [GroupName], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Location], [Status], [WinnerID]) 
VALUES
-- Round 1 (T? k?t)
(1, 1, 1, NULL, 1, 2, 3, 1, '2024-05-01 20:00:00', N'Santiago Bernabéu', 2, 1),
(1, 1, 1, NULL, 6, 7, 2, 2, '2024-05-02 20:00:00', N'Allianz Arena', 2, 6),
(1, 1, 1, NULL, 8, 4, 1, 2, '2024-05-03 20:00:00', N'Parc des Princes', 2, 4),
(1, 1, 1, NULL, 5, 3, 4, 0, '2024-05-04 20:00:00', N'Anfield', 2, 5),

-- Round 2 (Bán k?t)
(1, 2, 1, NULL, 1, 6, NULL, NULL, '2024-05-15 20:00:00', N'Wembley Stadium', 0, NULL),
(1, 2, 1, NULL, 4, 5, NULL, NULL, '2024-05-16 20:00:00', N'Wembley Stadium', 0, NULL);


-- K?CH B?N 2: FRIENDLY ASIA TOUR (TournamentID = 3)
INSERT INTO [dbo].[Matches] 
([TournamentID], [Round], [RoundType], [GroupName], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Location], [Status], [WinnerID]) 
VALUES
-- Round 1
(3, 1, 0, N'A', 10, 9, 1, 2, GETDATE(), N'My Dinh Stadium', 1, NULL),
(3, 1, 0, N'A', 3, 7, NULL, NULL, DATEADD(hour, 2, GETDATE()), N'Thong Nhat Stadium', 0, NULL),
-- Round 2
(3, 2, 0, N'A', 10, 3, NULL, NULL, DATEADD(day, 3, GETDATE()), N'My Dinh Stadium', 0, NULL),
(3, 2, 0, N'A', 9, 7, NULL, NULL, DATEADD(day, 3, GETDATE()), N'My Dinh Stadium', 0, NULL);
GO