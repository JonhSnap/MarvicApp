﻿using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Issue_Request.Issue_Request.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels
{
    public class GroupByIssueType_ViewModel
    {
        public EnumIssueType IdType { get; set; }
        public List<Issue_ViewModel> ListIssue { get; set; }

        public GroupByIssueType_ViewModel()
        {
            this.IdType = EnumIssueType.Epic;
            this.ListIssue = new List<Issue_ViewModel>();
        }
    }
}
