using BancoCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoCSharp.DAL
{
    class ClienteDAO
    {
        private static Context ctx = new Context();
        public static Cliente BuscarClientePorCpf(Cliente c)
        {
            return ctx.Clientes.FirstOrDefault
                (x => x.Cpf.Equals(c.Cpf));
        }

        public static bool CadastrarCliente(Cliente c)
        {
            if (BuscarClientePorCpf(c) == null)
            {
                ctx.Clientes.Add(c);
                ctx.SaveChanges();

                return true;
            }
            return false;
        }

        public static Cliente BuscarClientePorCpf(int Cpf)
        {
            return ctx.Clientes.Find(Cpf);
        }

    }
}
