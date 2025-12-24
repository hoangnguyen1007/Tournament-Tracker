-- CHÚ Ý: Đảm bảo bạn đang chọn đúng Database Cloud trước khi chạy lệnh này!

-- =============================================================
-- PHẦN 1: DỌN DẸP (XÓA BỎ DỮ LIỆU CŨ)
-- =============================================================

DROP PROCEDURE IF EXISTS [dbo].[sp_GetStandings];
DROP PROCEDURE IF EXISTS [dbo].[sp_GenerateGroupStage];

DROP TABLE IF EXISTS [dbo].[Matches];
DROP TABLE IF EXISTS [dbo].[Players];
DROP TABLE IF EXISTS [dbo].[Teams];
DROP TABLE IF EXISTS [dbo].[Tournaments];
DROP TABLE IF EXISTS [dbo].[Account];

GO

-- =============================================================
-- PHẦN 2: TẠO CẤU TRÚC MỚI (SCHEMA)
-- =============================================================

-- 1. Bảng ACCOUNT
CREATE TABLE [dbo].[Account](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [Username] NVARCHAR(50) NOT NULL UNIQUE,
    [PasswordHash] NVARCHAR(255) NOT NULL,
    [CreatedAt] DATETIME DEFAULT GETDATE()
);

-- 2. Bảng TOURNAMENTS
CREATE TABLE [dbo].[Tournaments](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [NAME] NVARCHAR(100) NOT NULL,
    [LOCATION] NVARCHAR(100) NULL,
    [STARTDATE] DATE NULL,
    [PRIZE] NVARCHAR(50) NULL,
    [POSTERPATH] NVARCHAR(255) NULL,
    [SPORT] NVARCHAR(50),   
    [TEAM_COUNT] INT,
    [CreatedBy] INT NULL,
    
    [GroupCount] INT DEFAULT 1, 
    [FormatMode] NVARCHAR(50) DEFAULT 'Single',    
    [Stage1Format] NVARCHAR(50) DEFAULT 'Knockout',
    [Stage2Format] NVARCHAR(50) NULL,              

    FOREIGN KEY (CreatedBy) REFERENCES Account(ID)
);

-- 3. Bảng TEAMS
CREATE TABLE [dbo].[Teams](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [TournamentID] INT NOT NULL,
    [TEAMNAME] NVARCHAR(100) NOT NULL,
    [COACH] NVARCHAR(100) NULL,
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(ID) ON DELETE CASCADE
);

-- 4. Bảng PLAYERS
CREATE TABLE [dbo].[Players](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [IDTEAM] INT NOT NULL,
    [PLAYERNAME] NVARCHAR(100) NOT NULL,
    [POSITION] NVARCHAR(50) NULL, 
    [AGE] INT NULL, -- Đã có cột tuổi
    [NUMBER] INT NULL,
    FOREIGN KEY (IDTEAM) REFERENCES Teams(ID) ON DELETE CASCADE
);

-- 5. Bảng MATCHES
CREATE TABLE [dbo].[Matches](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [TournamentID] INT NOT NULL,
    [Round] INT NOT NULL,          
    [RoundType] INT DEFAULT 0,     -- 0: Vòng bảng, 1: Knockout
    [GroupName] NVARCHAR(10) NULL, 
    
    [HomeTeamID] INT NOT NULL,     
    [AwayTeamID] INT NOT NULL,     
    
    [HomeScore] INT NULL,          
    [AwayScore] INT NULL,
    
    [MatchDate] DATETIME NULL,
    [Location] NVARCHAR(100) NULL,
    [Status] INT DEFAULT 0,        -- 0: Chưa đá, 1: Đang đá, 2: Kết thúc
    [WinnerID] INT NULL,           
    [ParentMatchId] INT NULL,      

    FOREIGN KEY (TournamentID) REFERENCES Tournaments(ID), 
    FOREIGN KEY (HomeTeamID) REFERENCES Teams(ID),
    FOREIGN KEY (AwayTeamID) REFERENCES Teams(ID),
    FOREIGN KEY (WinnerID) REFERENCES Teams(ID),
    FOREIGN KEY (ParentMatchId) REFERENCES Matches(ID)
);
GO

-- =============================================================
-- PHẦN 3: TẠO STORED PROCEDURE
-- =============================================================

