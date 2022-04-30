using MarvicSolution.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvicSolution.DATA.Configurations
{
    class Sprint_Configurations : IEntityTypeConfiguration<Sprint>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Sprint> builder)
        {
            builder.ToTable("Sprint");
            builder.HasKey(o => new { o.Id });
            builder.Property(prop => prop.Id_Project).IsRequired();
            builder.Property(prop => prop.SprintName).IsRequired();
        }
    }
}
