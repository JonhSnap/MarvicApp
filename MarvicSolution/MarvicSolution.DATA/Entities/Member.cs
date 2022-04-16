using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Entities
{
    public class Member
    {
        public Guid Id_Project { get; set; }
        public Guid Id_User { get; set; }
        public EnumStatus IsDeleted { get; set; } = EnumStatus.False;
    }
}
