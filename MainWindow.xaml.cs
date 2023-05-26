using NotePerson.Controller;
using NotePerson.Database;
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

namespace NotePerson
{
    public partial class MainWindow : Window
    {
        private UsuarioController usuario;
        private Query query;

        public MainWindow()
        {
            InitializeComponent();
            usuario = new UsuarioController();
            query = new Query();
            AtualizarListaUsuarios();
        }

        private void BotaoCadastrar_Click(object sender, RoutedEventArgs e)
        {
            usuario.CadastrarUsuario(CampoNome.Text, CampoEmail.Text, CampoSenha.Text);
        }

        private void AtualizarListaUsuarios()
        {
            List<Dictionary<string, object>> resultados = usuario.GetUsuarios();
            List<Usuario> usuarios = new List<Usuario>();

            foreach(Dictionary<string, object> row in resultados)
            {
                Usuario usuario = new Usuario
                {
                    ID = Convert.ToInt32(row["ID"]),
                    Nome = row["nome"].ToString(),
                    Email = row["email"].ToString()
                };

                usuarios.Add(usuario);
            }

            ListaUsuarios.ItemsSource = usuarios;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            usuario.DeleteUser(int.Parse(CampoDeletar.Text));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            usuario.UpdateUser(int.Parse(CampoDeletar.Text), CampoNome.Text, CampoEmail.Text, CampoSenha.Text);
        }
    }
}
