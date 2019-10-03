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


        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var clienteId = ClienteDAO.BuscarClientePorUsuario(usuarioId);
            Cliente cliente = ClienteDAO.BuscarClientePorUsuarioId(usuarioId);

            frmEscolhaConta conta = new frmEscolhaConta(cliente.Id);
            conta.ShowDialog();

            //TRAZ O OBJETO CLIENTE AQUI E PEGA O NOME PRA MOSTRAR NO CONTENT LBLBEMVINDO

            lblBemVindo.Content = "Bem-vindo! " + cliente.Nome;


            //lblSaldo.Content = "Saldo: " +
        }

        private void BtnSaque_Click(object sender, RoutedEventArgs e)
        {
            frmSaque saque = new frmSaque();
            saque.ShowDialog();
        }
    }
}
