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
        public Stage(Guid id_Project, string stage_Name, Guid id_Creator)
        {
            Id_Project = id_Project;
            Stage_Name = stage_Name;
            Id_Creator = id_Creator;
            Order = 0;
            DateCreated = DateTime.Now;
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
    }
}
