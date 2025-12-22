-- CHÚ Ý: Đảm bảo bạn đang chọn đúng Database Cloud trước khi chạy lệnh này!

-- =============================================================
-- PHẦN 1: DỌN DẸP (XÓA BỎ DỮ LIỆU CŨ)
-- =============================================================

-- 1. Xóa Stored Procedures nếu tồn tại
DROP PROCEDURE IF EXISTS [dbo].[sp_GetStandings];
DROP PROCEDURE IF EXISTS [dbo].[sp_GenerateGroupStage];

-- 2. Xóa các Bảng (Theo thứ tự ngược lại của quan hệ khóa ngoại)
-- Phải xóa bảng con trước, bảng cha sau để không lỗi
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
    
    -- Cột mới logic
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
    [AGE] INT NULL,
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
-- PHẦN 3: TẠO STORED PROCEDURE (QUAN TRỌNG)
-- =============================================================

-- SP 1: Tính Bảng Xếp Hạng
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
    SELECT 
        @TournamentID, 1, 0, t1.GroupName, t1.TeamID, t2.TeamID, 0, GETDATE()
    FROM #TempGroups t1
    JOIN #TempGroups t2 ON t1.GroupName = t2.GroupName AND t1.TeamID < t2.TeamID;

    DROP TABLE #TempGroups;
END
GO

-- =============================================================
-- PHẦN 4: DỮ LIỆU MẪU (SEED DATA)
-- =============================================================

-- 1. Admin (Lưu ý: Chạy lệnh này xong thì Pass của user admin sẽ là 123456)
INSERT INTO [dbo].[Account] ([Username], [PasswordHash])
VALUES ('admin', '8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92');

-- 2. Giải Đấu Mẫu
INSERT INTO [dbo].[Tournaments] 
([NAME], [LOCATION], [STARTDATE], [PRIZE], [SPORT], [TEAM_COUNT], [CreatedBy], [FormatMode], [Stage1Format], [Stage2Format], [GroupCount])
VALUES 
(N'Champions Cup 2024', N'Châu Âu', '2025-05-01', N'10,000,000', N'Soccer', 4, 1, 'Multi', 'Group Stage', 'Knockout', 1),
(N'V-League Open', N'Việt Nam', '2024-06-15', N'500,000', N'Soccer', 2, 1, 'Single', 'Knockout', NULL, 1);

-- 3. Đội Bóng
INSERT INTO [dbo].[Teams] ([TournamentID], [TEAMNAME], [COACH]) VALUES
(1, N'Real Madrid', N'Ancelotti'), (1, N'Man City', N'Pep Guardiola'),
(1, N'Bayern Munich', N'Tuchel'), (1, N'Barcelona', N'Xavi'),
(2, N'Hanoi FC', N'Iwamasa'), (2, N'Cong An Ha Noi', N'Kiatisuk');

-- 4. Cầu Thủ
INSERT INTO [dbo].[Players] ([IDTEAM], [PLAYERNAME], [POSITION], [NUMBER]) VALUES
(1, N'Vinicius Jr', N'FW', 7), (1, N'Jude Bellingham', N'MF', 5), (5, N'Nguyen Van Quyet', N'FW', 10);

-- 5. Trận Đấu Mẫu
INSERT INTO [dbo].[Matches] ([TournamentID], [Round], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Status], [GroupName])
VALUES (1, 1, 1, 2, 3, 3, GETDATE(), 2, 'A'), (1, 1, 3, 4, NULL, NULL, GETDATE(), 0, 'A');
INSERT INTO [dbo].[Matches] ([TournamentID], [Round], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Status])
VALUES (2, 1, 5, 6, 2, 0, GETDATE(), 2);

GO