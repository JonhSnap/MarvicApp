﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.Archive
{
    public class StatisticIssueArchived_ViewModel
    {
        public double x { get; set; }
        public double y { get; set; }

        public StatisticIssueArchived_ViewModel()
        {
            x = 0;
            y = 0;
        }
    }
}
