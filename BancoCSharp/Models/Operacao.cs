using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoCSharp.Models
{
    [Table("Operacao")]

    public class Operacao
    {
        public Operacao()
        {
            CriadoEm = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public string TipoOperacao { get; set; }
        protected DateTime CriadoEm { get; set; }
        public virtual Conta ContaId { get; set; }
    }
}
