﻿using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using static MarvicSolution.DATA.Common.Constant;

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

            builder.HasData(
            #region Project ABC
                new Stage()
                {
                    Id = new Guid("D72506EB-AD2A-48D5-8CAA-D322EE88811F"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Stage_Name = StageName.TODO,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    DateCreated = DateTime.Parse("2022-4-22"),
                    UpdateDate = new DateTime(),
                    Id_Updator = Guid.Empty,
                    Order = 0,
                    isDone = EnumStatus.False,
                    isDeleted = EnumStatus.False,
                    isDefault = EnumStatus.True
                }, new Stage()
                {
                    Id = new Guid("0CAA0071-7E46-48F8-B436-382001C1CA3A"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Stage_Name = StageName.INPROGRESS,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    DateCreated = DateTime.Parse("2022-4-22"),
                    UpdateDate = new DateTime(),
                    Id_Updator = Guid.Empty,
                    Order = 1,
                    isDone = EnumStatus.False,
                    isDeleted = EnumStatus.False,
                    isDefault = EnumStatus.False
                }, new Stage()
                {
                    Id = new Guid("DA3D7685-BB11-4681-B7F3-FFBC9ED54353"),
                    Id_Project = new Guid("A42B223B-FAEC-48E3-8E28-51FE1B22FA7C"), // Project ABC
                    Stage_Name = StageName.DONE,
                    Id_Creator = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"), // KhietPT
                    DateCreated = DateTime.Parse("2022-4-22"),
                    UpdateDate = new DateTime(),
                    Id_Updator = Guid.Empty,
                    Order = 2,
                    isDone = EnumStatus.True,
                    isDeleted = EnumStatus.False,
                    isDefault = EnumStatus.False
                }
                #endregion
            );
        }
    }
}
