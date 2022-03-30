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
    class App_Role_Configurations : IEntityTypeConfiguration<App_Role>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<App_Role> builder)
        {
            builder.ToTable("App_Role");
            builder.HasKey(o => new { o.Id });

            // Data Seeding
            builder.HasData(
                new App_Role
                {
                    Id = new Guid("EA586555-AF1D-4536-9E8C-29F00ADEF527"),
                    Name = "Project Manager",
                    Creator = "KhanhND",
                    DateCreated = DateTime.Now,
                    Updator = "KhanhND",
                    UpdateDate = DateTime.Now,
                    IsDeleted = Enums.EnumStatus.False
                },
                new App_Role
                {
                    Id = new Guid("A31BFD28-35FA-419A-B03F-FE687112DC5C"),
                    Name = "Member",
                    Creator = "KhanhND",
                    DateCreated = DateTime.Now,
                    Updator = "KhanhND",
                    UpdateDate = DateTime.Now,
                    IsDeleted = Enums.EnumStatus.False
                },
                new App_Role
                {
                    Id = new Guid("0BD0E4CD-9A05-4588-A75F-1625492156B3"),
                    Name = "Viewer",
                    Creator = "KhanhND",
                    DateCreated = DateTime.Now,
                    Updator = "KhanhND",
                    UpdateDate = DateTime.Now,
                    IsDeleted = Enums.EnumStatus.False
                }
                );
        }
    }
}
