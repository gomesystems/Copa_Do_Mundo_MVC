using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Copa_Do_Mundo_MVC.Models
{  /// <summary>
/// /instalar entity, sem internet
/// </summary>
    public class CopaDoMundoContext : DbContext
    {
        public DbSet<Selecao> Selecoes { get; set; } 
        public DbSet<Jogador> Jogadores { get; set; }
    }
}