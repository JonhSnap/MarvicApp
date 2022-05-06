using MarvicSolution.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvicSolution.DATA.Configurations
{
    class Lablel_Configurations : IEntityTypeConfiguration<Label>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Label> builder)
        {
            builder.ToTable("Label");
            builder.HasKey(o => new { o.Id });
            builder.Property(prop => prop.Id_Project).IsRequired();
            builder.Property(prop => prop.Id_Creator).IsRequired();
            builder.Property(prop => prop.Name).IsRequired();
        }
    }
}
