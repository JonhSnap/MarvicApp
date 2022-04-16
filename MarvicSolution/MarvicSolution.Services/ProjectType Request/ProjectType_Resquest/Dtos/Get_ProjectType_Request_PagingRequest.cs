using MarvicSolution.Services.ProjectType_.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest.Dtos
{
    public class Get_ProjectType_PagingRequest : ProjectType_PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
