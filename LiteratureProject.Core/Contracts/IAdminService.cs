﻿using LiteratureProject.Core.Models.AdminModels;
using LiteratureProject.Core.Models.ProfileModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Contracts
{
    public interface IAdminService
    {
        Task<AdminDashboardViewModel> GetDashboardStatisticsAsync();
    }

}
