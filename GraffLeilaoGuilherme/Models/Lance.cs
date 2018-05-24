using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraffLeilaoGuilherme.Models
{
    public class Lance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int lanceID { get; set; }

        public int pessoaID { get; set; }
        public Pessoa pessoa { get; set; }

        public int produtoID { get; set; }
        public Produto produto { get; set; }

        public float lanceValor { get; set; }
    }
}