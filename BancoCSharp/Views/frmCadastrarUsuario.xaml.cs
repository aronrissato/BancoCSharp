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
    /// Lógica interna para frmCadastrarUsuario.xaml
    /// </summary>
    public partial class frmCadastrarUsuario : Window
    {
        public frmCadastrarUsuario()
        {
            InitializeComponent();
        }

        public void LimparFormulario()
        {
            txtLogin.Clear();
            pswSenha.Clear();
            pswRepitaSenha.Clear();

            txtLogin.Focus();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Login = txtLogin.Text,
                Senha = pswSenha.Password
            };

            if (pswRepitaSenha.Password != pswSenha.Password)
            {
                MessageBox.Show("Senha digitada não confere com a confirmação da senha", "BancoCSharp", MessageBoxButton.OK, MessageBoxImage.Error);
                LimparFormulario();
            }
            else
            {
                var isExisted = UsuarioDAO.BuscarUsuarioPorLogin(usuario);

                if (isExisted == null)
                {
                    bool result = UsuarioDAO.CadastrarUsuario(usuario);

                    if (result)
                    {
                        MessageBox.Show("Usuário cadastrado com sucesso!", "Banco CSharp", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar usuario!", "BancoCSharp");
                    }

                    LimparFormulario();
                }
                else
                {
                    MessageBox.Show("Usuário já cadastrado!", "BancoCSharp");
                    LimparFormulario();
                }
            }
        }
    }
}





