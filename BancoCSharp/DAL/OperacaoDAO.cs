using BancoCSharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoCSharp.DAL
{
    class OperacaoDAO
    {
        public static Context ctx = new Context();

        public static Conta BuscarContaPorDigConta(Conta c)
        {
            return ctx.Contas.FirstOrDefault(x => x.DigConta.Equals(c.DigConta));
        }

        public static Conta BuscarContaIdPorDigConta(int DigConta)
        {
            var conta = ctx.Contas.Where(x => x.DigConta.Equals(DigConta)).FirstOrDefault();

            return conta;
        }

        public static bool RealizaSaque(Conta conta, int valorSaque)
        {
            if (conta.Saldo >= valorSaque)
            {
                conta.Saldo -= valorSaque;
                ctx.Contas.Attach(conta);
                ctx.Entry(conta).State = EntityState.Modified;
                ctx.SaveChanges();

                return true;
            }
            return false;
        }


        public static bool RealizaDeposito(Conta conta, int valorDeposito)
        {
            conta.Saldo += valorDeposito;
            ctx.Contas.Attach(conta);
            ctx.Entry(conta).State = EntityState.Modified;
            ctx.SaveChangesAsync();

            return true;
        }

        public static bool RealizaTransferencia(Conta conta_reme, Conta conta_dest, int ValorValorTransf)
        {
            if (conta_reme.Saldo >= ValorValorTransf)
            {
                conta_dest.Saldo += ValorValorTransf;
                conta_reme.Saldo -= ValorValorTransf;
                ctx.Contas.Attach(conta_reme);
                ctx.Entry(conta_reme).State = EntityState.Modified;
                ctx.Contas.Attach(conta_dest);
                ctx.Entry(conta_dest).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;

        }

        public static bool SubtraiTotalBoleto(int bo_DigConta, double enviaTotal)
        {
            Conta conta = BuscarContaIdPorDigConta(bo_DigConta);

            int saldoCliente = Convert.ToInt32(conta.Saldo);

            if (saldoCliente > enviaTotal)
            {
                conta.Saldo -= enviaTotal;
                ctx.Contas.Attach(conta);
                ctx.Entry(conta).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }



        /*                              FUNÇÕES CONTADAO PARA NAO DAR ERRO NO CONTEXT                   */

            

        //public static Conta _BuscarContaIdPorDigConta(int DigConta)
        //{
        //    var conta = ctx.Contas.Where(x => x.DigConta.Equals(DigConta)).FirstOrDefault();

        //    return conta;
        //}


        public static bool CadastrarConta(Conta c)
        {
            try
            {
                ctx.Clientes.Attach(c.ClienteId);
                ctx.Contas.Add(c);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static List<Conta> ListarContas(int clienteId)
        {
            return ctx.Contas.Where(x => x.ClienteId.Id.Equals(clienteId)).ToList();
        }


        public static int BuscarContaPorClienteId(int clienteId)
        {
            var conta = ctx.Contas.Where(x => x.ClienteId.Id.Equals(clienteId)).FirstOrDefault();

            return conta.Id;
        }

        public static Cliente BuscarClientePorId(int clienteId)
        {
            var cliente = ctx.Clientes.Where(x => x.Id.Equals(clienteId)).FirstOrDefault();

            return cliente;
        }
    }
}
