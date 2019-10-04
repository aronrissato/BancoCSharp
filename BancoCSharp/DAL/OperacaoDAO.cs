using BancoCSharp.Models;
using System;
using System.Collections.Generic;
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
            return ctx.Contas.FirstOrDefault(x => x.Id.Equals(DigConta));
        }

        public static bool RealizaSaque(Conta conta, int valorSaque)
        {
            if (conta.Saldo >= valorSaque)
            {
                conta.Saldo -= valorSaque;
                ctx.SaveChanges();

                return true;
            }
            return false;
        }


        public static bool RealizaDeposito(Conta conta, int valorDeposito)
        {
            conta.Saldo += valorDeposito;
            ctx.SaveChangesAsync();

            return true;
        }

        public static bool RealizaTransferencia(Conta conta_reme, Conta conta_dest, int ValorValorTransf)
        {
            if (conta_reme.Saldo >= ValorValorTransf)
            {
                conta_dest.Saldo += ValorValorTransf;
                conta_reme.Saldo -= ValorValorTransf;
                ctx.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;

        }

    }
}
