using FitPro.Controller;
using FitPro.Database;
using FitPro.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace FitPro
{
    public partial class DashboardAlunos : Window
    {

        private Query query;
        private UsuarioController usuario;
        private List<Aluno> alunoModel;
        private Aluno aluno;

        public DashboardAlunos()
        {
            InitializeComponent();
            query = new Query();
            usuario = new UsuarioController();
            alunoModel = new List<Aluno>();
            aluno = new Aluno();

            List<Dictionary<string, object>> usuarios = usuario.GetUsuarios();
            foreach (var usuario in usuarios)
            {
                Aluno novoAluno = new Aluno();
                novoAluno.setNome(Convert.ToString(usuario["nome"]));
                novoAluno.setTelefone(Convert.ToInt32(usuario["telefone"]));
                novoAluno.setUltima(Convert.ToInt32(usuario["ID_ultima_ficha"]));
                alunoModel.Add(novoAluno);
            }

            UsuariosGrid.ItemsSource = alunoModel;
        }
    }
}
