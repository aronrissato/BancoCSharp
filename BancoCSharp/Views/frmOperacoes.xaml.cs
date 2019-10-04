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
    /// Lógica interna para frmOperacoes.xaml
    /// </summary>
    public partial class frmOperacoes : Window
    {
        int usuarioId;

        public frmOperacoes(int id)
        {
            InitializeComponent();
            usuarioId = id;
        }

        public void LimparCadastroConta()
        {
            txtNovaConta.Clear();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var clienteId = ClienteDAO.BuscarClientePorUsuario(usuarioId);
            Cliente cliente = ClienteDAO.BuscarClientePorUsuarioId(usuarioId);

            //frmEscolhaConta conta = new frmEscolhaConta(cliente.Id);
            //conta.ShowDialog();

            lblBemVindo.Content = "Bem-vindo! " + cliente.Nome;
            cboConta.ItemsSource = ClienteDAO.ListarContas(clienteId);
            cboConta.DisplayMemberPath = "DigConta";
            cboConta.SelectedValuePath = "DigConta";

        }

        private void BtnSalvarConta_Click_1(object sender, RoutedEventArgs e)
        {

            Cliente cliente = ClienteDAO.BuscarClientePorUsuarioId(usuarioId);

            Conta conta = new Conta
            {
                DigConta = Convert.ToInt32(txtNovaConta.Text),
                ClienteId = cliente
            };

            int contador = Convert.ToInt32(txtNovaConta.Text);

            var isExisted = ClienteDAO.BuscarContaPorDigConta(conta);

            if (isExisted == null)
            {
                bool result = ClienteDAO.CadastrarConta(conta);

                if (result)
                {
                    MessageBox.Show("Conta cadastrada com sucesso!", "BancoCSharp", MessageBoxButton.OK, MessageBoxImage.Information);
                    cboConta.ItemsSource = ClienteDAO.ListarContas(cliente.Id);
                    cboConta.DisplayMemberPath = "DigConta";
                    cboConta.SelectedValuePath = "DigConta";
                    LimparCadastroConta();
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao salvar a conta!", "BancoCSharp", MessageBoxButton.OK, MessageBoxImage.Error);
                    LimparCadastroConta();
                }
            }
            else
            {
                MessageBox.Show("Informe 6 dígitos para a nova conta.", "BancoCSharp", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void BtnSaque_Click(object sender, RoutedEventArgs e)
        {
            int op_digConta = Convert.ToInt32(cboConta.SelectedValue);
            var clienteId = ClienteDAO.BuscarClientePorUsuario(usuarioId);

            frmSaque saque = new frmSaque(op_digConta, clienteId);
            saque.ShowDialog();
        }

        private void BtnDeposito_Click(object sender, RoutedEventArgs e)
        {
            int op_digConta = Convert.ToInt32(cboConta.SelectedValue);
            var clienteId = ClienteDAO.BuscarClientePorUsuario(usuarioId);

            frmDeposito deposito = new frmDeposito(op_digConta, clienteId);
            deposito.ShowDialog();

        }

        private void BtnTransferencia_Click(object sender, RoutedEventArgs e)
        {
            int op_digConta = Convert.ToInt32(cboConta.SelectedValue);
            var clienteId = ClienteDAO.BuscarClientePorUsuario(usuarioId);

            frmTransferencia transferencia = new frmTransferencia(op_digConta, clienteId);
            transferencia.ShowDialog();
        }

        private void BtnBoleto_Click(object sender, RoutedEventArgs e)
        {
            int op_digConta = Convert.ToInt32(cboConta.SelectedValue);
            var clienteId = ClienteDAO.BuscarClientePorUsuario(usuarioId);

            frmBoletos boletos = new frmBoletos(op_digConta, clienteId);
            boletos.ShowDialog();
        }

    }
}
