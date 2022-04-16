using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Module_Sample.Dtos
{
    public class Issue_PageResult<T>
    {
        public List<T> Items { get; set; }
        public int totalRecords { get; set; }
    }
}
