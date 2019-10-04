using BancoCSharp.DAL;
using BancoCSharp.Models;
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

namespace BancoCSharp.Views
{
    /// <summary>
    /// Lógica interna para frmDeposito.xaml
    /// </summary>
    public partial class frmDeposito : Window
    {
        int dp_DigConta;
        int cliente;

        public frmDeposito(int op_digConta, int clienteId)
        {
            InitializeComponent();
            dp_DigConta = op_digConta;
            cliente = clienteId;
        }

        public void LimparCampos()
        {
            txtValorDeposito.Clear();
            txtValorDeposito.Focus();
        }


        private void BtnDepositar_Click(object sender, RoutedEventArgs e)
        {
            Conta conta = OperacaoDAO.BuscarContaIdPorDigConta(dp_DigConta);
            int ValorDeposito = Convert.ToInt32(txtValorDeposito.Text);

            var operacao = OperacaoDAO.RealizaDeposito(conta, ValorDeposito);

            if (operacao)
            {
                MessageBox.Show("Depósito realizado! Leve o montante em qualquer agência.", "BancoCSharp", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao realizar seu depósito!", "BancoCSharp", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
