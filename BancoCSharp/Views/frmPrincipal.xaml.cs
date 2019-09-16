using BancoCSharp.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BancoCSharp
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "BancoCSharp", MessageBoxButton.YesNo,
                                   MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void BtnRealizarLogin_Click(object sender, RoutedEventArgs e)
        {
            frmOperacoes operacoes = new frmOperacoes();
            operacoes.ShowDialog();
        }

        private void NovoUsuario()
        { 
        TextBlock tb = new TextBlock();
        var hp = new Hyperlink(new Run("error"));
        hp.Click += (s, e) => { /* do something */ };
        }





    }
}
