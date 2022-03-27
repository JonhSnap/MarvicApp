using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.ProjectType_Request.Dtos
{
    public class ProjectType_PageResult<T>
    {
        public List<T> Items { get; set; }
        public int totalRecords { get; set; }
    }
}
