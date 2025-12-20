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
        private static string connectionString = "Data Source=localhost;Initial Catalog=TournamentTracker;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;Command Timeout=30";

        // TEAMS
        public static List<Team> GetTeams(int tournamentId, string search = "")
        {
            var teams = new List<Team>();

            // Câu lệnh SQL thêm điều kiện: WHERE TournamentID = @tID
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
                            // Map thêm TournamentID
                            TournamentID = reader.GetInt32(reader.GetOrdinal("TournamentID")),
                            TEAMNAME = reader.GetString(reader.GetOrdinal("TEAMNAME")),
                            COACH = reader.IsDBNull(reader.GetOrdinal("COACH")) ? "" : reader.GetString(reader.GetOrdinal("COACH"))
                        });
                    }
                }
            }
            return teams;
        }
        // CRUD FUNCTION
        public static bool CheckTeam(string teamName, int tournamentId)
        {
            // Thêm điều kiện AND TournamentID = @tID
            string query = "SELECT COUNT(*) FROM Teams WHERE TEAMNAME=@TN AND TournamentID=@tID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TN", teamName);
                cmd.Parameters.AddWithValue("@tID", tournamentId); // <--- QUAN TRỌNG

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count == 0; // True nếu chưa có (không trùng)
            }
        }
        public static void InsertTeam(Team team, int tournamentId)
        {
            // Thêm cột TournamentID vào câu lệnh INSERT
            string sql = "INSERT INTO Teams (TEAMNAME, COACH, TournamentID) VALUES (@TEAMNAME, @COACH, @tID)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@TEAMNAME", team.TEAMNAME);
                cmd.Parameters.AddWithValue("@COACH", string.IsNullOrWhiteSpace(team.COACH) ? (object)DBNull.Value : team.COACH);
                cmd.Parameters.AddWithValue("@tID", tournamentId); 

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public DataRow GetTournamentById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Tournaments WHERE ID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);

                if (dt.Rows.Count > 0) return dt.Rows[0];
                return null;
            }
        }

        // 2. Cập nhật giải đấu
        public bool UpdateTournament(int id, string name, string location, DateTime startDate, string prize, string posterPath, string sport, int teamCount,
                              string mode, string s1Format, string s2Format)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Cập nhật thêm 3 cột: FormatMode, Stage1Format, Stage2Format
                    string query = @"UPDATE Tournaments 
                             SET NAME = @name, 
                                 LOCATION = @location, 
                                 STARTDATE = @startDate, 
                                 PRIZE = @prize, 
                                 POSTERPATH = @posterPath, 
                                 SPORT = @sport, 
                                 TEAM_COUNT = @teamCount,
                                 FormatMode = @mode,
                                 Stage1Format = @s1,
                                 Stage2Format = @s2
                             WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // --- CÁC THAM SỐ CŨ ---
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@location", string.IsNullOrEmpty(location) ? (object)DBNull.Value : location);
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@prize", string.IsNullOrEmpty(prize) ? (object)DBNull.Value : prize);
                    cmd.Parameters.AddWithValue("@posterPath", string.IsNullOrEmpty(posterPath) ? (object)DBNull.Value : posterPath);
                    cmd.Parameters.AddWithValue("@sport", string.IsNullOrEmpty(sport) ? (object)DBNull.Value : sport);
                    cmd.Parameters.AddWithValue("@teamCount", teamCount);

                    // --- 3 THAM SỐ MỚI (QUAN TRỌNG) ---
                    cmd.Parameters.AddWithValue("@mode", mode);       // Ví dụ: "Single" hoặc "Multi"
                    cmd.Parameters.AddWithValue("@s1", s1Format);     // Ví dụ: "Knockout"
                    cmd.Parameters.AddWithValue("@s2", string.IsNullOrEmpty(s2Format) ? (object)DBNull.Value : s2Format);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Lỗi Update: " + ex.Message);
                    return false;
                }
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
        public int AddTournament(string name, string location, DateTime? startDate, string prize, string posterPath, string sport, int teamCount, string mode, string s1Format, string s2Format) 
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Thêm: SELECT CAST(SCOPE_IDENTITY() AS INT) để lấy ID vừa tạo ngay lập tức
                    string query = @"INSERT INTO Tournaments 
               (NAME, LOCATION, STARTDATE, PRIZE, POSTERPATH, SPORT, TEAM_COUNT, CreatedBy, FormatMode, Stage1Format, Stage2Format) 
               VALUES 
               (@name, @location, @startDate, @prize, @posterPath, @sport, @teamCount, @createdBy, @mode, @s1, @s2);
               SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@location", string.IsNullOrEmpty(location) ? (object)DBNull.Value : location);
                    cmd.Parameters.AddWithValue("@startDate", startDate.HasValue ? (object)startDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@prize", string.IsNullOrEmpty(prize) ? (object)DBNull.Value : prize);
                    cmd.Parameters.AddWithValue("@posterPath", string.IsNullOrEmpty(posterPath) ? (object)DBNull.Value : posterPath);
                    cmd.Parameters.AddWithValue("@sport", string.IsNullOrEmpty(sport) ? (object)DBNull.Value : sport);
                    cmd.Parameters.AddWithValue("@teamCount", teamCount);
                    cmd.Parameters.AddWithValue("@createdBy", UserSession.CurrentUserId);
                    cmd.Parameters.AddWithValue("@mode", mode);
                    cmd.Parameters.AddWithValue("@s1", s1Format);
                    cmd.Parameters.AddWithValue("@s2", string.IsNullOrEmpty(s2Format) ? (object)DBNull.Value : s2Format);
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return -1; // Trả về -1 nếu lỗi
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
        // Thêm tham số string keyword mặc định là rỗng
         public DataTable GetOtherTournaments(int currentUserId, string keyword = "")
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // --- SỬA Ở ĐÂY ---
                // Bỏ điều kiện "(CreatedBy <> @uid)" đi để nó lấy TOÀN BỘ giải trên hệ thống
                string query = @"SELECT * FROM Tournaments 
                         WHERE (@key = '' OR NAME LIKE N'%' + @key + '%') 
                         ORDER BY ID DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                // cmd.Parameters.AddWithValue("@uid", currentUserId); // Không cần dòng này nữa
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
                    // Chế độ TÌM KIẾM: Đếm TOÀN BỘ (không cần WHERE hoặc WHERE 1=1)
                    // Bạn muốn đếm cả của mình và người khác thì bỏ điều kiện lọc đi
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
                // Chỉ truyền tham số nếu câu lệnh có dùng @uid
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
                string sql = "SELECT * FROM Tournaments WHERE (CreatedBy <> @uid OR CreatedBy IS NULL) ";

                // Nối thêm điều kiện dựa vào nút bấm
                switch (filterMode)
                {
                    case "Active":
                        // Đang diễn ra: Ngày bắt đầu <= Hôm nay
                        sql += " AND STARTDATE <= CAST(GETDATE() AS DATE)";
                        break;
                    case "Upcoming":
                        // Sắp tới: Ngày bắt đầu > Hôm nay
                        sql += " AND STARTDATE > CAST(GETDATE() AS DATE)";
                        break;
                    case "HighPrize":
                        // Ví dụ: Lọc giải thưởng lớn (Logic này tuỳ bạn xử lý chuỗi tiền tệ)
                        // sql += " ... "; 
                        sql += " ORDER BY PRIZE DESC"; // Sắp xếp tiền to lên đầu
                        break;
                    case "Recently":
                        sql += " ORDER BY ID DESC"; // Mới tạo nhất
                        break;
                    case "All":
                    default:
                        // Mặc định sắp xếp theo ngày
                        sql += " ORDER BY ID DESC";
                        break;
                }

                // Nếu câu lệnh chưa có ORDER BY thì thêm mặc định
                if (!sql.Contains("ORDER BY")) sql += " ORDER BY STARTDATE ASC";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uid", userId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
        // =============================================================
        // PHẦN 4: TOURNAMENTS & MATCHES (CẬP NHẬT MỚI)
        // =============================================================

        // [MỚI] 1. Lấy danh sách Giải đấu (Để đổ vào ComboBox chọn giải)
        public static DataTable GetTournaments()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT ID, NAME FROM Tournaments"; // Lấy ID và Tên giải

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        // [CẬP NHẬT] 2. Lấy danh sách các vòng đấu (Theo ID Giải đấu)
        // Cần truyền vào tournamentId để biết lấy vòng của giải nào
        public static List<string> GetRounds(int tournamentId)
        {
            var rounds = new List<string>();
            // Chỉ lấy vòng đấu thuộc giải đấu đang chọn
            string sql = "SELECT DISTINCT Round FROM Matches WHERE TournamentID = @tID ORDER BY Round";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@tID", tournamentId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Hiển thị "Round 1", "Round 2"...
                        rounds.Add("Round " + reader.GetInt32(0).ToString());
                    }
                }
            }
            return rounds;
        }

        // [CẬP NHẬT] 3. Lấy danh sách trận đấu (Lọc theo Giải đấu + Vòng)
        public static DataTable GetMatchesTable(int tournamentId, string roundFilter = "")
        {
            DataTable dt = new DataTable();

            // Kết nối Matches, Teams (Chủ nhà), Teams (Khách)
            // QUAN TRỌNG: Phải lọc theo TournamentID
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
                JOIN Teams t2 ON m.AwayTeamID = t2.ID
                WHERE m.TournamentID = @tID";

            // Nếu có lọc theo vòng thì nối thêm điều kiện
            if (!string.IsNullOrEmpty(roundFilter))
            {
                sql += " AND m.Round = @RoundNum";
            }

            // Sắp xếp theo ID trận đấu
            sql += " ORDER BY m.ID ASC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Truyền tham số ID giải đấu
                cmd.Parameters.AddWithValue("@tID", tournamentId);

                if (!string.IsNullOrEmpty(roundFilter))
                {
                    // Chuyển chuỗi "Round 1" thành số 1 an toàn hơn
                    string roundNumStr = roundFilter.Replace("Round ", "").Trim();
                    int roundNum = 0;
                    if (int.TryParse(roundNumStr, out roundNum))
                    {
                        cmd.Parameters.AddWithValue("@RoundNum", roundNum);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@RoundNum", 1); // Mặc định nếu lỗi
                    }
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

        // [CẬP NHẬT] 4. Cập nhật kết quả trận đấu
        public static void UpdateMatchResult(int matchId, int homeScore, int awayScore)
        {
            // Cập nhật điểm số VÀ chuyển Status thành 2 (Kết thúc)
            string sql = "UPDATE Matches SET HomeScore = @h, AwayScore = @a, Status = 2 WHERE ID = @id";

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
