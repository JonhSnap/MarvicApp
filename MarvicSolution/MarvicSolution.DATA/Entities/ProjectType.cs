using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public string Updator { get; set; }
        public DateTime UpdateDate { get; set; }
        [DefaultValue(0)]
        public EnumStatus IsDeleted { get; set; }

        public ProjectType()
        {

        }

        public ProjectType(Guid id, string name, string updator, DateTime updateDate, EnumStatus isDeleted = EnumStatus.False)
        {
            Id = id;
            Name = name;
            Updator = updator;
            UpdateDate = updateDate;
            IsDeleted = isDeleted;
        }

    }
}
