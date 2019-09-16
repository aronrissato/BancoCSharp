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
        public Cliente ContaCliente { get; set; }
        public double Saldo { get; set; }
        public Operacao Extrato { get; set; }
        public DateTime CriadoEm { get; set; }



    }
}
