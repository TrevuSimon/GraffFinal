using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GraffLeilaoGuilherme.Models;

namespace GraffLeilaoGuilherme.DAL
{
    public class LeilaoInitializer :System.Data.Entity.DropCreateDatabaseIfModelChanges<LeilaoContext>
    {
        protected override void Seed(LeilaoContext context)
        {
            var pessoas = new List<Pessoa>
            {
                new Pessoa{pessoaID=0,nome="Joao",idade=18},
                new Pessoa{pessoaID=1,nome="Maria",idade=25},
                new Pessoa{pessoaID=2,nome="Jose",idade=23},
            };

            pessoas.ForEach(s => context.Pessoas.Add(s));
            context.SaveChanges();

            var produtos = new List<Produto>
            {
                new Produto{produtoID=0,nome="Relogio",valor=100},
                new Produto{produtoID=1,nome="Celular",valor=500}
            };

            produtos.ForEach(s => context.Produtos.Add(s));
            context.SaveChanges();

        }
    }
}