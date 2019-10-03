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
            txtCriadoEm.Text = DateTime.Now.ToString();
        }

        public void LimparFormularioCliente()
        {
            txtCpf.Clear();
            txtCriadoEm.Clear();
            txtEndereco.Clear();
            txtNomeCliente.Clear();

            txtLogin.Focus();
        }

        public void LimparFormularioUsuario()
        {
            txtLogin.Clear();
            pswSenha.Clear();
            pswRepitaSenha.Clear();

            txtLogin.Focus();
        }



        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            //Cadastro de usuario
            Usuario usuario = new Usuario
            {
                Login = txtLogin.Text,
                Senha = pswSenha.Password
            };

            if (pswRepitaSenha.Password != pswSenha.Password)
            {
                MessageBox.Show("Senha digitada não confere com a confirmação da senha", "BancoCSharp", MessageBoxButton.OK, MessageBoxImage.Error);
                LimparFormularioUsuario();
            }
            else
            {
                var isExisted = UsuarioDAO.BuscarUsuarioPorLogin(usuario);

                if (isExisted == null)
                {
                    Cliente cliente = new Cliente
                    {
                        Cpf = txtCpf.Text,
                        Nome = txtNomeCliente.Text,
                        Endereco = txtEndereco.Text,
                        DataNascimento = dtoNascimento.SelectedDate.Value,
                        UsuarioId = usuario
                    };

                    var isCpfExisted = ClienteDAO.BuscarClientePorCpf(cliente);


                    if (isCpfExisted == null)
                    {
                        bool resultCliente = ClienteDAO.CadastrarCliente(cliente);

                        if (resultCliente)
                        {
                            MessageBox.Show("Usuário cadastrado com sucesso!", "Banco CSharp", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Erro ao cadastrar cliente!", "Banco CSharp", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("CPF informado já está vinculado com outro cliente.", "Banco CSharp", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    LimparFormularioUsuario();
                    LimparFormularioCliente();
                }
                else
                {
                    MessageBox.Show("Usuário já cadastrado!", "BancoCSharp");
                    LimparFormularioCliente();
                }
            }
        }
    }
}





