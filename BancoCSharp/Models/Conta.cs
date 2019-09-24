using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoCSharp.Models
{
    [Table("Conta")]

    public class Conta
    {
        public Conta() 
        {
            CriadoEm = DateTime.Now;
        }


        [Key]
        public int Id { get; set; }
        public int DigConta { get; set; }
        public double Saldo { get; set; }
        protected DateTime CriadoEm { get; set; }
        public virtual Cliente ClienteId { get; set; }
    }
}
