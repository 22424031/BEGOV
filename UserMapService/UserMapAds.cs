using Microsoft.Extensions.Configuration;
using Ward.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Contracts.Ward;
using Ward.Application.Dtos.Ads;
using Ward.Application.Dtos;
using Ward.Application.Contracts.UserMap;

namespace UserMapService
{
    public class UserMapAds : BaseClient,IUserMapAds
    {
        public UserMapAds(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<BaseResponse<bool>> UpdateStatusUserMap(StatusFeedbackDto statusFeedbackDto)
        {
            return await this.PostAsync("api/SubWard/StatusFeedback", statusFeedbackDto);
        }
        public async Task<BaseResponse<bool>> UpdateStatusReportWarm(StatusFeedbackDto statusFeedbackDto)
        {
            return await this.PostAsync("api/SubWard/StatusReportWarmFeedback", statusFeedbackDto);
        }
    }
}
