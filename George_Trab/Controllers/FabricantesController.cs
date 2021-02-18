
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using George_Trab.Context;
using George_Trab.Models;
using System.Data.Entity;

namespace George_Trab.Controllers
{
    public class FabricantesController : Controller
    {
        public Conexao context = new Conexao();
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c => c.Nome));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fabricante f)
        {
            context.Fabricantes.Add(f);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            Fabricante f = context.Fabricantes.Find(id);
            if (f == null) return HttpNotFound();
            return View(f);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fabricante f)
        {
            if (ModelState.IsValid)
            {
                context.Entry(f).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(f);
        }

        public ActionResult Details(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            Fabricante f = context.Fabricantes.Find(id);
            if (f == null) return HttpNotFound();
            return View(f);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            Fabricante f = context.Fabricantes.Find(id);
            if (f == null) return HttpNotFound();
            return View(f);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Fabricante f = context.Fabricantes.Find(id);
            context.Fabricantes.Remove(f);
            context.SaveChanges();
            TempData["Message"] = "Fabricante " + f.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }
    }
}