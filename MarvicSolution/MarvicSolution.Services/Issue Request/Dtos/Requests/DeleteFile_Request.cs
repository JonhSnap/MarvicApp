using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.Requests
{
    public class DeleteFile_Request
    {
        public Guid IdIssue { get; set; }
        public string FileName { get; set; }
        public DeleteFile_Request()
        {
            IdIssue = Guid.Empty;
            FileName = string.Empty;
        }

        public DeleteFile_Request(Guid idIssue, string fileName)
        {
            IdIssue = idIssue;
            FileName = fileName;
        }
    }
}
