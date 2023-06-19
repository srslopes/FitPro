﻿using FitPro.Controller;
using FitPro.Database;
using FitPro.Model;
using FitPro.Views;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace FitPro
{
    public partial class DashboardAlunos : Window
    {
        public DashboardAlunos()
        {
            InitializeComponent();
            CarregarAlunos();
        }

        private void CarregarAlunos()
        {
            ListaAlunos.Items.Clear();
            List<Aluno> alunos = ControleAluno.Listar();

            // Carrega todos os alunos na Listbox 'ListaAlunos'
            foreach (Aluno aluno in alunos)
            {
                ListaAlunos.Items.Add(aluno.getNome());
            }
        }

        private void ListaAlunos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(ListaAlunos.SelectedItem != null)
            {
                string nome = ListaAlunos.SelectedItem.ToString();
                CarregarFicha ficha = new CarregarFicha(nome);
                ficha.Show();
            }
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
