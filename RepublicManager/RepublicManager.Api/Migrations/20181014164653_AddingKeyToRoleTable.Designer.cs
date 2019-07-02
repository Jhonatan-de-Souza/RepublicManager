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
    [Migration("20181014164653_AddingKeyToRoleTable")]
    partial class AddingKeyToRoleTable
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

                    b.Property<bool>("IsAtivo");

                    b.Property<int>("RepublicaId");

                    b.HasKey("Id");

                    b.HasIndex("RepublicaId");

                    b.ToTable("Aviso");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.CarrinhoDeCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<bool>("IsAtivo");

                    b.Property<int>("RepublicaId");

                    b.HasKey("Id");

                    b.HasIndex("RepublicaId");

                    b.ToTable("CarrinhoDeCompra");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<bool>("IsAtivo");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.ContaAPagar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContaId");

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<bool>("IsAtivo");

                    b.Property<int>("TipoContaId");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.HasIndex("TipoContaId");

                    b.ToTable("ContasAPagar");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.ContaAReceber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContaId");

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<bool>("IsAtivo");

                    b.Property<int>("TipoContaId");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.HasIndex("TipoContaId");

                    b.ToTable("ContasAReceber");
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

                    b.Property<bool>("IsAtivo");

                    b.Property<int>("UsuarioId");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoDeCompraId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Regra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("IsAtivo");

                    b.Property<int>("RepublicaId");

                    b.HasKey("Id");

                    b.HasIndex("RepublicaId");

                    b.ToTable("Regras");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Republica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<bool>("IsAtivo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Vagas");

                    b.HasKey("Id");

                    b.ToTable("Republica");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<string>("Descricao")
                        .HasMaxLength(150);

                    b.Property<bool>("IsAtivo");

                    b.HasKey("Id");

                    b.ToTable("Tarefa");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.TarefaUsuario", b =>
                {
                    b.Property<int>("UsuarioId");

                    b.Property<int>("TarefaId");

                    b.Property<string>("ComentarioAvaliacao")
                        .HasMaxLength(250);

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataDaTarefa");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<bool>("IsAtivo");

                    b.Property<bool>("IsCompleted");

                    b.Property<int>("NotaAvaliacao");

                    b.Property<DateTime>("PrevisaoDeConclusao");

                    b.HasKey("UsuarioId", "TarefaId");

                    b.HasIndex("TarefaId");

                    b.ToTable("TarefasUsuario");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.TipoConta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<string>("Descricao");

                    b.Property<bool>("IsAtivo");

                    b.HasKey("Id");

                    b.ToTable("TipoContas");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContaId");

                    b.Property<int>("CriadoPor");

                    b.Property<DateTime>("DataFinalContrato");

                    b.Property<DateTime>("DataRegistro");

                    b.Property<string>("Email");

                    b.Property<bool>("IsAtivo");

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Nome");

                    b.Property<int?>("RepublicaId");

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RepublicaId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Aviso", b =>
                {
                    b.HasOne("RepublicManager.Api.Core.Domain.Republica", "Republica")
                        .WithMany("Avisos")
                        .HasForeignKey("RepublicaId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.CarrinhoDeCompra", b =>
                {
                    b.HasOne("RepublicManager.Api.Core.Domain.Republica", "Republica")
                        .WithMany("CarrinhosDeCompra")
                        .HasForeignKey("RepublicaId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Conta", b =>
                {
                    b.HasOne("RepublicManager.Api.Core.Domain.Usuario", "Usuario")
                        .WithOne("Conta")
                        .HasForeignKey("RepublicManager.Api.Core.Domain.Conta", "UsuarioId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.ContaAPagar", b =>
                {
                    b.HasOne("RepublicManager.Api.Core.Domain.Conta", "Conta")
                        .WithMany("ContasAPagar")
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("RepublicManager.Api.Core.Domain.TipoConta", "TipoConta")
                        .WithMany()
                        .HasForeignKey("TipoContaId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.ContaAReceber", b =>
                {
                    b.HasOne("RepublicManager.Api.Core.Domain.Conta", "Conta")
                        .WithMany("ContasAReceber")
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("RepublicManager.Api.Core.Domain.TipoConta", "TipoConta")
                        .WithMany()
                        .HasForeignKey("TipoContaId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Produto", b =>
                {
                    b.HasOne("RepublicManager.Api.Core.Domain.CarrinhoDeCompra", "CarrinhoDeCompra")
                        .WithMany("Produtos")
                        .HasForeignKey("CarrinhoDeCompraId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Regra", b =>
                {
                    b.HasOne("RepublicManager.Api.Core.Domain.Republica", "Republica")
                        .WithMany("Regras")
                        .HasForeignKey("RepublicaId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.TarefaUsuario", b =>
                {
                    b.HasOne("RepublicManager.Api.Core.Domain.Tarefa", "Tarefa")
                        .WithMany("TarefaUsuarios")
                        .HasForeignKey("TarefaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("RepublicManager.Api.Core.Domain.Usuario", "Usuario")
                        .WithMany("TarefaUsuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("RepublicManager.Api.Core.Domain.Usuario", b =>
                {
                    b.HasOne("RepublicManager.Api.Core.Domain.Republica", "Republica")
                        .WithMany("Usuarios")
                        .HasForeignKey("RepublicaId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}