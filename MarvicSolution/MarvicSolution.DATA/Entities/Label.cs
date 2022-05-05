using MarvicSolution.DATA.Enums;
using System;

namespace MarvicSolution.DATA.Entities
{
    public class Label
    {
        public Label(Guid id_Project, string name, Guid id_Creator)
        {
            Id_Project = id_Project;
            Name = name;
            Id_Creator = id_Creator;
            DateCreated = DateTime.Now;
        }

        public Guid Id { get; set; }
        public Guid Id_Project { get; set; }
        public string Name { get; set; }
        public Guid Id_Creator { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime UpdateDate { get; set; }
        public Guid Id_Updator { get; set; }
        public EnumStatus isDeleted { get; set; }
    }
}
