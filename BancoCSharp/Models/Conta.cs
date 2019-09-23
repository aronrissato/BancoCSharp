using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoCSharp.Models
{
    [Table("Conta")]

    class Conta
    {
        public Conta() 
        {
            CriadoEm = DateTime.Now;
        }


        [Key]
        public int DigConta { get; set; }
        public double Saldo { get; set; }
        public string IdCliente { get; set; }
        public Operacao Extrato { get; set; }
        protected DateTime CriadoEm { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }



    }
}
