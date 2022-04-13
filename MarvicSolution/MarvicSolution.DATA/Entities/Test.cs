using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Entities
{
    public class Test
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EnumStatus IsDeleted { get; set; } = EnumStatus.False;
    }
}
