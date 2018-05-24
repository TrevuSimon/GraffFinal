using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraffLeilaoGuilherme.Models
{
    public class Produto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int produtoID { get; set; }
        public String nome { get; set; }
        public float valor { get; set; }

        public ICollection<Lance> lances { get; set; }
    }
}