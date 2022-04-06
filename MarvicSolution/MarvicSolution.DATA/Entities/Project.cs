using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Entities
{
    /// <summary>
    /// Table lam vi du
    /// </summary>
    public class Project
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Project name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Key is required.")]
        public string Key { get; set; }
        [Required(ErrorMessage = "Access is required.")]
        public EnumAccess Access { get; set; } = EnumAccess.Public;
        public Guid Id_Lead { get; set; }
        public Guid Id_Creator { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateEnd { get; set; }

        public Guid Id_Updator { get; set; }
        public DateTime? UpdateDate { get; set; }
        public EnumStatus IsDeleted { get; set; } = EnumStatus.False;

    }
}
