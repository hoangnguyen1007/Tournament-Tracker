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
        private static string connectionString = @"Data Source=localhost;Initial Catalog=TournamentTracker;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;Command Timeout=30";

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
        // CRUD FUNCTION
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
        SELECT
            p.ID,
            p.PLAYERNAME,
            p.POSITION,
            p.AGE,
            p.IDTEAM,
            p.NUMBER,
            t.TEAMNAME
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
        //MATCHES

        // 1. Lấy danh sách các vòng đấu (để đổ vào ComboBox)
        public static List<string> GetRounds()
        {
            var rounds = new List<string>();
            string sql = "SELECT DISTINCT Round FROM Matches ORDER BY Round";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Tạo chuỗi hiển thị "Round 1", "Round 2"...
                        rounds.Add("Round " + reader.GetInt32("Round").ToString());
                    }
                }
            }
            return rounds;
        }

        // 2. Lấy danh sách trận đấu (Có hỗ trợ lọc theo vòng)
        public static DataTable GetMatchesTable(string roundFilter = "")
        {
            DataTable dt = new DataTable();
            
            // Câu lệnh SQL kết nối 3 bảng: Matches, Teams (Chủ nhà), Teams (Khách)
            string sql = @"
                SELECT 
                    m.ID AS MatchID,
                    m.Round,
                    t1.TEAMNAME AS HomeTeamName,
                    t2.TEAMNAME AS AwayTeamName,
                    m.HomeScore,
                    m.AwayScore,
                    m.HomeTeamID,
                    m.AwayTeamID
                FROM Matches m
                JOIN Teams t1 ON m.HomeTeamID = t1.ID
                JOIN Teams t2 ON m.AwayTeamID = t2.ID";

            // Nếu có lọc theo vòng (VD: "Round 1" -> Lấy số 1)
            if (!string.IsNullOrEmpty(roundFilter))
            {
                sql += " WHERE m.Round = @RoundNum";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (!string.IsNullOrEmpty(roundFilter))
                {
                    // Cắt chuỗi "Round 1" lấy số 1
                    string roundNum = roundFilter.Replace("Round ", "").Trim();
                    cmd.Parameters.AddWithValue("@RoundNum", int.Parse(roundNum));
                }

                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            // Thêm cột hiển thị tỷ số (ScoreDisplay) cho đẹp
            dt.Columns.Add("ScoreDisplay", typeof(string));
            foreach (DataRow row in dt.Rows)
            {
                if (row["HomeScore"] == DBNull.Value || row["AwayScore"] == DBNull.Value)
                {
                    row["ScoreDisplay"] = "vs";
                }
                else
                {
                    row["ScoreDisplay"] = $"{row["HomeScore"]} - {row["AwayScore"]}";
                }
            }

            return dt;
        }

        // Cập nhật kết quả trận đấu
        public static void UpdateMatchResult(int matchId, int homeScore, int awayScore)
        {
            string sql = "UPDATE Matches SET HomeScore = @h, AwayScore = @a WHERE ID = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@h", homeScore);
                cmd.Parameters.AddWithValue("@a", awayScore);
                cmd.Parameters.AddWithValue("@id", matchId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
