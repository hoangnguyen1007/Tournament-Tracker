-- 1. Sử dụng đúng Database
USE [TournamentTracker];
GO

-- 2. Tạo bảng Teams (Đội bóng)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Teams]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Teams](
        [ID] [int] IDENTITY(1,1) NOT NULL,
        [TEAMNAME] [nvarchar](100) NOT NULL,
        [COACH] [nvarchar](100) NULL,
        [LOGOPATH] [nvarchar](255) NULL,
        PRIMARY KEY CLUSTERED ([ID] ASC)
    );
    PRINT 'Da tao bang Teams.';
END
GO

-- 3. Tạo bảng Players (Cầu thủ)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Players]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Players](
        [ID] [int] IDENTITY(1,1) NOT NULL,
        [PLAYERNAME] [char](36) NULL,
        [POSITION] [char](3) NULL,
        [AGE] [int] NULL,
        [IDTEAM] [int] NULL,
        PRIMARY KEY CLUSTERED ([ID] ASC)
    );
    
    -- Tạo khóa ngoại liên kết Player với Team
    ALTER TABLE [dbo].[Players] WITH CHECK ADD CONSTRAINT [FK_Players_Teams] FOREIGN KEY([IDTEAM])
    REFERENCES [dbo].[Teams] ([ID]);
    
    PRINT 'Da tao bang Players.';
END
GO

-- 4. Tạo bảng Matches (Lịch thi đấu) - Cái này cần cho tính năng bạn vừa làm
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matches]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Matches](
        [ID] [int] IDENTITY(1,1) NOT NULL,
        [Round] [int] NOT NULL,
        [HomeTeamID] [int] NOT NULL,
        [AwayTeamID] [int] NOT NULL,
        [HomeScore] [int] NULL,
        [AwayScore] [int] NULL,
        PRIMARY KEY CLUSTERED ([ID] ASC)
    );
    PRINT 'Da tao bang Matches.';
END
GO
USE [TournamentTracker];
GO

-- Kiểm tra xem bảng có chưa, chưa có thì mới tạo
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
