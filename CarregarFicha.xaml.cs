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
    public partial class CarregarFicha : Window
    {
        private Ficha ficha;
        private string nome;
        public CarregarFicha(int id, string Nome)
        {
            InitializeComponent();
            ficha = ControleFicha.carregar(id);
            nome = Nome;
            CarregarDados();
        }

        private void CarregarDados()
        {
            CampoNome.Text = nome;
            CampoData.Text = ficha.getData().ToString();
            tbPeso.Text = ficha.getPeso() +"kg";
            tbBarriga.Text = ficha.getCintura() + "cm";
            tbPeito.Text = ficha.getPeito() + "cm";
            tbBracoR.Text = ficha.getBracoR() + "cm";
            tbBracoL.Text = ficha.getBracoL() + "cm";
            tbPernaR.Text = ficha.getPernaR() + "cm";
            tbPernaL.Text = ficha.getPernaL() + "cm";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
