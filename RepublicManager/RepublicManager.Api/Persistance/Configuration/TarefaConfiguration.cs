using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Persistance.Configuration
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(tarefa => tarefa.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Descricao).HasMaxLength(150);
        }
    }
}
