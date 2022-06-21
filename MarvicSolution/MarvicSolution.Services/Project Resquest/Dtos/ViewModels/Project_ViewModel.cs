using MarvicSolution.DATA.Enums;
using System;

namespace MarvicSolution.Services.Project_Request.Project_Resquest.Dtos.ViewModels
{
    public class Project_ViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public EnumAccess Access { get; set; }
        public string Lead { get; set; }
        public Guid Id_Creator { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnd { get; set; }

        public Guid Id_Updator { get; set; }
        public DateTime? UpdateDate { get; set; }
        public EnumStatus IsStared { get; set; }
        public EnumStatus IsDeleted { get; set; }

        public Project_ViewModel()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            Key = string.Empty;
            Access = EnumAccess.Public;
            Lead = string.Empty;
            Id_Creator = Guid.Empty;
            DateCreated = new DateTime();
            DateStarted = new DateTime();
            DateEnd = new DateTime();
            Id_Updator = Guid.Empty;
            UpdateDate = new DateTime();
            IsStared = EnumStatus.False;
            IsDeleted = EnumStatus.False;
        }

        public Project_ViewModel(Guid id, string name, string key, EnumAccess access, string lead, Guid id_Creator, DateTime dateCreated, DateTime? dateStarted, DateTime? dateEnd, Guid id_Updator, DateTime? updateDate, EnumStatus isStared, EnumStatus isDeleted)
        {
            Id = id;
            Name = name;
            Key = key;
            Access = access;
            Lead = lead;
            Id_Creator = id_Creator;
            DateCreated = dateCreated;
            DateStarted = dateStarted;
            DateEnd = dateEnd;
            Id_Updator = id_Updator;
            UpdateDate = updateDate;
            IsStared = isStared;
            IsDeleted = isDeleted;
        }
    }
}
