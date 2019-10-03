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
    /// Lógica interna para frmSaque.xaml
    /// </summary>
    public partial class frmSaque : Window
    {
        public frmSaque()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboContaSaque.ItemsSource = ContaDAO.ListarContas(0);
        }


        private void BtnEnviaSaque_Click(object sender, RoutedEventArgs e)
        {
            Conta conta = new Conta
            {
                Id = Convert.ToInt32(cboContaSaque.SelectedValue)
            };

            int valorSaque = Convert.ToInt32(txtValorSaque.Text);

            var operacao = ContaDAO.RealizaSaque(conta, valorSaque);

            if (operacao == true)
            {
                MessageBox.Show("Saque realizado! Retire o montante em qualquer agência.", "BancoCSharp", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao realizar seu saque. Verifique seu saldo!", "BancoCSharp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
