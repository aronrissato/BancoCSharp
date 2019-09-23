using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoCSharp.Models
{
    class Context : DbContext
    {
        public Context() : base("BancoCSharp") { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
        //public DbSet<Extrato> extratos { get; set; }


    }
}