using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Persistance.Configuration
{
    public class TarefaUsuarioConfiguration : IEntityTypeConfiguration<Tarefa>

    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(tarefaUsuario => tarefaUsuario.Id);
        }
    }
}
