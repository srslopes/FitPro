using FitPro.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FitPro.Views;

namespace FitPro
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateTablesSQL();
        }

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            //TesteClasses tc = new TesteClasses();
            //tc.Show();
        }

        private void CreateTablesSQL()
        {
            try
            {
                Conexao conexao = new Conexao();
                Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso.");
                conexao.CloseConnection();
            }catch(Exception ex)
            {
                Console.WriteLine("Erro ao estabelecer a conexão: " + ex.Message);
            }
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
