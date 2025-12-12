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
        private static string connectionString = "";

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
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Account WHERE Username=@username AND PasswordHash=@password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                int match = (int)cmd.ExecuteScalar();
                return match > 0; // true nếu tồn tại, false nếu không
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

                    // --- BƯỚC 1: FIX LỖI THIẾU CỘT (TỰ ĐỘNG SỬA DB) ---
                    string fixSql = @"
                IF COL_LENGTH('dbo.Tournaments', 'SPORT') IS NULL
                    ALTER TABLE dbo.Tournaments ADD SPORT NVARCHAR(50) NULL;
                
                IF COL_LENGTH('dbo.Tournaments', 'TEAM_COUNT') IS NULL
                    ALTER TABLE dbo.Tournaments ADD TEAM_COUNT INT DEFAULT 0;
            ";
                    using (SqlCommand fixCmd = new SqlCommand(fixSql, conn))
                    {
                        fixCmd.ExecuteNonQuery();
                    }
                    // ----------------------------------------------------

                    // BƯỚC 2: THÊM DỮ LIỆU NHƯ BÌNH THƯỜNG
                    string query = @"INSERT INTO Tournaments 
                           (NAME, LOCATION, STARTDATE, PRIZE, POSTERPATH, SPORT, TEAM_COUNT) 
                           VALUES 
                           (@name, @location, @startDate, @prize, @posterPath, @sport, @teamCount)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@location", string.IsNullOrEmpty(location) ? (object)DBNull.Value : location);
                    cmd.Parameters.AddWithValue("@startDate", startDate.HasValue ? (object)startDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@prize", string.IsNullOrEmpty(prize) ? (object)DBNull.Value : prize);
                    cmd.Parameters.AddWithValue("@posterPath", string.IsNullOrEmpty(posterPath) ? (object)DBNull.Value : posterPath);
                    cmd.Parameters.AddWithValue("@sport", string.IsNullOrEmpty(sport) ? (object)DBNull.Value : sport);
                    cmd.Parameters.AddWithValue("@teamCount", teamCount);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Hiện lỗi chi tiết để debug
                    System.Windows.Forms.MessageBox.Show("Lỗi Database: " + ex.Message);
                    return false;
                }
            }
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
        public DataRow GetHeroTournament()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
            SELECT TOP 1 *
            FROM Tournaments
            ORDER BY STARTDATE ASC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                    return dt.Rows[0];

                return null;
            }
        }
        public DataRow GetTournamentStats()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT

    COUNT(ID) AS TotalTournaments,
    
 
    SUM(CASE WHEN STARTDATE > GETDATE() THEN 1 ELSE 0 END) AS UpcomingTournaments,
    
   
    SUM(CASE WHEN STARTDATE <= GETDATE() THEN 1 ELSE 0 END) AS StartedOrFinishedTournaments
FROM Tournaments;";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                return dt.Rows.Count > 0 ? dt.Rows[0] : null; 
            }
        }
    }
}
