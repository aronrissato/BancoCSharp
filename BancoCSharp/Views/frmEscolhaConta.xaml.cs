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
        public frmEscolhaConta()
        {
            InitializeComponent();
        }

        public void LimparFormulario()
        {
            txtNovaConta.Clear();
            txtNovaConta.Focus();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboContas.ItemsSource = ContaDAO.ListarContas();
            cboContas.DisplayMemberPath = "DigConta";
            cboContas.SelectedValuePath = "DigConta";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //frmOperacoes operacoes = new frmOperacoes();
            //operacoes.ShowDialog();
        }


        private void BtnCriaConta_Click(object sender, RoutedEventArgs e)
        {
            Conta conta = new Conta
            {
                DigConta = Convert.ToInt32(txtNovaConta.Text)
            };



            var isExisted = ContaDAO.BuscarContaPorDigConta(conta);

            if (isExisted == null)
            {
                bool result = ContaDAO.CadastrarConta(conta);

                if (result)
                {
                    MessageBox.Show("Conta cadastrada com sucesso!", "BancoCSharp");
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro ao salvar a conta!", "BancoCSharp");
                }
                LimparFormulario();
            }

        }
    }
}
