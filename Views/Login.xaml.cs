using FitPro.Controller;
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
using System.Windows.Shapes;

namespace FitPro
{
    public partial class Login : Window
    {
        private ControleAluno alunoController;

        public Login()
        {
            InitializeComponent();
            alunoController = new ControleAluno();
            LabelErradoEmail.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cadastrar cadastrar = new Cadastrar();
            cadastrar.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(alunoController.Autenticar(CampoEmail.Text, CampoSenha.Password)){
                DashboardAlunos dashalunos = new DashboardAlunos();
                dashalunos.Show();
                this.Hide();
            }else
                LabelErradoEmail.Visibility = Visibility.Visible;
        }
    }
}
