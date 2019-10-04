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

    public partial class frmTransferencia : Window
    {
        int tr_DigConta;
        int cliente;

        public frmTransferencia(int op_digConta, int clienteId)
        {
            InitializeComponent();
            tr_DigConta = op_digConta;
            cliente = clienteId;
        }

        private void BtnTransferir_Click(object sender, RoutedEventArgs e)
        {
            Conta conta_reme = OperacaoDAO.BuscarContaIdPorDigConta(tr_DigConta);
            int tr_DigConta_Destino = Convert.ToInt32(txtDestino.Text);
            int ValorTransf = Convert.ToInt32(txtValorTransf.Text);

            Conta contaDestino = OperacaoDAO.BuscarContaIdPorDigConta(tr_DigConta_Destino);

            var operacao = OperacaoDAO.RealizaTransferencia(conta_reme, contaDestino, ValorTransf);

            if (operacao)
            {
                MessageBox.Show("Transferência realizada!", "BancoCSharp", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao realizar a transferência! Verifique seu saldo na conta selecionada.", "BancoCSharp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
