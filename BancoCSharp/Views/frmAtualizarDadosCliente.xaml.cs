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
    /// Lógica interna para frmAtualizarDadosCliente.xaml
    /// </summary>
    public partial class frmAtualizarDadosCliente : Window
    {
        public frmAtualizarDadosCliente()
        {
            InitializeComponent();
        }
        public frmAtualizarDadosCliente(Usuario usuario)
        {
            InitializeComponent();
            labelUsuarioId.TextInput = usuario.Id;
        }

        public void LimparFormulario()
        {
            txtCpf.Clear();
            txtNomeCliente.Clear();
            txtEndereco.Clear();


            txtCpf.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Cpf = txtCpf.Text,
                Nome = txtNomeCliente.Text,
                Endereco = txtEndereco.Text,
                UsuarioId = 



            }


        }

    }
}
