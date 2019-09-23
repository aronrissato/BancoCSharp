﻿using BancoCSharp.Models;
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
            Usuario u = new Usuario
            {
                Login = txtLogin.Text,
                Senha = pswSenha.Password
            };

            if (pswRepitaSenha.Password != pswSenha.Password)
            {
                MessageBox.Show("Senha digitada não confere com a confirmação da senha",
                    "BancoCSharp", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Usuário cadastrado com sucesso!",
                        "Banco CSharp", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                LimparFormulario();
                
            }
        }
    }
}