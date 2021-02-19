using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using George_Trab.Models;
using System.Net;
using System.Data.Entity;
using George_Trab.Context;

namespace George_Trab.Controllers
{
    public class CategoriasController : Controller
    {
        public Conexao context = new Conexao();
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c => c.Nome));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria c)
        {
            context.Categorias.Add(c);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Categoria c = context.Categorias.Find(id);
            if (c == null) return HttpNotFound();
            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria c)
        {
            if (ModelState.IsValid)
            {
                context.Entry(c).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }

        public ActionResult Details(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            Categoria c = context.Categorias.Find(id);
            if (c == null) return HttpNotFound();
            return View(c);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            Categoria c = context.Categorias.Find(id);
            if (c == null) return HttpNotFound();
            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria c = context.Categorias.Find(id);
            context.Categorias.Remove(c);
            context.SaveChanges();
            TempData["Message"] = "Categoria " + c.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }

    }
}