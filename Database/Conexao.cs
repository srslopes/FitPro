using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace NotePerson.Database
{
    public class Conexao
    {
        MySqlConnection Connect;

        public Conexao()
        {
            try
            {
                string connectionString = "datasource=localhost;username=root;password=;database=dbpt";
                Connect = new MySqlConnection(connectionString);
                Connect.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public MySqlConnection GetConnection()
        {
            if(Connect.State == ConnectionState.Closed)
            {
                Connect.Open();
            }

            return Connect;
        }

        public void CloseConnection()
        {
            if(Connect != null && Connect.State == System.Data.ConnectionState.Open)
            {
                Connect.Close();
            }
        }
    }
}
