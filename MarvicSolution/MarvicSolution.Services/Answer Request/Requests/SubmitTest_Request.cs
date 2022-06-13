using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Answer_Request.Requests
{
    public class SubmitTest_Request
    {
        public List<Guid> listId { get; set; }
        public Guid IdTest { get; set; }
            
        public SubmitTest_Request()
        {
            IdTest = Guid.Empty;
            listId = new List<Guid>();
        }
    }
}
