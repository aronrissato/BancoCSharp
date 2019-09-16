using System;
using System.Collections.Generic;
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

        public string TipoOperacao { get; set; }
        public Conta DigConta { get; set; }
        public DateTime CriadoEm { get; set; }


    }
}
