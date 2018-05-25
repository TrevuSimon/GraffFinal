using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GraffLeilaoGuilherme.DAL;
using GraffLeilaoGuilherme.Models;

namespace GraffLeilaoGuilherme.Controllers
{
    public class LancesController : Controller
    {
        private LeilaoContext db = new LeilaoContext();

        // GET: Lances
        public ActionResult Index(String TextBox1)
        {
            if(TextBox1 != null)
            {
                try
                {
                    ViewBag.valorMax = db.Lances.Max(p => p.lanceValor);
                }
                catch
                {

                }
                ViewBag.Error = TempData["error"];
                var lances = db.Lances.Where(l => l.pessoa.nome.Contains(TextBox1)).Include(l => l.pessoa).Include(l => l.produto).ToList();
                return View(lances);
            }
            else
            {
                try
                {
                    ViewBag.valorMax = db.Lances.Max(p => p.lanceValor);
                }
                catch
                {

                }
                 
                ViewBag.Error = TempData["error"];
                var lances = db.Lances.Include(l => l.pessoa).Include(l => l.produto);
                return View(lances.ToList());
            }
            

        }



        // GET: Lances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lance lance = db.Lances.Find(id);
            lance.pessoa = db.Pessoas.Find(lance.pessoaID);
            lance.produto = db.Produtos.Find(lance.produtoID);
            if (lance == null)
            {
                return HttpNotFound();
            }
            return View(lance);
        }

        public void CreateViewBag(int? id)
        {
            ViewBag.valorMax = db.Lances.Where(p => p.produtoID == id).Select(c => c.lanceValor).DefaultIfEmpty(0).Max();
            var nome = db.Produtos.Where(a => a.produtoID == id).Select(a => a.nome).FirstOrDefault<String>();
            var valor = db.Produtos.Where(a => a.produtoID == id).Select(a => a.valor).FirstOrDefault<float>();
            ViewBag.nomeProduto = nome;
            ViewBag.valorProduto = valor;
            ViewBag.idValue = id;
        }

        // GET: Lances/Create
        public ActionResult Create(int? id)
        {
            CreateViewBag(id);


            ViewBag.pessoaID = new SelectList(db.Pessoas, "pessoaID", "nome");
            ViewBag.produtoID = new SelectList(db.Produtos, "produtoID", "nome",id);

            return View();
        }

        // POST: Lances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lanceID,pessoaID,produtoID,lanceValor")] Lance lance, int? id)
        {
            CreateViewBag(id);

            if (ModelState.IsValid)
            {
                db.Lances.Add(lance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pessoaID = new SelectList(db.Pessoas, "pessoaID", "nome", lance.pessoaID);
            ViewBag.produtoID = new SelectList(db.Produtos, "produtoID", "nome", lance.produtoID);

            return View(lance);
        }

        // GET: Lances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lance lance = db.Lances.Find(id);
            if (lance == null)
            {
                return HttpNotFound();
            }
            ViewBag.pessoaID = new SelectList(db.Pessoas, "pessoaID", "nome", lance.pessoaID);
            ViewBag.produtoID = new SelectList(db.Produtos, "produtoID", "nome", lance.produtoID);
            return View(lance);
        }

        // POST: Lances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lanceID,pessoaID,produtoID,lanceValor")] Lance lance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pessoaID = new SelectList(db.Pessoas, "pessoaID", "nome", lance.pessoaID);
            ViewBag.produtoID = new SelectList(db.Produtos, "produtoID", "nome", lance.produtoID);
            return View(lance);
        }

        // GET: Lances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lance lance = db.Lances.Find(id);
            if (lance == null)
            {
                return HttpNotFound();
            }
            return View(lance);
        }

        // POST: Lances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lance lance = db.Lances.Find(id);
            db.Lances.Remove(lance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
