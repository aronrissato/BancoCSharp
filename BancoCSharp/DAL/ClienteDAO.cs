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
                ctx.Usuarios.Attach(c.UsuarioId);
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
            var cliente = ctx.Clientes.Where(x => x.UsuarioId.Id.Equals(id)).FirstOrDefault();

            return cliente.Id;
        }

        public static Cliente BuscarClientePorUsuarioId(int id)
        {
            Cliente cliente = ctx.Clientes.Where(x => x.UsuarioId.Id.Equals(id)).FirstOrDefault();

            return cliente;
        }



        public static Usuario RetornaLogin(string login)
        {
            var RetornaUsuario = ctx.Usuarios.SqlQuery("Select id from Usuario Where login = '" + login + "'").FirstOrDefault();
            return RetornaUsuario;

        }

        public static Cliente ConsultaClientePorLogin(string login)
        {
            var RetornaClienteId = ctx.Clientes.SqlQuery("select c.id from Cliente c inner join Usuario u on c.UsuarioId_id = u.id where u.login like '%" + login + "%'").FirstOrDefault();
            return RetornaClienteId;

        }

        public static Cliente BuscarClientePorId(int clienteId)
        {
            var cliente = ctx.Clientes.Where(x => x.Id.Equals(clienteId)).FirstOrDefault();
            return cliente;
        }
    }
}
