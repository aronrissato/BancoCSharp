using BancoCSharp.DAL;
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
    /// Lógica interna para frmEscolhaConta.xaml
    /// </summary>
    public partial class frmEscolhaConta : Window
    {
        public frmEscolhaConta()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboConta.ItemsSource = ContaDAO.ListarContas();
            cboConta.DisplayMemberPath = "DigConta";
            cboConta.SelectedValuePath = "DigConta";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frmOperacoes operacoes = new frmOperacoes();
            operacoes.ShowDialog();
        }
    }
}
