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
    /// Lógica interna para frmBoletos.xaml
    /// </summary>
    public partial class frmBoletos : Window
    {
        int bo_DigConta;
        int cliente;
        private List<dynamic> boletosGrid = new List<dynamic>();
        double total = 0;
        double enviaTotal;

        public frmBoletos(int op_digConta, int clienteId)
        {
            InitializeComponent();
            bo_DigConta = op_digConta;
            cliente = clienteId;
        }

        private void BtnAddBoleto_Click(object sender, RoutedEventArgs e)
        {
            if (!txtCodigoBoleto.Text.Equals(""))
            {
                int boletoId = Convert.ToInt32(txtCodigoBoleto.Text);
                double valorBoleto = Convert.ToDouble(txtValorBoleto.Text);
                
                dynamic d = new
                {
                    boletoId = Convert.ToInt32(txtCodigoBoleto.Text),
                    valorBoleto = Convert.ToDouble(txtValorBoleto.Text).ToString("C2"),
                };

                boletosGrid.Add(d);
                dtaBoletos.ItemsSource = boletosGrid;
                dtaBoletos.Items.Refresh();

                total += valorBoleto;
                lblTotal.Content = "Total: " + total.ToString("C2");
                enviaTotal = total;
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos.", "Banco CSharp", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnPagarBoletos_Click(object sender, RoutedEventArgs e)
        {
            var result = OperacaoDAO.SubtraiTotalBoleto(bo_DigConta, enviaTotal);
            if (result)
            {
                MessageBox.Show("Pagamento realizado com sucesso!", "Banco CSharp", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao pagar o boleto.", "Banco CSharp", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
