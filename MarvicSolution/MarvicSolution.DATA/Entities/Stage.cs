using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.Enums;
using System;

namespace MarvicSolution.DATA.Entities
{
    public class Stage
    {
        public Stage()
        {
            this.Id = Guid.Empty;
            this.Id_Project = Guid.Empty;
            this.Stage_Name = string.Empty;
            this.Id_Creator = Guid.Empty;
            this.DateCreated = new DateTime();
            this.UpdateDate = new DateTime();
            this.Order = 0;
            this.Id_Updator = Guid.Empty;
            this.isDeleted = EnumStatus.False;
        }
        public Stage(Guid id_Project, string stage_Name, Guid id_Creator, int order,EnumStatus IsDone = EnumStatus.False, EnumStatus IsDefault = EnumStatus.False)
        {
            Id_Project = id_Project;
            Stage_Name = stage_Name;
            Id_Creator = id_Creator;
            Order = order;
            isDefault = IsDefault;
            DateCreated = DateTime.Now;
            isDone = IsDone;
        }


        public Guid Id { get; set; }
        public Guid Id_Project { get; set; }
        public string Stage_Name { get; set; }
        public Guid Id_Creator { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid Id_Updator { get; set; }
        public int Order { get; set; }
        public EnumStatus isDeleted { get; set; }
        public EnumStatus isDone { get; set; }
        public EnumStatus isDefault { get; set; }
    }
}