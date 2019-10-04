using BancoCSharp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BancoCSharp.DAL
{
    class ContaDAO
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


        public static bool RealizaDeposito(Conta conta, int valorDeposito)
        {
            conta.Saldo += valorDeposito;
            ctx.Contas.Attach(conta);
            ctx.Entry(conta).State = EntityState.Modified;
            ctx.SaveChangesAsync();

            return true;
        }

    }
}
