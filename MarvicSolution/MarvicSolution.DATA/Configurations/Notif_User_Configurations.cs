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
    class Notif_User_Configurations : IEntityTypeConfiguration<Notif_User>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Notif_User> builder)
        {
            builder.ToTable("Notif_User");


            // Data Seeding
            builder.HasData(
                new Notif_User()
                {
                    Id = new Guid("29D3D4E2-46AE-4257-9A95-FDE99546F53C"),
                    IdNotif = new Guid("3F5F79B2-27C2-45E1-842C-71811F9C8260"),
                    IdUser = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"),
                    IsView = EnumStatus.True
                },
                new Notif_User()
                {
                    Id = new Guid("565E5866-90F8-4960-B36B-F2D6F6C0D7F2"),
                    IdNotif = new Guid("20647F78-5EED-43BC-AC09-FCEBD546D2CE"),
                    IdUser = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("BEA2D6F1-B734-440F-900B-95A33F2CDEE3"),
                    IdNotif = new Guid("3F5F79B2-27C2-45E1-842C-71811F9C8260"),
                    IdUser = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"),
                    IsView = EnumStatus.True
                },
                new Notif_User()
                {
                    Id = new Guid("C67AAD9F-B67F-43B8-AA51-435BE6EEAE73"),
                    IdNotif = new Guid("20647F78-5EED-43BC-AC09-FCEBD546D2CE"),
                    IdUser = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"),
                    IsView = EnumStatus.False
                },
                new Notif_User()
                {
                    Id = new Guid("85505ECF-F765-43E7-BC5C-85BCCE8457A9"),
                    IdNotif = new Guid("3F5F79B2-27C2-45E1-842C-71811F9C8260"),
                    IdUser = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"),
                    IsView = EnumStatus.True
                },
                new Notif_User()
                {
                    Id = new Guid("1200DE61-ECCF-4389-91AC-613BA5CC1594"),
                    IdNotif = new Guid("20647F78-5EED-43BC-AC09-FCEBD546D2CE"),
                    IdUser = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"),
                    IsView = EnumStatus.False
                }
                );
        }
    }
}
