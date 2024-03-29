﻿using FitPro.Controller;
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

namespace FitPro.Views
{
    public partial class TesteClasses : Window
    {

        private Aluno aluno;
        private Ficha ficha;

        public TesteClasses()
        {
            InitializeComponent();
            aluno = new Aluno();
            ficha = new Ficha(aluno);
            limparAluno();
            limparFicha();
        }

        private void limparAluno()
        {
            aluno = new Aluno();
            idAluno.Text = "ID";
            campoId.Text = "";
            campoNome.Text = "";
            campoTelefone.Text = "";
            campoNascimento.Text = "";
            campoAltura.Text = "";
            campoFichas.Items.Clear();
            campoId.Text = "";
        }
        private void carregarAluno(int id)
        {
            aluno = ControleAluno.carregar(id);
            idAluno.Text = "ID: " +aluno.getId().ToString();
            campoNome.Text = aluno.getNome().ToString();
            campoTelefone.Text = aluno.getTelefone().ToString();
            campoAltura.Text = aluno.getAltura().ToString();
            campoFichas.Items.Clear();
            for (int i=0; i< aluno.getFichas().Count; i++) campoFichas.Items.Add(aluno.getFichas()[i]);
            limparFicha();
        }
        private void limparFicha()
        {
            ficha = new Ficha(aluno);
            idFicha.Text = "ID";
            campoIdAluno.Text = "ID Aluno";
            campoDataCriacao.Text = "Criação";
            campoPeso.Text = "";
            campoPeito.Text = "";
            campoCintura.Text = "";
            campoBracoR.Text = "";
            campoBracoL.Text = "";
            campoPernaR.Text = "";
            campoPernaL.Text = "";
            campoComentarios.Text = "";
        }
        private void carregarFicha(int id)
        {
            limparFicha();
            ficha = ControleFicha.carregar(id);
            idFicha.Text = "ID: " +ficha.getId();
            campoIdAluno.Text = "ID Aluno: " +ficha.getId();
            campoDataCriacao.Text = "Criação: " +ficha.getIdAluno();
            campoPeso.Text = ficha.getPeso().ToString();
            campoPeito.Text = ficha.getPeito().ToString();
            campoCintura.Text = ficha.getCintura().ToString();
            campoBracoR.Text = ficha.getBracoR().ToString();
            campoBracoL.Text = ficha.getBracoL().ToString();
            campoPernaR.Text = ficha.getPernaR().ToString();
            campoPernaL.Text = ficha.getPernaL().ToString();
            campoComentarios.Text = ficha.getComentarios();
        }

        private void bSalvarAluno_Click(object sender, RoutedEventArgs e)
        {
            aluno.setNome(campoNome.Text);
            aluno.setTelefone(int.Parse(campoTelefone.Text));
            //aluno.setNascimento(DateTime.Parse());
            aluno.setAltura(float.Parse(campoAltura.Text));
            ControleAluno.salvar(aluno);
            carregarAluno(aluno.getId());
        }

        private void bCarrFichas_Click(object sender, RoutedEventArgs e)
        {
            if(campoFichas.SelectedItem != null)
            {
                carregarFicha(int.Parse(campoFichas.SelectedItem.ToString()));
            }
        }

        private void bCarrAluno_Click(object sender, RoutedEventArgs e)
        {
            carregarAluno(int.Parse(campoId.Text));
        }

        private void bSalvarFicha_Click(object sender, RoutedEventArgs e)
        {
            ficha.setPeso(float.Parse(campoPeso.Text));
            ficha.setPeito(float.Parse(campoPeito.Text));
            ficha.setCintura(float.Parse(campoCintura.Text));
            ficha.setBracoL(float.Parse(campoBracoL.Text));
            ficha.setBracoR(float.Parse(campoBracoR.Text));
            ficha.setPernaL(float.Parse(campoPernaL.Text));
            ficha.setPernaR(float.Parse(campoPernaR.Text));
            ficha.setComentarios(campoComentarios.Text);
            ControleFicha.salvar(ficha, aluno);
            int id = ficha.getId();
            carregarAluno(aluno.getId());
            carregarFicha(id);
        }

        private void bLimparAluno_Click(object sender, RoutedEventArgs e)
        {
            limparAluno();
            limparFicha();
        }

        private void bExcluirAluno_Click(object sender, RoutedEventArgs e)
        {
            ControleAluno.deletar(aluno);
            limparAluno();
            limparFicha();
        }

        private void bLimparFicha_Click(object sender, RoutedEventArgs e)
        {
            limparFicha();
        }

        private void bExcluirFicha_Click(object sender, RoutedEventArgs e)
        {
            ControleFicha.deletar(ficha);
            carregarAluno(aluno.getId());
            limparFicha();
        }
    }
}