-- SP 1: Tính Bảng Xếp Hạng (Đã fix lỗi thiếu TeamID cho bạn)
CREATE PROCEDURE [dbo].[sp_GetStandings]
    @TournamentID INT,
    @GroupName NVARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    WITH TeamStats AS (
        SELECT HomeTeamID AS TeamID, 
               CASE WHEN HomeScore > AwayScore THEN 3 WHEN HomeScore = AwayScore THEN 1 ELSE 0 END AS Points,
               HomeScore AS GF, AwayScore AS GA,
               1 AS Played,
               CASE WHEN HomeScore > AwayScore THEN 1 ELSE 0 END AS Won,
               CASE WHEN HomeScore = AwayScore THEN 1 ELSE 0 END AS Drawn,
               CASE WHEN HomeScore < AwayScore THEN 1 ELSE 0 END AS Lost
        FROM Matches WHERE TournamentID = @TournamentID AND Status = 2 AND (@GroupName IS NULL OR GroupName = @GroupName)
        
        UNION ALL
        
        SELECT AwayTeamID AS TeamID, 
               CASE WHEN AwayScore > HomeScore THEN 3 WHEN AwayScore = HomeScore THEN 1 ELSE 0 END AS Points,
               AwayScore AS GF, HomeScore AS GA,
               1 AS Played,
               CASE WHEN AwayScore > HomeScore THEN 1 ELSE 0 END AS Won,
               CASE WHEN AwayScore = HomeScore THEN 1 ELSE 0 END AS Drawn,
               CASE WHEN AwayScore < HomeScore THEN 1 ELSE 0 END AS Lost
        FROM Matches WHERE TournamentID = @TournamentID AND Status = 2 AND (@GroupName IS NULL OR GroupName = @GroupName)
    )
    SELECT 
        ROW_NUMBER() OVER (ORDER BY SUM(Points) DESC, (SUM(GF)-SUM(GA)) DESC, SUM(GF) DESC) AS Rank,
        t.ID AS TeamID, -- <--- QUAN TRỌNG: Cần cột này để C# không lỗi
        t.TEAMNAME as Name,
        ISNULL(SUM(s.Played), 0) AS Played,
        ISNULL(SUM(s.Won), 0) AS Won,
        ISNULL(SUM(s.Drawn), 0) AS Drawn,
        ISNULL(SUM(s.Lost), 0) AS Lost,
        ISNULL(SUM(s.GF), 0) AS GF,
        ISNULL(SUM(s.GA), 0) AS GA,
        ISNULL(SUM(s.GF) - SUM(s.GA), 0) AS GD,
        ISNULL(SUM(s.Points), 0) AS Points
    FROM Teams t
    LEFT JOIN TeamStats s ON t.ID = s.TeamID
    WHERE t.TournamentID = @TournamentID
    GROUP BY t.ID, t.TEAMNAME
    ORDER BY Points DESC, GD DESC, GF DESC;
END
GO

-- SP 2: Tạo Lịch Đấu Vòng Bảng
CREATE PROCEDURE [dbo].[sp_GenerateGroupStage]
    @TournamentID INT,
    @NumberOfGroups INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Matches WHERE TournamentID = @TournamentID AND RoundType = 0;
    CREATE TABLE #TempGroups (TeamID INT, GroupName NVARCHAR(10));
    INSERT INTO #TempGroups (TeamID, GroupName)
    SELECT ID, CHAR(65 + (ROW_NUMBER() OVER (ORDER BY ID) - 1) % @NumberOfGroups)
    FROM Teams WHERE TournamentID = @TournamentID;
    INSERT INTO Matches (TournamentID, Round, RoundType, GroupName, HomeTeamID, AwayTeamID, Status, MatchDate)
    SELECT @TournamentID, 1, 0, t1.GroupName, t1.TeamID, t2.TeamID, 0, GETDATE()
    FROM #TempGroups t1
    JOIN #TempGroups t2 ON t1.GroupName = t2.GroupName AND t1.TeamID < t2.TeamID;
    DROP TABLE #TempGroups;
END
GO

-- =============================================================
-- PHẦN 4: DỮ LIỆU MẪU (SỬ DỤNG IDENTITY_INSERT ĐỂ AN TOÀN TUYỆT ĐỐI)
-- =============================================================

-- 1. TÀI KHOẢN (ID = 1)
SET IDENTITY_INSERT [dbo].[Account] ON;
INSERT INTO [dbo].[Account] ([ID], [Username], [PasswordHash])
VALUES (1, 'admin', '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92');
SET IDENTITY_INSERT [dbo].[Account] OFF;
GO

