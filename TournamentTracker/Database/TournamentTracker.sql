-- 1. TẠO DATABASE
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TournamentTracker')
BEGIN
    CREATE DATABASE [TournamentTracker];
END
GO

USE [TournamentTracker];
GO

-- =============================================
-- PHẦN 1: (ACCOUNT, TEAMS, PLAYERS)
-- =============================================

-- 2. Bảng ACCOUNT
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Account](
        [ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[CreatedAt] [datetime] NULL,
        PRIMARY KEY CLUSTERED ([ID] ASC)
        );
    END
GO

-- ================================================
-- 3. Bảng Teams 
IF OBJECT_ID('[dbo].[Teams]', 'U') IS NULL
CREATE TABLE [dbo].[Teams](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [TEAMNAME] NVARCHAR(100) NOT NULL,
    [COACH] NVARCHAR(100) NULL,
);
GO

-- 4. Bảng Players 
IF OBJECT_ID('[dbo].[Players]', 'U') IS NULL
CREATE TABLE [dbo].[Players](
    [ID] INT IDENTITY(1,1) PRIMARY KEY,
    [IDTEAM] INT NOT NULL,
    [PLAYERNAME] NVARCHAR(100) NOT NULL,
    [POSITION] NVARCHAR(50) NULL, -- GK, DF, MF, FW
    [AGE] INT NULL,
    [NUMBER] INT NULL, -- Số áo đấu
);
GO

ALTER TABLE Players 
ADD CONSTRAINT FK_Players_Teams 
FOREIGN KEY (IDTEAM) REFERENCES Teams(ID);
-- =============================================
-- PHẦN 2: TỔ CHỨC GIẢI ĐẤU (TOURNAMENT & ENTRIES)
-- =============================================

-- 5. Bảng Tournaments (Quản lý thông tin giải đấu)
--IF OBJECT_ID('[dbo].[Tournaments]', 'U') IS NULL
--CREATE TABLE [dbo].[Tournaments](
    IF NOT EXISTS (SELECT * FROM sys.objects 
               WHERE object_id = OBJECT_ID(N'[dbo].[Tournaments]') 
               AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Tournaments](
        [ID] INT IDENTITY(1,1) PRIMARY KEY,
        [NAME] NVARCHAR(100) NOT NULL,
        [LOCATION] NVARCHAR(100) NULL,
        [STARTDATE] DATE NULL,
        [PRIZE] NVARCHAR(50) NULL,
        [POSTERPATH] NVARCHAR(255) NULL  ,
        [SPORT] NVARCHAR(50),   
        [TEAM_COUNT] int
    );
    PRINT 'Created table Tournaments.';
END
GO
-- 6. Bảng TournamentEntries (Đăng ký Đội vào Giải)
-- Bảng này quan trọng: Giúp 1 đội có thể tham gia nhiều giải khác nhau
--IF OBJECT_ID('[dbo].[TournamentEntries]', 'U') IS NULL
--CREATE TABLE [dbo].[TournamentEntries](
    

--);
--GO

-- =============================================
-- PHẦN 3: TRẬN ĐẤU & SỰ KIỆN (CORE FEATURE)
-- =============================================

-- 7. Bảng Matches (Bảng TỔNG HỢP - Quan trọng nhất)
-- Chứa cả Lịch thi đấu và Kết quả
IF OBJECT_ID('[dbo].[Matches]', 'U') IS NULL
CREATE TABLE [dbo].[Matches](
    
    -- THÔNG TIN ĐỐI ĐẦU
    [ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Round] [int] NOT NULL,-- Đây chính là RoundNumber (Vòng 1, 2...).
    [HomeTeamID] [int] NOT NULL,
    [AwayTeamID] [int] NOT NULL,
    [HomeScore] [int] NULL,
    [AwayScore] [int] NULL,

    -- LỊCH THI ĐẤU
    [MatchDate] DATETIME NULL,      -- Ngày giờ đá
    [Location] NVARCHAR(100) NULL,  -- Sân vận động
    [Status] INT DEFAULT 0,         -- 0: Chưa đá (Scheduled), 1: Đang đá, 2: Kết thúc

    -- KẾT QUẢ
    [WinnerID] INT NULL,

    -- CẤU HÌNH CHO THUẬT TOÁN XẾP LỊCH
    [RoundNumber] INT NOT NULL, -- Vòng 1, Vòng 2, Tứ kết (đánh số 1,2,3...)
    [RoundType] INT NOT NULL,   -- 0: Vòng Bảng (tính điểm), 1: Knockout (loại trực tiếp)
    [GroupName] NVARCHAR(10) NULL, -- Ví dụ: 'A', 'B'. Dùng để lọc Bảng xếp hạng.
    
    -- CẤU HÌNH CHO CÂY KNOCKOUT (Nâng cao)
    [ParentMatchId] INT NULL, -- ID của trận kế tiếp mà đội thắng sẽ lọt vào
    
);
GO

-- 8. Bảng MatchEvents (Sự kiện trận đấu - Để tính Vua phá lưới)
    --IF OBJECT_ID('[dbo].[MatchEvents]', 'U') IS NULL
    --CREATE TABLE [dbo].[MatchEvents](


    --);
    --GO











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

-- ---------------------------------------------------------
-- KỊCH BẢN 1: CHAMPIONS CUP (Đấu loại trực tiếp - Knockout)
-- ---------------------------------------------------------

-- VÒNG 1 (Tứ Kết) - Đã đá xong (Status = 2)
INSERT INTO [dbo].[Matches] 
([Round], [RoundNumber], [RoundType], [GroupName], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Location], [Status], [WinnerID]) 
VALUES
-- Trận 1: Real Madrid (1) vs Man City (2) -> Real thắng 3-1
(1, 1, 1, NULL, 1, 2, 3, 1, '2024-05-01 20:00:00', N'Santiago Bernabéu', 2, 1),

-- Trận 2: Bayern Munich (6) vs Barcelona (7) -> Hòa 2-2, Bayern thắng Pen (giả định set WinnerID=6)
(1, 1, 1, NULL, 6, 7, 2, 2, '2024-05-02 20:00:00', N'Allianz Arena', 2, 6),

-- Trận 3: PSG (8) vs Arsenal (4) -> Arsenal thắng 1-2
(1, 1, 1, NULL, 8, 4, 1, 2, '2024-05-03 20:00:00', N'Parc des Princes', 2, 4),

-- Trận 4: Liverpool (5) vs Man Utd (3) -> Liverpool thắng 4-0
(1, 1, 1, NULL, 5, 3, 4, 0, '2024-05-04 20:00:00', N'Anfield', 2, 5);

-- VÒNG 2 (Bán Kết) - Sắp đá (Status = 0, chưa có tỷ số)
-- Người thắng Trận 1 (Real) vs Người thắng Trận 2 (Bayern)
-- Người thắng Trận 3 (Arsenal) vs Người thắng Trận 4 (Liverpool)
INSERT INTO [dbo].[Matches] 
([Round], [RoundNumber], [RoundType], [GroupName], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Location], [Status], [WinnerID]) 
VALUES
(2, 2, 1, NULL, 1, 6, NULL, NULL, '2024-05-15 20:00:00', N'Wembley Stadium', 0, NULL),
(2, 2, 1, NULL, 4, 5, NULL, NULL, '2024-05-16 20:00:00', N'Wembley Stadium', 0, NULL);

