using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.System.Users.Requests
{
    public class DeleteAvatar_Request
    {
        public Guid IdUser { get; set; }
        public string FileName { get; set; }
        public DeleteAvatar_Request()
        {
            IdUser = Guid.Empty;
            FileName = string.Empty;
        }

        public DeleteAvatar_Request(Guid idIssue, string fileName)
        {
            IdUser = idIssue;
            FileName = fileName;
        }
    }
}