-- 2. GIẢI ĐẤU (3 Giải)
SET IDENTITY_INSERT [dbo].[Tournaments] ON;
INSERT INTO [dbo].[Tournaments] ([ID], [NAME], [LOCATION], [STARTDATE], [PRIZE], [SPORT], [TEAM_COUNT], [CreatedBy], [FormatMode], [Stage1Format], [Stage2Format], [GroupCount])
VALUES 
(1, N'Champions Cup 2024', N'Châu Âu', '2025-05-01', N'10,000,000', N'Soccer', 4, 1, 'Multi', 'Group Stage', 'Knockout', 1),
(2, N'V-League Open', N'Việt Nam', '2024-06-15', N'500,000', N'Soccer', 2, 1, 'Single', 'Knockout', NULL, 1),
(3, N'UIT Football Tournament', N'Sân vận động UIT', '2025-01-01', N'2,000,000,000', N'Soccer', 8, 1, 'Multi', 'Group Stage', 'Knockout', 2);
SET IDENTITY_INSERT [dbo].[Tournaments] OFF;
GO

-- 3. ĐỘI BÓNG (14 Đội)
SET IDENTITY_INSERT [dbo].[Teams] ON;
INSERT INTO [dbo].[Teams] ([ID], [TournamentID], [TEAMNAME], [COACH]) VALUES
-- Giải 1
(1, 1, N'Real Madrid', N'Ancelotti'), (2, 1, N'Man City', N'Pep Guardiola'),
(3, 1, N'Bayern Munich', N'Tuchel'), (4, 1, N'Barcelona', N'Xavi'),
-- Giải 2
(5, 2, N'Hanoi FC', N'Iwamasa'), (6, 2, N'Cong An Ha Noi', N'Kiatisuk'),
-- Giải 3 (UIT - 8 Đội)
(7, 3, N'Manchester United', N'Erik ten Hag'), (8, 3, N'Real Madrid CF', N'Carlo Ancelotti'),
(9, 3, N'FC Barcelona', N'Hansi Flick'), (10, 3, N'FC Bayern', N'Vincent Kompany'),
(11, 3, N'Liverpool FC', N'Arne Slot'), (12, 3, N'Paris Saint-Germain', N'Luis Enrique'),
(13, 3, N'Juventus', N'Thiago Motta'), (14, 3, N'Al Nassr', N'Luis Castro');
SET IDENTITY_INSERT [dbo].[Teams] OFF;
GO

-- 4. CẦU THỦ (THÊM HÀNG LOẠT)
-- Không cần IDENTITY_INSERT vì ID cầu thủ tự nhảy là được

-- Cầu thủ Giải 1 & 2 (Mẫu cũ)
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [NUMBER], [AGE]) VALUES
(1, N'Vinicius Jr', N'FW', 7, 24), (1, N'Jude Bellingham', N'MF', 5, 21),
(5, N'Nguyen Van Quyet', N'FW', 10, 33);

-- Cầu thủ Giải 3 (UIT) - 8 Đội x 11 Cầu thủ = 88 người

-- Team 7: Man Utd
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [NUMBER], [AGE]) VALUES
(7, N'Andre Onana', N'GK', 24, 28), (7, N'Diogo Dalot', N'DF', 20, 25), (7, N'Lisandro Martinez', N'DF', 6, 26),
(7, N'Harry Maguire', N'DF', 5, 31), (7, N'Luke Shaw', N'DF', 23, 29), (7, N'Casemiro', N'MF', 18, 32),
(7, N'Kobbie Mainoo', N'MF', 37, 19), (7, N'Bruno Fernandes', N'MF', 8, 30), (7, N'Alejandro Garnacho', N'FW', 17, 20),
(7, N'Marcus Rashford', N'FW', 10, 27), (7, N'Rasmus Hojlund', N'FW', 11, 21);

-- Team 8: Real Madrid CF
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [NUMBER], [AGE]) VALUES
(8, N'Thibaut Courtois', N'GK', 1, 32), (8, N'Dani Carvajal', N'DF', 2, 32), (8, N'Eder Militao', N'DF', 3, 26),
(8, N'Antonio Rudiger', N'DF', 22, 31), (8, N'Ferland Mendy', N'DF', 23, 29), (8, N'Tchouameni', N'MF', 18, 24),
(8, N'Valverde', N'MF', 15, 26), (8, N'Jude Bellingham', N'MF', 5, 21), (8, N'Rodrygo', N'FW', 11, 23),
(8, N'Vinicius Jr', N'FW', 7, 24), (8, N'Kylian Mbappe', N'FW', 9, 25);

-- Team 9: FC Barcelona
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [NUMBER], [AGE]) VALUES
(9, N'Ter Stegen', N'GK', 1, 32), (9, N'Jules Kounde', N'DF', 23, 25), (9, N'Ronald Araujo', N'DF', 4, 25),
(9, N'Pau Cubarsi', N'DF', 33, 17), (9, N'Alejandro Balde', N'DF', 3, 21), (9, N'Frenkie de Jong', N'MF', 21, 27),
(9, N'Pedri', N'MF', 8, 22), (9, N'Gavi', N'MF', 6, 20), (9, N'Lamine Yamal', N'FW', 19, 17),
(9, N'Raphinha', N'FW', 11, 27), (9, N'Lewandowski', N'FW', 9, 36);

