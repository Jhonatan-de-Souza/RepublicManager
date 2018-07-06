﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RepublicManager.Api.Persistance;
using System;

namespace RepublicManager.Api.Migrations
{
    [DbContext(typeof(RepublicManagerContext))]
    [Migration("20180706015706_RepublicaAlteracao")]
    partial class RepublicaAlteracao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Aviso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataAviso");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("isAtivo");

                    b.HasKey("Id");

                    b.ToTable("Aviso");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.CarrinhoDeCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<int>("RepublicaId");

                    b.Property<bool>("isAtivo");

                    b.HasKey("Id");

                    b.ToTable("CarrinhoDeCompra");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarrinhoDeCompraId");

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("UsuarioId");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("isAtivo");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoDeCompraId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Republica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<string>("Nome");

                    b.Property<int>("Vagas");

                    b.Property<bool>("isAtivo");

                    b.HasKey("Id");

                    b.ToTable("Republica");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataFinalContrato");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<string>("Login");

                    b.Property<string>("Senha");

                    b.Property<bool>("isAtivo");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Produto", b =>
                {
                    b.HasOne("RepublicManager.Api.Core.Domain.CarrinhoDeCompra", "CarrinhoDeCompra")
                        .WithMany("ListaProdutos")
                        .HasForeignKey("CarrinhoDeCompraId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
