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

                // Populando banco de dados
                PopulationDatabaseStudents();
                PopulationDatabaseFicha();

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

        private void PopulationDatabaseStudents()
        {
            try
            {
                string sql = @"INSERT IGNORE INTO aluno (ID, nome, telefone, data_nascimento, altura, ID_ultima_ficha, IDs_fichas)
                              VALUES
                              (1, 'Ana Silva', '1234567890', '1999-05-10', 1.65, 100, '100.105.110'),
                              (2, 'Pedro Santos', '9876543210', '1998-07-15', 1.78, 101, '101.106.111'),
                              (3, 'Maria Oliveira', '5555555555', '2000-02-20', 1.60, 102, '102.107.112'),
                              (4, 'André Almeida', '9999999999', '1997-12-05', 1.75, 103, '103.108.113'),
                              (5, 'Carolina Rodrigues', '7777777777', '1999-09-25', 1.68, 104, '104.109.114'),
                              (6, 'Guilherme Sousa', '2222222222', '2001-03-12', 1.82, 115, '115.120.125'),
                              (7, 'Laura Lima', '8888888888', '1996-11-02', 1.63, 116, '116.121.126'),
                              (8, 'Lucas Mendes', '4444444444', '1999-08-18', 1.80, 117, '117.122.127');";

                using (MySqlCommand command = new MySqlCommand(sql, Connect))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao popular tabela 'alunos': " + ex.Message);
            }
        }

        private void PopulationDatabaseFicha()
        {
            try
            {
                string sql = @"INSERT IGNORE INTO ficha (ID, ID_aluno, data, peso, medida_barriga, medida_peito, medida_braco_direito, medida_braco_esquerdo, medida_perna_direita, medida_perna_esquerda, comentarios)
                              VALUES
                              (100, 1, '2022-01-10', 70.5, 80, 95, 32, 31, 55, 54, 'Ficha 1 do aluno 1'),
                              (101, 2, '2022-01-11', 68.9, 78, 92, 30, 29, 53, 52, 'Ficha 1 do aluno 2'),
                              (102, 3, '2022-01-12', 65.2, 75, 89, 29, 28, 51, 50, 'Ficha 1 do aluno 3'),
                              (103, 4, '2022-01-13', 72.1, 82, 97, 34, 33, 57, 56, 'Ficha 1 do aluno 4'),
                              (104, 5, '2022-01-14', 69.8, 79, 93, 31, 30, 54, 53, 'Ficha 1 do aluno 5'),
                              (105, 1, '2022-02-10', 69.2, 78, 92, 31, 30, 54, 53, 'Ficha 2 do aluno 1'),
                              (106, 2, '2022-02-11', 67.5, 76, 90, 30, 29, 52, 51, 'Ficha 2 do aluno 2'),
                              (107, 3, '2022-02-12', 64.9, 74, 88, 28, 27, 50, 49, 'Ficha 2 do aluno 3');";

                using (MySqlCommand command = new MySqlCommand(sql, Connect))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao popular tabela 'ficha': " + ex.Message);
            }
        }
    }
}
