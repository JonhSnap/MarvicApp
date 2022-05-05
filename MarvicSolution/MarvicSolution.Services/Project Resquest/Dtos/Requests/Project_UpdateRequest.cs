using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Request.Project_Resquest.Dtos
{
    public class Project_UpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public EnumAccess Access { get; set; }
        public Guid Id_Lead { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime DateEnd { get; set; }
        public EnumStatus IsStared { get; set; }
        public Guid Id_Updator { get; set; }
        public DateTime UpdateDate { get; set; }

        public Project_UpdateRequest()
        {
            Id = new Guid();
            Name = string.Empty;
            Key = string.Empty;
            Access =  EnumAccess.Public;
            Id_Lead = new Guid();
            DateStarted = new DateTime();
            DateEnd = new DateTime();
            IsStared =  EnumStatus.False;
            Id_Updator = new Guid();
            UpdateDate = new DateTime();
        }
        public Project_UpdateRequest(Guid id, string name, string key, EnumAccess access, Guid id_Lead, DateTime? dateStarted, DateTime dateEnd, EnumStatus isStared, Guid id_Updator, DateTime updateDate)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Access = access;
            Id_Lead = id_Lead;
            DateStarted = dateStarted;
            DateEnd = dateEnd;
            IsStared = isStared;
            Id_Updator = id_Updator;
            UpdateDate = updateDate;
        }
    }
}
