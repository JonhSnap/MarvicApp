using MarvicSolution.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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
                    Message = "Mr.A has create task A1.1",
                    IsIssue = 1,
                    IsProject = 0
                }, new Notifications()
                {
                    Id = new Guid("20647F78-5EED-43BC-AC09-FCEBD546D2CE"),
                    IdItemRef = new Guid("DF2E4C8C-36D7-4448-96FC-5FE36363E1D6"),
                    Date = DateTime.Parse("2022-6-2"),
                    Message = "Mr.B has update Task A1.2",
                    IsIssue = 1,
                    IsProject = 0
                },
                //////////////////////// thay đổi message lại sau nên từ từ làm tiếp
                new Notifications()
                {
                    Id = new Guid("5e8a29d7-d221-46cf-8c75-1e87935647d5"),
                    IdItemRef = new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"),
                    Date = DateTime.Parse("2022-07-03"),
                    Message = "KhietPT has been started Sprint Sprint A1 in Project Project ABC",
                    IsIssue = 0,
                    IsProject =  1
                }, new Notifications()
                {
                    Id = new Guid("b5398d9d-f910-4e6e-af3e-1ed6ca8f0ccf"),
                    IdItemRef = new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"),
                    Date = DateTime.Parse("2022-07-03"),
                    Message = "KhietPT has been complete Sprint Sprint 1 in Project Project ABC",
                    IsIssue = 0,
                    IsProject = 1
                }, new Notifications()
                {
                    Id = new Guid("45a5903e-08b9-4495-9e78-2266f6b48ac0"),
                    IdItemRef = new Guid("4b9a6895-4467-453e-8915-5ed19312fb54"),
                    Date = DateTime.Parse("2022-07-03"),
                    Message = "KhietPT has been changed issue The Task Legendary A1.8 to DONE",
                    IsIssue = 1,
                    IsProject = 0
                }
                );
        }
    }
}
