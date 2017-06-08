using ProjetoGuiaCidade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoGuiaCidade.Controllers
{
    public class CategoriasController : Controller
    {
        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria()
            {
                CategoriaId = 1,
                Titulo_Categoria = "Restaurantes"
            },

            new Categoria()
            {
                CategoriaId = 2,
                Titulo_Categoria = "Bares"
            }

        };
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(long id)
        {
            return View(categorias.Where(c => c.CategoriaId == id).First());
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            categorias.Add(categoria);
            categoria.CategoriaId = categorias.Select(c => c.CategoriaId).Max() + 1;
            return RedirectToAction("Index");
            
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(long id)
        {
            return View(categorias.Where(c => c.CategoriaId == id).First());
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria )
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(long id)
        {
            return View(categorias.Where(c => c.CategoriaId == id).First());
        }

        // POST: Categorias/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Categoria categoria)
        {
            categorias.Remove(categorias.Where(c => c.CategoriaId == categoria.CategoriaId).First());
            return RedirectToAction("Index");
        }
    }
}
