using MarvicSolution.DATA.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Entities
{
    public class App_Role : IdentityRole<Guid>
    {
        public override Guid Id { get; set; }
        public override string Name { get; set; }
        public string Creator { get; set; }
        public DateTime DateCreated { get; set; }
        public string Updator { get; set; }
        public DateTime UpdateDate { get; set; }
        public EnumStatus IsDeleted { get; set; }
    }
}
