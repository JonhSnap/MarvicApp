using MarvicSolution.DATA.Enums;
using System;

namespace MarvicSolution.Services.Sprint_Request.ViewModels
{
    public class SprintVM
    {
        public SprintVM(Guid id, Guid id_Project, string sprintName, Guid id_Creator,
            DateTime update_Date, DateTime create_Date, DateTime start_Date, DateTime end_Date, EnumStatus is_Archieved, EnumStatus is_Started)
        {
            Id = id;
            Id_Project = id_Project;
            SprintName = sprintName;
            Id_Creator = id_Creator;
            Update_Date = update_Date.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            Create_Date = create_Date.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            End_Date = end_Date.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            Start_Date = start_Date.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            Is_Archieved = is_Archieved;
            Is_Started = is_Started;
        }

        public Guid Id { get; set; }
        public Guid Id_Project { get; set; }
        public string SprintName { get; set; }
        public Guid Id_Creator { get; set; }
        public string Update_Date { get; set; }
        public string Create_Date { get; set; }
        public string End_Date { get; set; }
        public string Start_Date { get; set; }
        public EnumStatus Is_Archieved { get; set; }
        public EnumStatus Is_Started { get; set; }
    }
}
