using BancoCSharp.DAL;
using BancoCSharp.Models;
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
    /// Interação lógica para frmPrincipal.xam
    /// </summary>
    public partial class frmPrincipal : Window
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        public void LimparFormulario()
        {
            txtLogin.Clear();
            pswSenha.Clear();

            txtLogin.Focus();
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
            Usuario usuario = new Usuario
            {
                Login = txtLogin.Text,
                Senha = pswSenha.Password
            };

            var login = UsuarioDAO.ValidarLogin(usuario);

            if (login != null)
            {
                frmOperacoes operacoes = new frmOperacoes(login.Id);
                operacoes.ShowDialog();
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("Usuario não encontrado!", "BancoCSharp", MessageBoxButton.OK, MessageBoxImage.Error);
                LimparFormulario();
            }
        }
        

        private void BtnNovaConta_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarUsuario u = new frmCadastrarUsuario();
            u.ShowDialog();
        }
    }
}
