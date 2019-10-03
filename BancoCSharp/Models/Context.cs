using System;
using System.Data.Entity;

namespace BancoCSharp.Models
{
    internal class Context : DbContext
    { 
        public Context() : base("DefaultConnection") { }

        public DbSet<Usuario> Usuarios { get; set; }        
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
    }
}