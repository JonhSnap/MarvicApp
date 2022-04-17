﻿
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Issue_Request
{
    public interface IIssue_Service
    {
        // INPUT
        Task<Guid> Create(Issue_CreateRequest rq);
        Task<Guid> Update(Issue_UpdateRequest request);
        Task<Guid> Delete(Guid Id);

        // OUTPUT
        Task<List<Issue_ViewModel>> GetAlls();
    }
}