-- ---------------------------------------------------------
-- KỊCH BẢN 2: FRIENDLY ASIA TOUR (Vòng bảng - Round Robin)
-- ---------------------------------------------------------
-- Gồm: Hanoi FC (10), Chelsea (9), Man Utd (3), Barca (7)

-- Lượt trận 1: Đang đá (Status = 1)
INSERT INTO [dbo].[Matches] 
([Round], [RoundNumber], [RoundType], [GroupName], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Location], [Status], [WinnerID]) 
VALUES
-- Hanoi FC vs Chelsea (Đang đá phút 70, tỷ số tạm thời 1-2)
(1, 1, 0, N'A', 10, 9, 1, 2, GETDATE(), N'My Dinh Stadium', 1, NULL),

-- Man Utd vs Barca (Sắp đá hôm nay)
(1, 1, 0, N'A', 3, 7, NULL, NULL, DATEADD(hour, 2, GETDATE()), N'Thong Nhat Stadium', 0, NULL);

-- Lượt trận 2: Tương lai
INSERT INTO [dbo].[Matches] 
([Round], [RoundNumber], [RoundType], [GroupName], [HomeTeamID], [AwayTeamID], [HomeScore], [AwayScore], [MatchDate], [Location], [Status], [WinnerID]) 
VALUES
-- Hanoi FC vs Man Utd
(2, 2, 0, N'A', 10, 3, NULL, NULL, DATEADD(day, 3, GETDATE()), N'My Dinh Stadium', 0, NULL),
-- Chelsea vs Barca
(2, 2, 0, N'A', 9, 7, NULL, NULL, DATEADD(day, 3, GETDATE()), N'My Dinh Stadium', 0, NULL);

