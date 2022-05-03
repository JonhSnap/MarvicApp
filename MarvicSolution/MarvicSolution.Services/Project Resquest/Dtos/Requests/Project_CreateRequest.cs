using MarvicSolution.DATA.Common;
using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Request.Project_Resquest.Dtos
{
    public class Project_CreateRequest
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public EnumAccess Access { get; set; }
        
        public Guid Id_Lead { get; set; }
        public Guid Id_Creator { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateEnd { get; set; }

        public Project_CreateRequest()
        {
            Name = string.Empty;
            Key = string.Empty;
            Access = EnumAccess.Public;
            Id_Lead = Guid.Empty;
            Id_Creator = Guid.Empty;
            DateStarted = new DateTime();
            DateEnd = new DateTime();
        }

        public Project_CreateRequest(string name, string key, EnumAccess access, Guid id_Lead, Guid id_Creator, DateTime dateStarted, DateTime dateEnd)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Access = access;
            Id_Lead = id_Lead;
            Id_Creator = id_Creator;
            DateStarted = dateStarted;
            DateEnd = dateEnd;
        }
    }
}
