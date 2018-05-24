using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraffLeilaoGuilherme.Models
{
    public class Pessoa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int pessoaID { get; set; }
        public String nome { get; set; }
        public int idade { get; set; }

        public ICollection<Lance> lances { get; set; }
    }
}