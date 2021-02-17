using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using George_Trab.Models;

namespace George_Trab.Context
{
    public class Conexao : DbContext
    {
        public Conexao() : base("Asp_Net_MVC_CS") {}
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
    }
}