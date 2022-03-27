using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Group_Sample.Dtos
{
    public class GetSamplePagingRequest : Sample_PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
