using MarvicSolution.DATA.Enums;
using System;

namespace MarvicSolution.DATA.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Id_Test { get; set; }
        public EnumPoint Scores { get; set; }
    }
}
