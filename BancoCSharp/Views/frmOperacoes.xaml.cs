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
        frmPrincipal home;

        public frmOperacoes(frmPrincipal principal)
        {
            InitializeComponent();
            home = principal;

        }


        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var id = home.txtLogin.Text;

            Cliente teste = ClienteDAO.ConsultaClientePorLogin(id);

            lblBemVindo.Content = "Bem-vindo!" + teste.Nome;


            //lblSaldo.Content = "Saldo: " +
        }


    }
}
