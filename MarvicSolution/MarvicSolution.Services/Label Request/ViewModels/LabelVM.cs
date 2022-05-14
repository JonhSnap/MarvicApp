using System;

namespace MarvicSolution.Services.Label_Request.ViewModels
{
    public class LabelVM
    {
        public LabelVM(Guid id, Guid id_Project, string name,
            Guid id_Creator, DateTime dateCreated, DateTime updateDate, Guid id_Updator)
        {
            Id = id;
            Id_Project = id_Project;
            Name = name;
            Id_Creator = id_Creator;
            Update_Date = dateCreated.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            Create_Date = updateDate.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            Id_Updator = id_Updator;
        }
        public Guid Id { get; set; }
        public Guid Id_Project { get; set; }
        public string Name { get; set; }
        public Guid Id_Creator { get; set; }
        public string Update_Date { get; set; }
        public string Create_Date { get; set; }
        public Guid Id_Updator { get; set; }

    }
}
