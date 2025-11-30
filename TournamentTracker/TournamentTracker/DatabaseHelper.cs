using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;

namespace TeamListForm
{
    internal class DatabaseHelper
    {
        private static string connectionString =
            @"Data Source=DESKTOP-LOJ3INE\SQLEXPRESS;Initial Catalog=TournamentTracker;Integrated Security=True;TrustServerCertificate=True;";

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
    }
}
