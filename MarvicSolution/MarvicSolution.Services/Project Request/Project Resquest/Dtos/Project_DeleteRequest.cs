using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Request.Project_Resquest.Dtos
{
    public class Project_DeleteRequest
    {
        ///Các prop cần thiết cho request này
        ///public Guid Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }

        public EnumAccess Access { get; set; } = EnumAccess.Public;
        public Guid Lead_Id { get; set; }
        public Guid Creator_Id { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateEnd { get; set; }

        public Guid Updator_Id { get; set; }
        public DateTime UpdateDate { get; set; }
        public EnumStatus IsDeleted { get; set; }
    }
}
