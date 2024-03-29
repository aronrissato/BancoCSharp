﻿using BancoCSharp.DAL;
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
    /// Lógica interna para frmEscolhaConta.xaml
    /// </summary>
    public partial class frmEscolhaConta : Window
    {
        int clienteId;

        public frmEscolhaConta(int id)
        {
            InitializeComponent();
            clienteId = id;
        }

        public void LimparFormulario()
        {
            txtNovaConta.Clear();
            txtNovaConta.Focus();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboContas.ItemsSource = ContaDAO.ListarContas(clienteId);
            cboContas.DisplayMemberPath = "DigConta";
            cboContas.SelectedValuePath = "DigConta";
        }


        private void BtnCriaConta_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(txtNovaConta.Text) == 6)
            {
                var cliente = ClienteDAO.BuscarClientePorId(clienteId);

                Conta conta = new Conta
                {
                    DigConta = Convert.ToInt32(txtNovaConta.Text),
                    ClienteId = cliente
                };

                var isExisted = ContaDAO.BuscarContaPorDigConta(conta);

                if (isExisted == null)
                {
                    bool result = ContaDAO.CadastrarConta(conta);

                    if (result)
                    {
                        MessageBox.Show("Conta cadastrada com sucesso!", "BancoCSharp", MessageBoxButton.OK, MessageBoxImage.Information);
                        cboContas.ItemsSource = ContaDAO.ListarContas(clienteId);
                        cboContas.DisplayMemberPath = "DigConta";
                        cboContas.SelectedValuePath = "DigConta";
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar a conta!", "BancoCSharp", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LimparFormulario();
                }
            }
            else
            {
                MessageBox.Show("A conta deve ter somente 6 digitos", "BancoCSharp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
