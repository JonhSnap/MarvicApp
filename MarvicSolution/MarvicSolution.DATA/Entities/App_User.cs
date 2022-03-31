using MarvicSolution.DATA.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Entities
{
    public class App_User : IdentityUser<Guid>
    {
        public override Guid Id { get; set; }
        public string FullName { get; set; }
        public override string UserName { get; set; }
        public string Password { get; set; }
        public override string Email { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Organization { get; set; }
        public override string PhoneNumber { get; set; }
        public EnumStatus IsDeleted { get; set; } = EnumStatus.False;
    }
}
