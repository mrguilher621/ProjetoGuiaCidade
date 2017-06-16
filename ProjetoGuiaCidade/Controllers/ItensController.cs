using ProjetoGuiaCidade.Contexts;
using ProjetoGuiaCidade.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjetoGuiaCidade.Controllers
{
    public class ItensController : Controller
    {
        private EFContext context = new EFContext();

        // GET: Itens
        public ActionResult Index()
        {
            return View(context.Item.OrderBy(i => i.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        public ActionResult Create(Item item)
        {
            context.Item.Add(item);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Details(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = context.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);

        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = context.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);

        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = context.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Categorias/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Item item = context.Item.Find(id);
            context.Item.Remove(item);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}