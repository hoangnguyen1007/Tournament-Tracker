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
    internal class DatabaseHelper
    {
        private static string connectionString = @"Data Source=DESKTOP-LOJ3INE\SQLEXPRESS;Initial Catalog=TournamentTracker;Integrated Security=True;TrustServerCertificate=True;";

        // TEAMS
        public static List<Team> GetTeams(string search = "")
        {
            var teams = new List<Team>();
            string sql = "SELECT ID, TEAMNAME, COACH FROM Teams"; // SELECT 
            if (!string.IsNullOrWhiteSpace(search)) sql += " WHERE TEAMNAME LIKE @search";
            // Kết nối DB
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (!string.IsNullOrWhiteSpace(search)) cmd.Parameters.AddWithValue("@search", $"%{search}%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        teams.Add(new Team
                        {
                            ID = reader.GetInt32("ID"),
                            TEAMNAME = reader.GetString("TEAMNAME"),
                            COACH = reader.IsDBNull("COACH") ? "" : reader.GetString("COACH")
                        });
                    }
                }
            }
            return teams;
        }
        // TEAM CRUD FUNCTION
        public static bool CheckTeam(string team) // Xem có tồn tại team này chưa ?
        {
            string query = "SELECT COUNT(*) FROM Teams WHERE TEAMNAME=@TN";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TN", team);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                // nếu đã tồn tại TEAMNAME return false, ngược lại return true
                return count == 0;
            }
        }
        public static void InsertTeam(Team team)
        {
            string sql = "INSERT INTO Teams (TEAMNAME, COACH) VALUES (@TEAMNAME, @COACH)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TEAMNAME", team.TEAMNAME);
                cmd.Parameters.AddWithValue("@COACH", string.IsNullOrWhiteSpace(team.COACH) ? (object)DBNull.Value : team.COACH);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateTeam(Team team)
        {
            string sql = "UPDATE Teams SET TEAMNAME = @TEAMNAME, COACH = @COACH WHERE ID = @ID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ID", team.ID);
                cmd.Parameters.AddWithValue("@TEAMNAME", team.TEAMNAME);
                cmd.Parameters.AddWithValue("@COACH", string.IsNullOrWhiteSpace(team.COACH) ? (object)DBNull.Value : team.COACH);

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
                    // Kiểm tra username đã tồn tại
                    using (SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM dbo.Account WHERE Username=@username", conn))
                    {
                        check.Parameters.AddWithValue("@username", username);
                        int exists = (int)check.ExecuteScalar();
                        if (exists > 0)
                        {
                            return false;
                        }
                    }

                    // Thêm account mới
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
                // SỬA CÂU QUERY: Lấy luôn ID
                string query = "SELECT ID FROM Account WHERE Username=@username AND PasswordHash=@password";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    // --- LƯU SESSION TẠI ĐÂY ---
                    UserSession.CurrentUserId = Convert.ToInt32(result);
                    UserSession.CurrentUsername = username;
                    return true;
                }
                return false;
            }
        }

        //Tournaments database
        public bool AddTournament(string name, string location, DateTime? startDate, string prize, string posterPath, string sport, int teamCount)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Thêm cột CreatedBy vào câu lệnh INSERT
                    string query = @"INSERT INTO Tournaments 
                   (NAME, LOCATION, STARTDATE, PRIZE, POSTERPATH, SPORT, TEAM_COUNT, CreatedBy) 
                   VALUES 
                   (@name, @location, @startDate, @prize, @posterPath, @sport, @teamCount, @createdBy)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@location", string.IsNullOrEmpty(location) ? (object)DBNull.Value : location);
                    cmd.Parameters.AddWithValue("@startDate", startDate.HasValue ? (object)startDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@prize", string.IsNullOrEmpty(prize) ? (object)DBNull.Value : prize);
                    cmd.Parameters.AddWithValue("@posterPath", string.IsNullOrEmpty(posterPath) ? (object)DBNull.Value : posterPath);
                    cmd.Parameters.AddWithValue("@sport", string.IsNullOrEmpty(sport) ? (object)DBNull.Value : sport);
                    cmd.Parameters.AddWithValue("@teamCount", teamCount);

                    // --- LẤY ID TỪ SESSION ---
                    cmd.Parameters.AddWithValue("@createdBy", UserSession.CurrentUserId);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                    return false;
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
                // Chỉ lấy dòng nào có CreatedBy trùng với ID đang đăng nhập
                string query = "SELECT * FROM Tournaments WHERE CreatedBy = @uid ORDER BY ID DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@uid", userId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        // 2. Lấy giải đấu của người khác (FIND / EXPLORE)
        public DataTable GetOtherTournaments(int currentUserId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Lấy tất cả giải MÀ KHÔNG PHẢI do mình tạo (CreatedBy != ID hoặc CreatedBy IS NULL)
                string query = "SELECT * FROM Tournaments WHERE (CreatedBy <> @uid OR CreatedBy IS NULL) ORDER BY ID DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@uid", currentUserId);

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
                    // CHẾ ĐỘ 1: Lấy giải CỦA TÔI sắp diễn ra gần nhất
                    // Điều kiện: CreatedBy = userId VÀ Ngày >= Hôm nay
                    sql = @"SELECT TOP 1 * FROM Tournaments 
                    WHERE CreatedBy = @uid AND STARTDATE >= CAST(GETDATE() AS DATE)
                    ORDER BY STARTDATE ASC";
                }
                else
                {
                    // CHẾ ĐỘ 2: Lấy giải CỦA NGƯỜI KHÁC sắp diễn ra (Quảng bá)
                    // Điều kiện: CreatedBy KHÁC userId
                    sql = @"SELECT TOP 1 * FROM Tournaments 
                    WHERE (CreatedBy <> @uid OR CreatedBy IS NULL) 
                    AND STARTDATE >= CAST(GETDATE() AS DATE)
                    ORDER BY STARTDATE ASC";
                }

                // Fallback: Nếu không có giải sắp tới, lấy giải vừa mới tạo gần nhất (DESC)
                // Bạn có thể viết thêm logic backup query ở đây nếu muốn.

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
                    // Chế độ CỦA TÔI: Chỉ đếm giải do tôi tạo
                    whereClause = "WHERE CreatedBy = @uid";
                }
                else
                {
                    // Chế độ TÌM KIẾM: Đếm giải của người khác (hoặc toàn bộ public)
                    whereClause = "WHERE (CreatedBy <> @uid OR CreatedBy IS NULL)";
                }

                string query = $@"
            SELECT
                COUNT(ID) AS TotalTournaments,
                SUM(CASE WHEN STARTDATE > GETDATE() THEN 1 ELSE 0 END) AS UpcomingTournaments,
                SUM(CASE WHEN STARTDATE <= GETDATE() THEN 1 ELSE 0 END) AS StartedOrFinishedTournaments
            FROM Tournaments
            {whereClause}"; // Chèn điều kiện lọc vào đây

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@uid", userId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        // =============================================================
        // PHẦN 4: TOURNAMENTS & MATCHES (CẬP NHẬT MỚI)
        // =============================================================

        // 1. Lấy danh sách các vòng đấu (để đổ vào ComboBox)
        public static List<string> GetRounds(int tournamentId) // Nên thêm tham số ID giải
        {
            var rounds = new List<string>();
            // Lọc theo giải đấu hiện tại
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
        // 2. Lấy danh sách trận đấu (Có hỗ trợ lọc theo vòng)
        public static DataTable GetMatchesTable(int tournamentId, string roundFilter = "")
        {
            DataTable dt = new DataTable();

            string sql = @"
            SELECT 
                m.ID AS MatchID,
                m.Round,
                ISNULL(t1.TEAMNAME, 'Unknown Home (' + CAST(m.HomeTeamID AS NVARCHAR) + ')') AS HomeTeamName,
                ISNULL(t2.TEAMNAME, 'Unknown Away (' + CAST(m.AwayTeamID AS NVARCHAR) + ')') AS AwayTeamName,
                m.HomeScore,
                m.AwayScore,
                m.HomeTeamID,
                m.AwayTeamID
            FROM Matches m
            LEFT JOIN Teams t1 ON m.HomeTeamID = t1.ID
            LEFT JOIN Teams t2 ON m.AwayTeamID = t2.ID
            WHERE m.TournamentID = @tId";

            // Logic xử lý filter an toàn hơn
            int roundNumber = 0;
            bool hasRoundFilter = false;

            if (!string.IsNullOrEmpty(roundFilter))
            {
                // 1. Xóa chữ "Round" và khoảng trắng dư thừa
                string numberPart = roundFilter.Replace("Round", "").Trim();
                // 2. Ép kiểu sang số 
                if (int.TryParse(numberPart, out roundNumber))
                {
                    sql += " AND m.Round = @RoundNum";
                    hasRoundFilter = true;
                }
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@tId", tournamentId);

                // Chỉ thêm tham số nếu ép kiểu thành công
                if (hasRoundFilter)
                {
                    cmd.Parameters.AddWithValue("@RoundNum", roundNumber);
                }

                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            // Tạo cột hiển thị tỷ số (ScoreDisplay) cho đẹp trên GridView
            dt.Columns.Add("ScoreDisplay", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                if (row["HomeScore"] == DBNull.Value || row["AwayScore"] == DBNull.Value)
                    row["ScoreDisplay"] = "vs";
                else
                    row["ScoreDisplay"] = $"{row["HomeScore"]} - {row["AwayScore"]}";
            }

            return dt;
        }

        // [CẬP NHẬT] 4. Cập nhật kết quả trận đấu
        public static void UpdateMatchResult(int matchId, int homeScore, int awayScore)
        {
            object winnerId = DBNull.Value;
            int homeTeamId = 0, awayTeamId = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Lấy ID 2 đội
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
                // Xác định người thắng
                if (homeScore > awayScore) winnerId = homeTeamId;
                else if (awayScore > homeScore) winnerId = awayTeamId;
                // Cập nhật DB
                string updateSql = "UPDATE Matches SET HomeScore=@h, AwayScore=@a, Status=2, WinnerID=@win WHERE ID=@id";
                using (SqlCommand cmd = new SqlCommand(updateSql, conn))
                {
                    cmd.Parameters.AddWithValue("@h", homeScore);
                    cmd.Parameters.AddWithValue("@a", awayScore);
                    cmd.Parameters.AddWithValue("@win", winnerId);
                    cmd.Parameters.AddWithValue("@id", matchId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // [MỚI] 5. Lấy danh sách đội bóng thuộc một giải đấu cụ thể
        public static List<Team> GetTeamsByTournament(int tournamentId)
        {
            List<Team> list = new List<Team>();
            // Chỉ lấy đội có TournamentID trùng khớp
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
                        // Kiểm tra null cho cột Coach nếu cần
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
        public static DataTable GetStandingsTable(int tournamentId, string groupName = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetStandings", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TournamentID", tournamentId);
                // Xử lý groupName null
                cmd.Parameters.AddWithValue("@GroupName", string.IsNullOrEmpty(groupName) ? (object)DBNull.Value : groupName);

                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);   
            }
            return dt;
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
    }
}
