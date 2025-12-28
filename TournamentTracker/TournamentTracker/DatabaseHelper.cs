using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;


namespace TeamListForm
{
    public class TeamCountInfo
    {
        public int CurrentCount { get; set; } 
        public int MaxCount { get; set; }   
    }
    internal class DatabaseHelper
    {
        private static string connectionString = @"Data Source=SQL9001.site4now.net;Initial Catalog=db_ac29fc_tournamenttracker;User Id=db_ac29fc_tournamenttracker_admin;Password=Nn3832143";
        // TEAMS
        public static List<Team> GetTeams(int tournamentId, string search = "")
        {
            var teams = new List<Team>();

            string sql = "SELECT ID, TEAMNAME, COACH, TournamentID FROM Teams WHERE TournamentID = @tID";

            if (!string.IsNullOrWhiteSpace(search)) sql += " AND TEAMNAME LIKE @search";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@tID", tournamentId); // <--- QUAN TRỌNG
                if (!string.IsNullOrWhiteSpace(search)) cmd.Parameters.AddWithValue("@search", $"%{search}%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        teams.Add(new Team
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            TournamentID = reader.GetInt32(reader.GetOrdinal("TournamentID")),
                            TEAMNAME = reader.GetString(reader.GetOrdinal("TEAMNAME")),
                            COACH = reader.IsDBNull(reader.GetOrdinal("COACH")) ? "" : reader.GetString(reader.GetOrdinal("COACH"))
                        });
                    }
                }
            }
            return teams;
        }
        public static void InsertTeam(Team team)
        {
            string sql = "INSERT INTO Teams (TournamentID, TEAMNAME, COACH) VALUES (@TourID, @Name, @Coach)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TourID", team.TournamentID);
                cmd.Parameters.AddWithValue("@Name", team.TEAMNAME);
                cmd.Parameters.AddWithValue("@Coach", string.IsNullOrWhiteSpace(team.COACH) ? (object)DBNull.Value : team.COACH);

                conn.Open();
                cmd.ExecuteScalar();
            }
        }
        public static int InsertTeamAndGetID(Team team)
        {
            string sql = @"INSERT INTO Teams (TournamentID, TEAMNAME, COACH) 
                   OUTPUT INSERTED.ID 
                   VALUES (@TourID, @Name, @Coach)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TourID", team.TournamentID);
                cmd.Parameters.AddWithValue("@Name", team.TEAMNAME);
                cmd.Parameters.AddWithValue("@Coach", string.IsNullOrWhiteSpace(team.COACH) ? (object)DBNull.Value : team.COACH);

                conn.Open();
                int newId = (int)cmd.ExecuteScalar();
                return newId;
            }
        }
        public TeamCountInfo GetTeamCountInfo(int tournamentId)
        {
            TeamCountInfo info = new TeamCountInfo();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlMax = "SELECT TEAM_COUNT FROM Tournaments WHERE ID = @id";
                using (SqlCommand cmd = new SqlCommand(sqlMax, conn))
                {
                    cmd.Parameters.AddWithValue("@id", tournamentId);
                    object result = cmd.ExecuteScalar();
                    info.MaxCount = (result != null) ? Convert.ToInt32(result) : 0;
                }


                string sqlCount = "SELECT COUNT(*) FROM Teams WHERE TournamentID = @id";
                using (SqlCommand cmd = new SqlCommand(sqlCount, conn))
                {
                    cmd.Parameters.AddWithValue("@id", tournamentId);
                    info.CurrentCount = (int)cmd.ExecuteScalar();
                }
            }
            return info;
        }
        public static bool CheckTeam(string teamName, int tournamentId)
        {
            string query = "SELECT COUNT(*) FROM Teams WHERE TEAMNAME=@TN AND TournamentID=@tID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TN", teamName);
                cmd.Parameters.AddWithValue("@tID", tournamentId); // <--- QUAN TRỌNG

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count == 0; 
            }
        }
        public DataRow GetTournamentById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM Tournaments WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0) return dt.Rows[0];
                    return null;
                }
                catch
                {
                    return null;
                }
            }
        }

        // 2. Cập nhật giải đấu
        public bool UpdateTournament(int id, string name, string location, DateTime date, string prize, string posterPath, string sport, int teamCount, int groupCount)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = @"UPDATE Tournaments 
                                   SET NAME = @Name, 
                                       LOCATION = @Location, 
                                       STARTDATE = @Date, 
                                       PRIZE = @Prize, 
                                       POSTERPATH = @Poster,
                                       SPORT = @Sport, 
                                       TEAM_COUNT = @TeamCount,
                                       GroupCount = @GroupCount
                                   WHERE ID = @ID";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Location", string.IsNullOrEmpty(location) ? (object)DBNull.Value : location);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Prize", string.IsNullOrEmpty(prize) ? (object)DBNull.Value : prize);
                    cmd.Parameters.AddWithValue("@Poster", string.IsNullOrEmpty(posterPath) ? (object)DBNull.Value : posterPath);
                    cmd.Parameters.AddWithValue("@Sport", string.IsNullOrEmpty(sport) ? (object)DBNull.Value : sport);
                    cmd.Parameters.AddWithValue("@TeamCount", teamCount);
                    cmd.Parameters.AddWithValue("@GroupCount", groupCount);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật giải: " + ex.Message);
                    return false;
                }
            }
        }
        public static void UpdateTeam(Team team)
        {
            string sql = "UPDATE Teams SET TEAMNAME = @Name, COACH = @Coach WHERE ID = @ID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", team.ID);
                cmd.Parameters.AddWithValue("@Name", team.TEAMNAME);
                cmd.Parameters.AddWithValue("@Coach", string.IsNullOrWhiteSpace(team.COACH) ? (object)DBNull.Value : team.COACH);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteTeam(int id)
        {
            string sql = "DELETE FROM Teams WHERE ID = @ID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                 cmd.ExecuteNonQuery();
            }
        }
        public static bool IsRoundComplete(int tournamentId, int round)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM Matches WHERE TournamentID = @tId AND Round = @r AND Status <> 2";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tId", tournamentId);
                    cmd.Parameters.AddWithValue("@r", round);

                    int unfinishedMatches = (int)cmd.ExecuteScalar();
                    return unfinishedMatches == 0;
                }
            }
        }
        // PLAYERS
        public static List<Player> GetPlayersByTeam(int teamId, string search = "")
        {
            var players = new List<Player>();
            string sql = @"
            SELECT p.ID, p.PLAYERNAME, p.POSITION, p.AGE, p.IDTEAM, p.NUMBER, t.TEAMNAME
            FROM Players p
            LEFT JOIN Teams t ON p.IDTEAM = t.ID
            WHERE p.IDTEAM = @TeamID
            AND (@Search = '' OR p.PLAYERNAME LIKE '%' + @Search + '%')";
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TeamID", teamId);
                cmd.Parameters.AddWithValue("@Search", search);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        players.Add(new Player
                        {
                            ID = reader.GetInt32("ID"),

                            PlayerName = reader["PLAYERNAME"]?.ToString().Trim() ?? "",
                            Position = reader["POSITION"]?.ToString().Trim() ?? "",
                            Age = reader.IsDBNull("AGE") ? 0 : reader.GetInt32("AGE"),
                            TeamID = reader.IsDBNull("IDTEAM") ? (int?)null : reader.GetInt32("IDTEAM"),
                            Number = reader["Number"] != DBNull.Value ? (int)reader["Number"] : 0
                        });
                    }
                }
            }
            return players;
        }
        // PLAYERS CRUD FUNCTION
        public static void InsertPlayer(Player player)
        {
            string sql = "INSERT INTO Players (PlayerName, Age, Position, IDTEAM) VALUES (@Name, @Age, @Pos, @TeamID)";
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Name", player.PlayerName);
            cmd.Parameters.AddWithValue("@Age", player.Age);
            cmd.Parameters.AddWithValue("@Pos", player.Position);
            cmd.Parameters.AddWithValue("@TeamID", player.TeamID);
            cmd.Parameters.AddWithValue("@Number", player.Number);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        public static void UpdatePlayer(Player player)
        {
            string sql = "UPDATE Players SET PlayerName = @Name, Age = @Age, Position = @Pos WHERE ID = @ID";
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Name", player.PlayerName);
            cmd.Parameters.AddWithValue("@Age", player.Age);
            cmd.Parameters.AddWithValue("@Pos", player.Position);
            cmd.Parameters.AddWithValue("@ID", player.ID);
            cmd.Parameters.AddWithValue("@Number", player.Number);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void DeletePlayer(Player player)
        {
            if (player == null || string.IsNullOrWhiteSpace(player.PlayerName))
                return;

            string sql = "DELETE FROM Players WHERE PLAYERNAME = @PlayerName";

            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@PlayerName", player.PlayerName.Trim());

            conn.Open();
            cmd.ExecuteNonQuery();
        }
        // ACCOUNT
        public bool Register(string username, string password)
        {
            string hashedPassword;
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                hashedPassword = BitConverter.ToString(bytes).Replace("-", "");
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM dbo.Account WHERE Username=@username", conn))
                    {
                        check.Parameters.AddWithValue("@username", username);
                        int exists = (int)check.ExecuteScalar();
                        if (exists > 0)
                        {
                            return false;
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO dbo.Account (Username, PasswordHash) VALUES (@username, @password)", conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
                return false;
            }
        }

        public bool Login(string username, string password)
        {
            string hashedPassword;
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                hashedPassword = BitConverter.ToString(bytes).Replace("-", "");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Account WHERE Username=@username AND PasswordHash=@password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                int match = (int)cmd.ExecuteScalar();
                return match > 0; 
            }
        }
        public int GetUserId(string username)
        {
            int userId = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID FROM Account WHERE Username = @u";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@u", username);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
                catch { }
            }
            return userId;
        }
        //Tournaments database
        public int AddTournament(string name, string location, DateTime date, string prize, string posterPath, string sport, int teamCount, int groupCount, int createdBy)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = @"INSERT INTO Tournaments 
                                   (NAME, LOCATION, STARTDATE, PRIZE, POSTERPATH, SPORT, TEAM_COUNT, GroupCount, CreatedBy) 
                                   OUTPUT INSERTED.ID
                                   VALUES 
                                   (@Name, @Location, @Date, @Prize, @Poster, @Sport, @TeamCount, @GroupCount, @CreatedBy)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Location", string.IsNullOrEmpty(location) ? (object)DBNull.Value : location);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Prize", string.IsNullOrEmpty(prize) ? (object)DBNull.Value : prize);
                    cmd.Parameters.AddWithValue("@Poster", string.IsNullOrEmpty(posterPath) ? (object)DBNull.Value : posterPath);
                    cmd.Parameters.AddWithValue("@Sport", string.IsNullOrEmpty(sport) ? (object)DBNull.Value : sport);
                    cmd.Parameters.AddWithValue("@TeamCount", teamCount);
                    cmd.Parameters.AddWithValue("@GroupCount", groupCount);
                    cmd.Parameters.AddWithValue("@CreatedBy", createdBy);
                    return (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm giải: " + ex.Message);
                    return -1;
                }
            }
        }
        // 1. Lấy giải đấu do User hiện tại tạo (MY TOURNAMENTS)
        public DataTable GetMyTournaments(int userId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Tournaments WHERE CreatedBy = @uid ORDER BY ID DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@uid", userId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        // 2. Lấy giải đấu của người khác (FIND / EXPLORE)
         public DataTable GetOtherTournaments(int currentUserId, string keyword = "")
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT * FROM Tournaments 
                         WHERE (@key = '' OR NAME LIKE N'%' + @key + '%') 
                         ORDER BY ID DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@key", keyword);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
        public DataTable GetAllTournaments()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Tournaments ORDER BY ID DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                }
            }
            return dt;
        }
        public bool DeleteTournament(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Tournaments WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception)
                {
                    return false; 
                }
            }
        }
        public DataRow GetHeroTournament(int userId, bool isMyTournamentMode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "";

                if (isMyTournamentMode)
                {
                    sql = @"SELECT TOP 1 * FROM Tournaments 
                    WHERE CreatedBy = @uid AND STARTDATE >= CAST(GETDATE() AS DATE)
                    ORDER BY STARTDATE ASC";
                }
                else
                {
                    sql = @"SELECT TOP 1 * FROM Tournaments 
                    WHERE (CreatedBy <> @uid OR CreatedBy IS NULL) 
                    AND STARTDATE >= CAST(GETDATE() AS DATE)
                    ORDER BY STARTDATE ASC";
                }
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0) return dt.Rows[0];
                    return null;
                }
            }
        }

        public DataRow GetTournamentStats(int userId, bool isMyTournamentMode)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string whereClause = "";

                if (isMyTournamentMode)
                {
                    whereClause = "WHERE CreatedBy = @uid";
                }
                else
                {
                    whereClause = "";
                }

                string query = $@"
            SELECT
                COUNT(ID) AS TotalTournaments,
                SUM(CASE WHEN STARTDATE > GETDATE() THEN 1 ELSE 0 END) AS UpcomingTournaments,
                SUM(CASE WHEN STARTDATE <= GETDATE() THEN 1 ELSE 0 END) AS StartedOrFinishedTournaments
            FROM Tournaments
            {whereClause}";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (isMyTournamentMode)
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public DataTable GetTournamentsByFilter(int userId, string filterMode)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM Tournaments WHERE 1=1 ";
                switch (filterMode)
                {
                    case "Active":
                        sql += " AND STARTDATE <= CAST(GETDATE() AS DATE)";
                        break;
                    case "Upcoming":
                        sql += " AND STARTDATE > CAST(GETDATE() AS DATE)";
                        break;
                    case "HighPrize":
                        sql += " ORDER BY PRIZE DESC";
                        break;
                    case "Recently":
                        sql += " ORDER BY ID DESC";
                        break;
                    case "All":
                    default:
                        sql += " ORDER BY STARTDATE ASC";
                        break;
                }

                if (!sql.Contains("ORDER BY")) sql += " ORDER BY STARTDATE ASC";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        // TOURNAMENTS & MATCHES
        //MATCHES
        public static List<string> GetRounds(int tournamentId)
        {
            var rounds = new List<string>();
            string sql = "SELECT DISTINCT Round FROM Matches WHERE TournamentID = @tId ORDER BY Round";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@tId", tournamentId); 
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rounds.Add("Round " + reader.GetInt32(0).ToString());
                    }
                }
            }
            return rounds;
        }
        // Lấy danh sách trận đấu (Có hỗ trợ lọc theo vòng)
        public static DataTable GetMatchesTable(int tournamentId, int round, string groupName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                SELECT 
                    M.ID as MatchID,
                    M.Round,
                    M.GroupName,
                    M.Status,
                    M.HomeScore,
                    M.AwayScore,
                    M.HomeTeamID,
                    M.AwayTeamID,
                    M.MatchDate,
        
                    -- [QUAN TRỌNG] Lấy địa điểm từ bảng Tournaments (viết tắt là T)
                    -- Dùng ISNULL để nếu bảng Tournaments không có thì trả về chuỗi rỗng
                    ISNULL(T.LOCATION, '') as Location,

                    T1.TEAMNAME as HomeTeamName, 
                    T2.TEAMNAME as AwayTeamName,
                    CASE
                        -- Nếu đã kết thúc hoặc ĐÃ CÓ ĐIỂM SỐ thì hiện tỷ số
                        WHEN M.Status = 2 OR (M.HomeScore IS NOT NULL AND M.AwayScore IS NOT NULL) 
                        THEN CAST(M.HomeScore AS NVARCHAR) + ' - ' + CAST(M.AwayScore AS NVARCHAR)
                    ELSE 'vs'
                    END as ScoreDisplay
                FROM Matches M
                LEFT JOIN Teams T1 ON M.HomeTeamID = T1.ID
                LEFT JOIN Teams T2 ON M.AwayTeamID = T2.ID
    
                -- [BẮT BUỘC] JOIN Bảng Giải Đấu để lấy địa điểm
                INNER JOIN Tournaments T ON M.TournamentID = T.ID

                WHERE M.TournamentID = @tId AND M.Round = @r";

                bool hasGroupFilter = !string.IsNullOrEmpty(groupName)
                                      && groupName != "All"
                                      && groupName != "Tất cả các bảng";

                if (hasGroupFilter)
                    sql += " AND M.GroupName = @gName";

                sql += " ORDER BY M.GroupName, M.MatchDate";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tId", tournamentId);
                    cmd.Parameters.AddWithValue("@r", round);

                    if (hasGroupFilter)
                    {
                        cmd.Parameters.AddWithValue("@gName", groupName);
                    }

                    DataTable dt = new DataTable();
                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                    return dt;
                }
            }
        }

        // Cập nhật kết quả trận đấu
        public static void UpdateMatchResult(int matchId, int homeScore, int awayScore, bool isFinished)
        {
            int status = isFinished ? 2 : 0;

            object winnerId = DBNull.Value;
            int homeTeamId = 0, awayTeamId = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (isFinished)
                {
                    string getTeamsSql = "SELECT HomeTeamID, AwayTeamID FROM Matches WHERE ID = @id";
                    using (SqlCommand cmd = new SqlCommand(getTeamsSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", matchId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                homeTeamId = reader.GetInt32(0);
                                awayTeamId = reader.GetInt32(1);
                            }
                        }
                    }
                    if (homeScore > awayScore) winnerId = homeTeamId;
                    else if (awayScore > homeScore) winnerId = awayTeamId;
                }

                string updateSql = "UPDATE Matches SET HomeScore=@h, AwayScore=@a, Status=@stat, WinnerID=@win WHERE ID=@id";

                using (SqlCommand cmd = new SqlCommand(updateSql, conn))
                {
                    cmd.Parameters.AddWithValue("@h", homeScore);
                    cmd.Parameters.AddWithValue("@a", awayScore);
                    cmd.Parameters.AddWithValue("@stat", status);
                    cmd.Parameters.AddWithValue("@win", winnerId);
                    cmd.Parameters.AddWithValue("@id", matchId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static List<Team> GetTeamsByTournament(int tournamentId)
        {
            List<Team> list = new List<Team>();
            string sql = "SELECT * FROM Teams WHERE TournamentID = @tID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@tID", tournamentId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Team t = new Team();
                        t.ID = (int)reader["ID"];
                        t.TEAMNAME = reader["TEAMNAME"].ToString();
                        t.COACH = reader["COACH"] != DBNull.Value ? reader["COACH"].ToString() : "";

                        list.Add(t);
                    }
                }
            }
            return list;
        }
        // Thêm trận đấu mới
        public static void InsertMatch(int tournamentId, int round, int roundType, int homeTeamId, int awayTeamId, string groupName = null)
        {
            // Status = 0 (Chưa đá)
            string sql = @"INSERT INTO Matches 
                   (TournamentID, Round, RoundType, GroupName, HomeTeamID, AwayTeamID, Status, MatchDate) 
                   VALUES 
                   (@tId, @round, @rType, @gName, @hId, @aId, 0, GETDATE())";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@tId", tournamentId);
                cmd.Parameters.AddWithValue("@round", round);
                cmd.Parameters.AddWithValue("@rType", roundType);
                cmd.Parameters.AddWithValue("@hId", homeTeamId);
                cmd.Parameters.AddWithValue("@aId", awayTeamId);
                cmd.Parameters.AddWithValue("@gName", string.IsNullOrEmpty(groupName) ? (object)DBNull.Value : groupName);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        // Hàm lấy Bảng Xếp Hạng (Dùng cho Round 1, Vòng bảng)
        public static DataTable GetStandings(int tournamentId, string groupName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetStandings", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TournamentID", tournamentId);
                if (string.IsNullOrEmpty(groupName) || groupName == "All")
                    cmd.Parameters.AddWithValue("@GroupName", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@GroupName", groupName);
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    // Không làm gì cả, trả về bảng rỗng
                }
                return dt;
            }
        }
        // Hàm lấy danh sách người thắng (Dùng cho Round 2 trở đi, Vòng knockout)
        public static List<int> GetWinnersFromRound(int tournamentId, int round)
        {
            List<int> ids = new List<int>();
            string sql = "SELECT WinnerID FROM Matches WHERE TournamentID=@tId AND Round=@r AND WinnerID IS NOT NULL";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@tId", tournamentId);
                cmd.Parameters.AddWithValue("@r", round);
                conn.Open();
                using (SqlDataReader r = cmd.ExecuteReader()) { while (r.Read()) ids.Add(r.GetInt32(0)); }
            }
            return ids;
        }
        // Hàm lấy vòng đấu lớn nhất hiện tại
        public static int GetMaxRound(int tournamentId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(Round), 0) FROM Matches WHERE TournamentID=@tId", conn);
                cmd.Parameters.AddWithValue("@tId", tournamentId);
                return (int)cmd.ExecuteScalar();
            }
        }
        // Hàm gọi Stored Procedure chia bảng
        public static bool GenerateGroupStage(int tournamentId, int numberOfGroups)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GenerateGroupStage", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TournamentID", tournamentId);
                cmd.Parameters.AddWithValue("@NumberOfGroups", numberOfGroups);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
                    return false;
                }
            }
        }
        // Hàm lấy số bảng của giải đấu
        public static int GetTournamentGroupCount(int tournamentId)
        {
            // Mặc định là 1 bảng
            int defaultCount = 1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT GroupCount FROM Tournaments WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", tournamentId);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int count))
                    {
                        // Nếu > 0 thì lấy, còn không (hoặc âm) thì lấy mặc định
                        return count > 0 ? count : defaultCount;
                    }
                }
                catch
                {
                    // Nếu có lỗi thì trả về mặc định
                }
            }
            return defaultCount;
        }
        // Kiểm tra xem giải đấu đã có lịch thi đấu chưa
        public static bool HasSchedule(int tournamentId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Chỉ cần đếm xem có bất kỳ trận đấu nào thuộc giải này không
                string sql = "SELECT COUNT(*) FROM Matches WHERE TournamentID = @tId";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tId", tournamentId);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Trả về True nếu đã có lịch
                }
            }
        }

        // Hàm Reset giải đấu (Xóa sạch lịch để làm lại từ đầu)
        public static void ResetTournamentMatches(int tournamentId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Matches WHERE TournamentID = @tId";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tId", tournamentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Hàm khóa toàn bộ trận đấu và quy về 0-0 nếu chưa đá
        public static void LockRound(int tournamentId, int round)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"UPDATE Matches 
                       SET Status = 2, 
                           HomeScore = ISNULL(HomeScore, 0), 
                           AwayScore = ISNULL(AwayScore, 0) 
                       WHERE TournamentID = @tId AND Round = @r";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@tId", tournamentId);
                    cmd.Parameters.AddWithValue("@r", round);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
