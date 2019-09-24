using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoCSharp.Models
{
    [Table("Usuario")]

    public class Usuario
    {
        public Usuario()
        {
            CriadoEm = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        protected DateTime CriadoEm { get; set; }

    }
}
