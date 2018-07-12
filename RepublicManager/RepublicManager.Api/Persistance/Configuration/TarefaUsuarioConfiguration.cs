using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Persistance.Configuration
{
    public class TarefaUsuarioConfiguration : IEntityTypeConfiguration<TarefaUsuario>

    {
        public void Configure(EntityTypeBuilder<TarefaUsuario> builder)
        {
            builder.HasKey(tarefaUsuario => tarefaUsuario.Id);
            builder.Property(x => x.UsuarioId)
                .IsRequired();
            builder.Property(x => x.TarefaId).IsRequired();
            builder.Property(x => x.ComentarioAvaliacao).HasMaxLength(250);
            builder.Property(x => x.DataDaTarefa).IsRequired();
            builder.Property(x => x.PrevisaoDeConclusao).IsRequired();

        }
    }
}
