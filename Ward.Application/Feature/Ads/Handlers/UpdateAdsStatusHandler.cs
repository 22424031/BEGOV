using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Contracts.Ads;
using Ward.Application.Contracts.UserMap;
using Ward.Application.Dtos.Common;
using Ward.Application.Feature.Ads.Requests;

namespace Ward.Application.Feature.Ads.Handlers
{
    public class UpdateAdsStatusHandler : IRequestHandler<UpdateAdsStatusRequest, BaseResponse<bool>>
    {
        private readonly IAdsRepository _adsRepository;
        private readonly IUserMapAds _userMapAds;
        public UpdateAdsStatusHandler(IAdsRepository adsRepository, IUserMapAds userMapAds) {
                _adsRepository = adsRepository;
            _userMapAds = userMapAds;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateAdsStatusRequest request, CancellationToken cancellationToken)
        {
            BaseResponse<bool> rs = new();
            try
            {
                var data = await _adsRepository.GetAdsById(request.StatusFeedback.Id);
                if(data == null)
                {
                    rs.Status = 204;
                    rs.ErrorMessage = "AdsID not found in database";
                    
                }
                data.Status = request.StatusFeedback.Status;
                data.Feedback = request.StatusFeedback.Comment;
                await _adsRepository.Update(data);
                await _adsRepository.SaveChange();
                await _userMapAds.UpdateStatusUserMap(request.StatusFeedback);
            }
            catch (Exception ex)
            {
                rs.IsError = true;
                rs.ErrorMessage = ex.Message;
                rs.Status = 500;
            }
            return rs;
        }
    }
}
