using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoCSharp.Models
{
    [Table("Usuario")]
    class Usuario
    {
        public Usuario()
        {
            CriadoEm = DateTime.Now;
        }


        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}
