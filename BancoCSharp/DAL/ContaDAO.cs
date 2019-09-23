using BancoCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (BuscarContaPorDigConta(c) == null)
            {
                ctx.Contas.Add(c);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<Conta> ListarContas()
        {
            return ctx.Contas.ToList();
        }

        public static Conta BuscarContaPorDigConta(int DigConta)
        {
            return ctx.Contas.Find(DigConta);
        }
    }
}
