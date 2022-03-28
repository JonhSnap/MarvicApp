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
        // March/29/2022 chua update migration
        [Required(ErrorMessage = "Project Id is required.")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Project name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Key is required.")]
        public string Key { get; set; }

        public Guid ProjectType_Id { get; set; }
        public Guid Lead_Id { get; set; }
        public Guid Creator_Id { get; set; }

        [Required(ErrorMessage = "Date Created is required.")]
        public DateTime DateCreated { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateEnd { get; set; }

        public Guid Updator_Id { get; set; }
        public DateTime UpdateDate { get; set; }
        public EnumStatus IsDeleted { get; set; }

    }
}
