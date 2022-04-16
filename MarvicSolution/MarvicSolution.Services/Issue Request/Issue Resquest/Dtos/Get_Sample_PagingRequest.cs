
using MarvicSolution.Services.Module_Sample.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Issue_Request.Dtos
{
    public class Get_Sample_PagingRequest : Issue_PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
