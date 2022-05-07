using MarvicSolution.DATA.Enums;
using System;

namespace MarvicSolution.DATA.Entities
{
    public class Sprint
    {
        public Sprint()
        {
        }

        public Sprint(Guid id_Project, string sprintName, Guid id_Creator)
        {
            Id_Project = id_Project;
            SprintName = sprintName;
            Id_Creator = id_Creator;
            Create_Date = DateTime.Now;;
            Is_Delete = EnumStatus.False;
        }

        public Guid Id { get; set; }
        public Guid Id_Project { get; set; }
        public string SprintName { get; set; }
        public Guid Id_Creator { get; set; }
        public DateTime Update_Date { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime End_Date { get; set; }
        public DateTime Start_Date { get; set; }
        public EnumStatus Is_Delete { get; set; }
    }
}
