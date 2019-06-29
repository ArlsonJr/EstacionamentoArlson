using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EstacionamentoArlson.Models;

namespace EstacionamentoArlson.Controllers
{
    public class EstacionamentoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Estacionamentoes
        public ActionResult Index()
        {
            var estacionamento = db.Estacionamento.Include(e => e.Preco);
            return View(estacionamento.ToList());
        }

        // GET: Estacionamentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamento estacionamento = db.Estacionamento.Find(id);
            if (estacionamento == null)
            {
                return HttpNotFound();
            }
            return View(estacionamento);
        }

        // GET: Estacionamentoes/Create
        public ActionResult Create()
        {
            ViewBag.IdPreco = new SelectList(db.Preco, "CodigoPreco", "CodigoPreco");
            return View();
        }

        // POST: Estacionamentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoEstacionamento,Placa,TempoCobrado,ValorTotal,Entrada,Saida,IdPreco")] Estacionamento estacionamento)
        {
            if (ModelState.IsValid)
            {
                db.Estacionamento.Add(estacionamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPreco = new SelectList(db.Preco, "CodigoPreco", "CodigoPreco", estacionamento.IdPreco);
            return View(estacionamento);
        }

        // GET: Estacionamentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamento estacionamento = db.Estacionamento.Find(id);
            if (estacionamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPreco = new SelectList(db.Preco, "CodigoPreco", "CodigoPreco", estacionamento.IdPreco);
            return View(estacionamento);
        }

        // POST: Estacionamentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoEstacionamento,Placa,TempoCobrado,ValorTotal,Entrada,Saida,IdPreco")] Estacionamento estacionamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estacionamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPreco = new SelectList(db.Preco, "CodigoPreco", "CodigoPreco", estacionamento.IdPreco);
            return View(estacionamento);
        }

        // GET: Estacionamentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estacionamento estacionamento = db.Estacionamento.Find(id);
            if (estacionamento == null)
            {
                return HttpNotFound();
            }
            return View(estacionamento);
        }

        // POST: Estacionamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estacionamento estacionamento = db.Estacionamento.Find(id);
            db.Estacionamento.Remove(estacionamento);
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
