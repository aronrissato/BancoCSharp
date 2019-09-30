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
            try
            {
                ctx.Clientes.Add(c);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int BuscarClientePorUsuario(int id)
        {
            var usuarioid = ctx.Clientes.FirstOrDefault(x => x.UsuarioId.Equals(id));
            int clienteid = usuarioid.Id;

            return clienteid;
        }


        public static Usuario ConsultaBanco(string login)
        {
            var RetornaUsuario = ctx.Usuarios.SqlQuery("Select id from Usuario Where login = '" + login + "'").FirstOrDefault();
            return RetornaUsuario;

        }

        public static Cliente ConsultaClientePorLogin(string login)
        {
            var RetornaClienteId = ctx.Clientes.SqlQuery("select c.id from Cliente c inner join Usuario u on c.UsuarioId_id = u.id where u.login like '%"+login+"%'").FirstOrDefault();
            return RetornaClienteId;

        }

    }
}
