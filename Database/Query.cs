using MySql.Data.MySqlClient;
using BCrypt.Net;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System;

namespace FitPro.Database
{
    public class Query
    {
        private Conexao conexao;

        public Query()
        {
            conexao = new Conexao();
        }
        
        public void Insert(string table, List<(string column, object value)> values)
        {
            MySqlConnection connection = conexao.GetConnection();

            if(connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                List<string> columns = new List<string>();
                List<string> parameters = new List<string>();
                List<MySqlParameter> sqlParameters = new List<MySqlParameter>();

                foreach(var (column,value) in values)
                {
                    columns.Add(column.ToString());
                    parameters.Add($"@{column}");
                    sqlParameters.Add(new MySqlParameter($"@{column}", value));
                }

                string joinedColumns = string.Join(", ", columns);
                string joinedParameters = string.Join(", ", parameters);

                string query = $"INSERT INTO `{table}` ({joinedColumns}) VALUES ({joinedParameters})";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddRange(sqlParameters.ToArray());
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro no INSERT: " + ex.Message);
            }
            finally
            {
                conexao.CloseConnection();
            }
        }

        public List<Dictionary<string, object>> Read(string table, string fields = "*")
        {
            MySqlConnection connection = conexao.GetConnection();
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

            try
            {
                string query = $"SELECT {fields} FROM `{table}`";
                MySqlCommand command = new MySqlCommand(query, connection);
                
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();
                        for(int i=0;i<reader.FieldCount;i++)
                        {
                            string fieldName = reader.GetName(i);
                            object fieldValue = reader.GetValue(i);
                            row[fieldName] = fieldValue;
                        }

                        results.Add(row);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro no READ USUARIOS: " + ex.Message);
            }
            finally
            {
                conexao.CloseConnection();
            }

            return results;
        }

        public void Update(string table, List<(string column, object value)> values, string condition)
        {
            MySqlConnection connection = conexao.GetConnection();

            try
            {
                List<string> assignments = new List<string>();
                List<MySqlParameter> sqlParameters = new List<MySqlParameter>();

                foreach(var (column, value) in values)
                {
                    assignments.Add($"{column} = @{column}");
                    sqlParameters.Add(new MySqlParameter($"@{column}", value));
                }

                string joinedAssignments = string.Join(", ", assignments);

                string query = $"UPDATE `{table}` SET {joinedAssignments} WHERE {condition}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddRange(sqlParameters.ToArray());
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro no UPDATE: " + ex.Message);
            }
            finally
            {
                conexao.CloseConnection();
            }
        }

        public void Delete(string table, string condition)
        {
            MySqlConnection connection = conexao.GetConnection();

            try
            {
                string query = $"DELETE FROM `{table}` WHERE {condition}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro no DELETE: " + ex.Message);
            }
            finally
            {
                conexao.CloseConnection();
            }
        }

        public List<Dictionary<string, object>> ReadWhere(string table, string condition)
        {
            MySqlConnection connection = conexao.GetConnection();
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

            try
            {
                string query = $"SELECT * FROM `{table}` WHERE {condition}";
                MySqlCommand command = new MySqlCommand(query, connection);

                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();
                        for(int i=0;i<reader.FieldCount;i++)
                        {
                            string fieldName = reader.GetName(i);
                            object value = reader.GetValue(i);
                            row[fieldName] = value;
                        }

                        results.Add(row);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro no READWHERE: " + ex.Message);
            }
            finally
            {
                conexao.CloseConnection();
            }

            return results;
        }
    }
}
