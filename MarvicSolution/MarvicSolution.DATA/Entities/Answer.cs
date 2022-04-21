using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Entities
{
    public class Answer
    {

        public Guid Id { get; set; }
        public Guid Id_Question { get; set; }
        public string Name { get; set; }
        public EnumStatus IsAnswer { get; set; } = EnumStatus.False;
        public EnumStatus IsDeleted { get; set; } = EnumStatus.False;
    }
}
