﻿using ProjetoGuiaCidade.Contexts;
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
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext();
      
        // GET: Categorias
        public ActionResult Index()
        {
            return View(context.Categoria.OrderBy(c => c.Titulo_Categoria));
        }

        // GET: Categorias/Details/5
        public ActionResult Details(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);

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
            context.Categoria.Add(categoria);
            context.SaveChanges();  
            return RedirectToAction("Index");
            
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categoria.Find(id);
            if(categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria )
        {
            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
           
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(long? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria categoria = context.Categoria.Find(id);
            context.Categoria.Remove(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
