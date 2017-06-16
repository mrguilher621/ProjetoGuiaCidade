using ProjetoGuiaCidade.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoGuiaCidade.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Banco") { }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}