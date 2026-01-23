using LibraryProject.Business.DTOs.StatisticsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.Abstract
{
    public interface IStatisticsService
    {
        Task<DashboardDto> GetDashboardStatistics();
    }
}
