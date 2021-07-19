using AppGerenciamentoFrota.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppGerenciamentoFrota.Infra
{
    public partial class GerenciamentoFrotaContext : DbContext
    {
        public virtual DbSet<Veiculo> Veiculo {get;set;}

        public GerenciamentoFrotaContext(DbContextOptions<GerenciamentoFrotaContext> options) : base(options)
        {

        }
       
    }
}
