using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels
{
    public class RequestVM
    {
        public string Shceme { get; set; }
        public HostString Host { get; set; }
        public PathString PathBase { get; set; }

        public RequestVM(string shceme, HostString host, PathString pathBase)
        {
            Shceme = shceme;
            Host = host;
            PathBase = pathBase;
        }
    }
}
