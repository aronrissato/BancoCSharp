﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoCSharp.Models
{
    [Table("Cliente")]

    class Cliente
    {
        public Cliente()
        {
            CriadoEm = DateTime.Now;
        }

        [Key]
        public string IdCliente { get; set; }
        public string Login { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime CriadoEm { get; set; }

        [ForeignKey("Login")]
        public virtual Usuario Usuario { get; set; }
    }
}
