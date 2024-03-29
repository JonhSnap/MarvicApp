﻿using Microsoft.AspNetCore.Http;
using System;

namespace MarvicSolution.Services.System.Users.Requests
{
    public class UploadAvatar_Request
    {
        public IFormFile File { get; set; }
        public string Url { get; set; }

        public UploadAvatar_Request()
        {
            File = null;
            Url = string.Empty;
        }
    }
}
