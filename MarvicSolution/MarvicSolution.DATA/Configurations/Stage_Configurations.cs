using MarvicSolution.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarvicSolution.DATA.Configurations
{
    class Stage_Configurations : IEntityTypeConfiguration<Stage>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Stage> builder)
        {
            builder.ToTable("Stage");
            builder.HasKey(o => new { o.Id });
            builder.Property(prop => prop.Id_Project).IsRequired();
            builder.Property(prop => prop.Id_Creator).IsRequired();
            builder.Property(prop => prop.Stage_Name).IsRequired();
        }
    }
}
