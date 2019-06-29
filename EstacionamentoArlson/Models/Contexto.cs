using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EstacionamentoArlson.Models
{
    public class Contexto : DbContext
    {
        public Contexto() : base("EstacionamentoArlson")
        {
            Database.Log = instrucao => Debug.WriteLine(instrucao);
        }

        public DbSet<Estacionamento> Estacionamento { get; set; }
        public DbSet<Preco> Preco { get; set; }
    }
}