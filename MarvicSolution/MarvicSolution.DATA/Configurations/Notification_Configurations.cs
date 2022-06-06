using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Configurations
{
    class Notification_Configurations : IEntityTypeConfiguration<Notifications>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Notifications> builder)
        {
            builder.ToTable("Notifications");
            builder.HasKey(o => new { o.Id });

            // Data Seeding
            builder.HasData(
                new Notifications()
                {
                    Id = new Guid("3F5F79B2-27C2-45E1-842C-71811F9C8260"),
                    IdItemRef = new Guid("EDFF3F58-7640-4F5A-ADA0-DC017F602501"),
                    Date = DateTime.Parse("2022-6-3"),
                    Message = "Mr.A has create task A1.1"
                }, new Notifications()
                {
                    Id = new Guid("20647F78-5EED-43BC-AC09-FCEBD546D2CE"),
                    IdItemRef = new Guid("DF2E4C8C-36D7-4448-96FC-5FE36363E1D6"),
                    Date = DateTime.Parse("2022-6-2"),
                    Message = "Mr.B has update Task A1.2"
                }
                );
        }
    }
}
