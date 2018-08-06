using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Persistance.Configuration
{
    public class TarefaUsuarioConfiguration : IEntityTypeConfiguration<TarefaUsuario>

    {
        public void Configure(EntityTypeBuilder<TarefaUsuario> builder)
        {
            //chave composta
            builder.HasKey(tarefaUsuario => new {tarefaUsuario.UsuarioId,tarefaUsuario.TarefaId});

            //builder.Property(tarefaUsuario => tarefaUsuario.Id).ValueGeneratedOnAdd();

            builder.Property(tarefaUsuario => tarefaUsuario.UsuarioId).IsRequired();
            builder.Property(tarefaUsuario => tarefaUsuario.TarefaId).IsRequired();

            builder.Property(tarefaUsuario => tarefaUsuario.ComentarioAvaliacao).HasMaxLength(250);
            builder.Property(tarefaUsuario => tarefaUsuario.DataDaTarefa).IsRequired();
            builder.Property(tarefaUsuario => tarefaUsuario.PrevisaoDeConclusao).IsRequired();

            //nao sei se ta certo
            builder.HasOne(x => x.Tarefa)
                .WithMany(x => x.TarefaUsuarios)
                .HasForeignKey(x => x.TarefaId)
                .IsRequired();

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.TarefaUsuarios)
                .HasForeignKey(x => x.UsuarioId)
                .IsRequired();

        }
    }
}
