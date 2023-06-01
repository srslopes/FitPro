using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System;

namespace FitPro.Database
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

                // Chamadas para criar a tabelas no banco de dados [caso não exista]
                CreateTableUsers();
                CreateTableRegister();
                CreateTableStudents();

                Console.WriteLine("Tabelas criadas com sucesso!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro ao criar as tabelas: " + ex.Message);
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

        private void CreateTableUsers()
        {
            try
            {
                string sql = @"
                    CREATE TABLE IF NOT EXISTS usuario (
                    ID INT NOT NULL AUTO_INCREMENT,
                    nome VARCHAR(255) NOT NULL,
                    email VARCHAR(255) NOT NULL,
                    senha VARCHAR(255) NOT NULL,
                    PRIMARY KEY (ID)
                            );";

                using(MySqlCommand command = new MySqlCommand(sql, Connect))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro ao criar tabela 'usuario': " + ex.Message);
            }
        }

        private void CreateTableRegister()
        {
            try{
                string sql = @"
                        CREATE TABLE IF NOT EXISTS ficha (
                        ID INT NOT NULL AUTO_INCREMENT,
                        ID_aluno INT,
                        data VARCHAR(255) NOT NULL,
                        peso FLOAT,
                        medida_barriga FLOAT,
                        medida_peito FLOAT,
                        medida_braco_direito FLOAT,
                        medida_braco_esquerdo FLOAT,
                        medida_perna_direita FLOAT,
                        medida_perna_esquerda FLOAT,
                        comentarios VARCHAR(255) NOT NULL,
                        PRIMARY KEY (ID)
                                );";

                using(MySqlCommand command = new MySqlCommand(sql, Connect))
                {
                    command.ExecuteNonQuery();
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Erro ao criar tabela 'ficha': " + ex.Message);
            }
        }

        private void CreateTableStudents()
        {
            try{
                string sql = @"
                        CREATE TABLE IF NOT EXISTS aluno (
                        ID INT NOT NULL AUTO_INCREMENT,
                        nome VARCHAR(255) NOT NULL,
                        telefone INT,
                        data_nascimento VARCHAR(255) NOT NULL,
                        altura FLOAT,
                        IDs_fichas VARCHAR(100),
                        PRIMARY KEY (ID)
                                );";

                using(MySqlCommand command = new MySqlCommand(sql, Connect))
                {
                    command.ExecuteNonQuery();
                }
            }catch(Exception ex)
            {
                Console.WriteLine("Erro ao criar tabela 'aluno': " + ex.Message);
            }
        }
    }
}
