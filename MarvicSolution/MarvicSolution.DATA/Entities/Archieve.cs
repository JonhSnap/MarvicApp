using MarvicSolution.DATA.Enums;
using System;

namespace MarvicSolution.DATA.Entities
{
    public class Archieve
    {
        public Archieve()
        {
        }

        public Archieve(Guid id_Sprint, string description)
        {
            Id_Sprint = id_Sprint;
            Description = description;
            Create_Date = DateTime.Now;
        }

        public Archieve(Guid id_Sprint)
        {
            Id_Sprint = id_Sprint;
        }

        public Guid Id { get; set; }
        public Guid Id_Sprint { get; set; }
        public string Description { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Create_Update { get; set; }
        public EnumStatus Is_Delete { get; set; }
    }
}
