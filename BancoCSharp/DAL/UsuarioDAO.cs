using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoCSharp.Models;

namespace BancoCSharp.DAL
{
    class UsuarioDAO
    {
        private static Context ctx = new Context();
        public static Usuario BuscarUsuarioPorLogin(Usuario u)
        {
            return ctx.Usuarios.FirstOrDefault
                (x => x.Login.Equals(u.Login));
        }

        public static bool CadastrarUsuario(Usuario u)
        {
            if (BuscarUsuarioPorLogin(u) == null)
            {
                ctx.Usuarios.Add(u);
                ctx.SaveChanges();

                return true;
            }
            return false;
        }

        public static Usuario BuscarUsuarioPorCpf(int Cpf)
        {
            return ctx.Usuarios.Find(Cpf);
        }

    }
}
