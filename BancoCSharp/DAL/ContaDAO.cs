using BancoCSharp.Models;
using System.Collections.Generic;
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

        public static bool CadastrarConta(Conta c)
        {
            try
            {
                ctx.Clientes.Attach(c.ClienteId);
                ctx.Contas.Add(c);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<Conta> ListarContas(int clienteId)
        {
            return ctx.Contas.Where(x => x.ClienteId.Id.Equals(clienteId)).ToList();
        }

        public static bool RealizaSaque(Conta conta, int valorSaque)
        {
            var objConta = BuscarContaPorDigConta(conta);

            if (objConta != null)
            {
                if (objConta.Saldo >= valorSaque)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
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
