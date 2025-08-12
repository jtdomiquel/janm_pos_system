using MySql.Data.MySqlClient;

namespace jandm_pos
{
    public static class Database
    {
        private static string connectionString = "server=localhost;port=3308;user=root;password=vcdu2021Ms5;database=jandm_pos_db;default command timeout=0;Pooling=false;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