-- Team 10: Bayern Munich
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [NUMBER], [AGE]) VALUES
(10, N'Manuel Neuer', N'GK', 1, 38), (10, N'Joshua Kimmich', N'DF', 6, 29), (10, N'Upamecano', N'DF', 2, 26),
(10, N'Kim Min-jae', N'DF', 3, 28), (10, N'Alphonso Davies', N'DF', 19, 24), (10, N'Palhinha', N'MF', 16, 29),
(10, N'Jamal Musiala', N'MF', 42, 21), (10, N'Thomas Muller', N'MF', 25, 35), (10, N'Leroy Sane', N'FW', 10, 28),
(10, N'Serge Gnabry', N'FW', 7, 29), (10, N'Harry Kane', N'FW', 9, 31);

-- Team 11: Liverpool
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [NUMBER], [AGE]) VALUES
(11, N'Alisson Becker', N'GK', 1, 32), (11, N'Trent AA', N'DF', 66, 26), (11, N'Van Dijk', N'DF', 4, 33),
(11, N'Konate', N'DF', 5, 25), (11, N'Robertson', N'DF', 26, 30), (11, N'Mac Allister', N'MF', 10, 25),
(11, N'Szoboszlai', N'MF', 8, 24), (11, N'Gravenberch', N'MF', 38, 22), (11, N'Luis Diaz', N'FW', 7, 27),
(11, N'Mohamed Salah', N'FW', 11, 32), (11, N'Darwin Nunez', N'FW', 9, 25);

-- Team 12: PSG
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [NUMBER], [AGE]) VALUES
(12, N'Donnarumma', N'GK', 99, 25), (12, N'Hakimi', N'DF', 2, 26), (12, N'Marquinhos', N'DF', 5, 30),
(12, N'Skriniar', N'DF', 37, 29), (12, N'Nuno Mendes', N'DF', 25, 22), (12, N'Vitinha', N'MF', 17, 24),
(12, N'Joao Neves', N'MF', 87, 19), (12, N'Fabian Ruiz', N'MF', 8, 28), (12, N'Dembele', N'FW', 10, 27),
(12, N'Barcola', N'FW', 29, 22), (12, N'Goncalo Ramos', N'FW', 9, 23);

-- Team 13: Juventus
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [NUMBER], [AGE]) VALUES
(13, N'Di Gregorio', N'GK', 29, 27), (13, N'Danilo', N'DF', 6, 33), (13, N'Bremer', N'DF', 3, 27),
(13, N'Gatti', N'DF', 4, 26), (13, N'Cambiaso', N'DF', 27, 24), (13, N'Locatelli', N'MF', 5, 26),
(13, N'Douglas Luiz', N'MF', 26, 26), (13, N'Koopmeiners', N'MF', 8, 26), (13, N'Yildiz', N'FW', 10, 19),
(13, N'Conceicao', N'FW', 7, 21), (13, N'Vlahovic', N'FW', 9, 24);

-- Team 14: Al Nassr
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [NUMBER], [AGE]) VALUES
(14, N'Bento', N'GK', 24, 25), (14, N'Sultan', N'DF', 2, 30), (14, N'Laporte', N'DF', 27, 30),
(14, N'Simakan', N'DF', 3, 24), (14, N'Alex Telles', N'DF', 15, 31), (14, N'Brozovic', N'MF', 77, 31),
(14, N'Otavio', N'MF', 25, 29), (14, N'Talisca', N'MF', 94, 30), (14, N'Mane', N'FW', 10, 32),
(14, N'Ghareeb', N'FW', 29, 27), (14, N'Cristiano Ronaldo', N'FW', 7, 39);

GO

-- 5. MATCHES (Lịch thi đấu mẫu cho Giải 1 và 2)
INSERT INTO [dbo].[Matches] ([TournamentID], [Round], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Status], [GroupName])
VALUES (1, 1, 1, 2, 3, 3, GETDATE(), 2, 'A'), (1, 1, 3, 4, NULL, NULL, GETDATE(), 0, 'A');
INSERT INTO [dbo].[Matches] ([TournamentID], [Round], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Status])
VALUES (2, 1, 5, 6, 2, 0, GETDATE(), 2);

-- Fix lại ID tự tăng cho các lần nhập sau
DBCC CHECKIDENT ('Account', RESEED);
DBCC CHECKIDENT ('Tournaments', RESEED);
DBCC CHECKIDENT ('Teams', RESEED);
DBCC CHECKIDENT ('Players', RESEED);
DBCC CHECKIDENT ('Matches', RESEED);
GO