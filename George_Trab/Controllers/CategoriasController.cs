using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using George_Trab.Models;

namespace George_Trab.Controllers
{
    public class CategoriasController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria() { CategoriaId = 1, Nome = "Notebooks"},
            new Categoria() { CategoriaId = 2, Nome = "Monitores"},
            new Categoria() { CategoriaId = 3, Nome = "Impressoras"},
            new Categoria() { CategoriaId = 4, Nome = "Mouses"},
            new Categoria() { CategoriaId = 5, Nome = "Desktops"}
        };

        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria c)
        {
            categorias.Add(c);
            c.CategoriaId = categorias.Select(m => m.CategoriaId).Max();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria c)
        {
            categorias.Remove(categorias.Where(m => m.CategoriaId == c.CategoriaId).First());
            categorias.Add(c);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(categorias.Where(m => m.CategoriaId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria c)
        {
            categorias.Remove(categorias.Where(m => m.CategoriaId == c.CategoriaId).First());
            return RedirectToAction("Index");
        }

    }
}