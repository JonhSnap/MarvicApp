﻿using MarvicSolution.DATA.Enums;
using System;

namespace MarvicSolution.Services.Stage_Request.ViewModels
{
    public class StageVM
    {
        public StageVM() { }
        public StageVM(Guid id, Guid id_Project, string stage_Name,
            Guid id_Creator, DateTime dateCreated, DateTime updateDate, Guid id_Updator, int order,EnumStatus isDone, EnumStatus isDefault)
        {
            Id = id;
            Id_Project = id_Project;
            Stage_Name = stage_Name;
            Id_Creator = id_Creator;
            DateCreated = dateCreated.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            UpdateDate = updateDate.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            Id_Updator = id_Updator;
            Order = order;
            IsDone = isDone;
            IsDefault = isDefault;
        }

        public Guid Id { get; set; }
        public Guid Id_Project { get; set; }
        public string Stage_Name { get; set; }
        public Guid Id_Creator { get; set; }
        public string DateCreated { get; set; }
        public string UpdateDate { get; set; }
        public Guid Id_Updator { get; set; }
        public int Order { get; set; }
        public EnumStatus IsDone { get; set; }
        public EnumStatus IsDefault { get; set; }

    }
}
