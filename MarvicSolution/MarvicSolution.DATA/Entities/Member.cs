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
        public EnumRole Role { get; set; }
        public EnumStatus IsActive { get; set; }

        public Member()
        {
            Id_Project = Guid.Empty;
            Id_User = Guid.Empty;
            Role = EnumRole.Developer;
            IsActive = EnumStatus.True;
        }
    }
}
