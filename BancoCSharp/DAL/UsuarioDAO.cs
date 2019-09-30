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
            return ctx.Usuarios.FirstOrDefault(x => x.Login.Equals(u.Login));
        }

        public static bool CadastrarUsuario(Usuario u)
        {
            try
            {
                ctx.Usuarios.Add(u);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }



        public static Usuario BuscarUsuarioPorLogin(int Login)
        {
            return ctx.Usuarios.Find(Login);
        }

        public static bool ValidarLogin(Usuario u)
        {
            var login = ctx.Usuarios.Where(x => x.Login == u.Login && x.Senha == u.Senha).FirstOrDefault();

            return login != null;
        }

        public static List<Usuario> ListarUsuarios()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
