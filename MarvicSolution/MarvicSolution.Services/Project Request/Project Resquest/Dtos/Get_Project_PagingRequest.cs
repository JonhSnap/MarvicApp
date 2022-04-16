using MarvicSolution.Services.Project_Request.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Request.Project_Resquest.Dtos
{
    public class Get_Project_PagingRequest : Project_PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
