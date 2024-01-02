using Ward.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Dtos.Ads;
using Ward.Application.Dtos;

namespace Ward.Application.Contracts.Ward
{
    public interface IWardAds
    {
        Task<BaseResponse<bool>> PushToWard(AdsDto dto);
        Task<BaseResponse<bool>> UpdateStatusUserMap(StatusFeedbackDto statusFeedbackDto);
        Task<BaseResponse<bool>> UpdateStatusReportWarm(StatusFeedbackDto statusFeedbackDto);
    }
}
