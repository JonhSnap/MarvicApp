using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.Requests
{
    public class UploadFile_Request
    {
        public Guid IdIssue { get; set; }
        public IFormFile File { get; set; }
        public string Url { get; set; }

        public UploadFile_Request()
        {
            IdIssue = Guid.Empty;
            File = null;
            Url = string.Empty;
        }
    }
}
