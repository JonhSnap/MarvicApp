using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Entities
{
    /// <summary>
    /// Table lam vi du
    /// </summary>
    public class ProjectType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public string Updator { get; set; }
        public DateTime UpdateDate { get; set; }
        public EnumStatus IsDeleted { get; set; }

        public ProjectType()
        {

        }

        public ProjectType(Guid id, string name, string updator, DateTime updateDate, EnumStatus isDeleted)
        {
            Id = id;
            Name = name;
            Updator = updator;
            UpdateDate = updateDate;
            IsDeleted = isDeleted;
        }

    }
}
