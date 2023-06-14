using FitPro.Controller;
using FitPro.Database;
using FitPro.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace FitPro
{
    public partial class DashboardAlunos : Window
    {

        private Query query;

        public DashboardAlunos()
        {
            InitializeComponent();
            query = new Query();
            List<Aluno> alunos = ControleAluno.Listar();
            UsuariosGrid.ItemsSource = alunos;
        }
    }
}
