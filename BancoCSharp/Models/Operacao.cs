using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoCSharp.Models
{
    class Operacao
    {
        public Operacao()
        {
            CriadoEm = DateTime.Now;
        }

        [Key]
        public string IdOperacao { get; set; }
        public string TipoOperacao { get; set; }
        public int DigConta { get; set; }
        protected DateTime CriadoEm { get; set; }

        [ForeignKey("DigConta")]
        public virtual Conta Conta { get; set; }
        


    }
}
