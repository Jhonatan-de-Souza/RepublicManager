using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Persistance.Configuration
{
    public class UsuarioRoleConfiguration :IEntityTypeConfiguration<UsuarioRole>
    {
        public void Configure(EntityTypeBuilder<UsuarioRole> builder)
        {
            builder
                .ToTable("UsuarioRole");

            builder
                .HasKey(usuarioRole => new { usuarioRole.RoleId, usuarioRole.UsuarioId });

            builder
                .HasOne(usuarioRole => usuarioRole.Usuario)
                .WithMany(usuario => usuario.Roles)
                .HasForeignKey(usuarioRole => usuarioRole.UsuarioId);

            builder
                .HasOne(usuarioRole => usuarioRole.Role)
                .WithMany(role => role.Usuarios)
                .HasForeignKey(usuarioRole => usuarioRole.RoleId);
        }
    }
}
