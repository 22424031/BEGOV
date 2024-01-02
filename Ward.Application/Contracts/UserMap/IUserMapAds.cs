using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Dtos.Common;
using Ward.Application.Dtos;

namespace Ward.Application.Contracts.UserMap
{
    public interface IUserMapAds
    {
        Task<BaseResponse<bool>> UpdateStatusUserMap(StatusFeedbackDto statusFeedbackDto);
        Task<BaseResponse<bool>> UpdateStatusReportWarm(StatusFeedbackDto statusFeedbackDto);
    }
}
