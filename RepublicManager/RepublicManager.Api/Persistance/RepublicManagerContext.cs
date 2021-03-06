﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Persistance.Configuration;

namespace RepublicManager.Api.Persistance
{
    public class RepublicManagerContext : DbContext
    {
        public RepublicManagerContext(DbContextOptions<RepublicManagerContext> options)
            : base(options)
        {
                
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.SetNull;
            }

            modelBuilder.ApplyConfiguration(new RepublicaConfiguration());
            modelBuilder.ApplyConfiguration(new AvisosConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new CarrinhoDeCompraConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new TarefaConfiguration());
            modelBuilder.ApplyConfiguration(new TarefaUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new RegraConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioRoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
        public DbSet<Aviso> Aviso { get; set; }
        public DbSet<Republica> Republica { get; set; }
        public DbSet<CarrinhoDeCompra> CarrinhoDeCompra { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<TarefaUsuario> TarefasUsuario { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<ContaAPagar> ContasAPagar { get; set; }
        public DbSet<ContaAReceber> ContasAReceber { get; set; }
        public DbSet<TipoConta> TipoContas { get; set; }
        public DbSet<Regra> Regras { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsuarioRole> UsuarioRoles { get; set; }
    }
}