using MarvicSolution.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Configurations
{
    class ProjectType_Configurations : IEntityTypeConfiguration<ProjectType>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ProjectType> builder)
        {
            builder.ToTable("ProjectType");
            builder.HasKey(o => new { o.Id });

            // Data Seeding
            builder.HasData(
                new ProjectType
                {
                    Id = new Guid("77B88991-F823-4301-B452-1B14CA44D5CB"),
                    Creator = "User A",
                    Name = "Marketing",
                    Updator = "User A_Update",
                    UpdateDate = DateTime.Parse("2022-9-1")
                },
                new ProjectType
                {
                    Id = new Guid("21C68955-EA3E-4B41-8EC5-EF816C912F1A"),
                    Creator = "User B",
                    Name = "Development Program",
                    Updator = "User B_Update",
                    UpdateDate = DateTime.Parse("2021-10-15")
                },
                new ProjectType
                {
                    Id = new Guid("CC6C38BE-7461-4F0C-B3DD-722477375D61"),
                    Creator = "User C",
                    Name = "Accounting",
                    Updator = "User C_Update",
                    UpdateDate = DateTime.Parse("2015-5-20")
                }
            );
        }
    }
}
