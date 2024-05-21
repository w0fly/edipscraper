using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace EdipScraper
{
    public class MySqlHelper
    {
        private string connectionString;

        public MySqlHelper(string server, string database, string uid, string password)
        {
            connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query)
        {
            using (var connection = GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void ExecuteNonQuery(string query)
        {
            using (var connection = GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
