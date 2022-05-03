using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public EnumAccess Access { get; set; }
        public Guid Id_Lead { get; set; }
        public Guid Id_Creator { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnd { get; set; }

        public Guid Id_Updator { get; set; }
        public DateTime? UpdateDate { get; set; }
        public EnumStatus IsStared { get; set; }
        public EnumStatus IsDeleted { get; set; }

        public Project()
        {
            this.Id = Guid.NewGuid();
            this.Name = "";
            this.Key = "";
            this.Access = EnumAccess.Public;
            this.Id_Lead = Guid.Empty;
            this.Id_Creator = Guid.Empty;
            this.DateCreated = new DateTime();
            this.DateStarted = new DateTime();
            this.DateEnd = new DateTime();
            this.Id_Updator = Guid.Empty;
            this.UpdateDate = new DateTime();
            this.IsStared = EnumStatus.False;
            this.IsDeleted = EnumStatus.False;
        }

    }
}
