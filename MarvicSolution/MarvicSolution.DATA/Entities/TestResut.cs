using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Entities
{
    public class TestResut
    {
        public Guid Id { get; set; }
        public Guid Id_User { get; set; }
        public Guid Id_Test { get; set; }
        public DateTime CreateDate { get; set; }
        public double TotalPoint { get; set; }
        public TestResut()
        {
            Id = Guid.Empty;
            Id_User = Guid.Empty;
            Id_Test = Guid.Empty;
            CreateDate = new DateTime();
            TotalPoint = 0;
        }

        public TestResut(Guid id, Guid id_User, Guid id_Test, DateTime createDate, double totalPoint)
        {
            Id = id;
            Id_User = id_User;
            Id_Test = id_Test;
            CreateDate = createDate;
            TotalPoint = totalPoint;
        }

    }
}
