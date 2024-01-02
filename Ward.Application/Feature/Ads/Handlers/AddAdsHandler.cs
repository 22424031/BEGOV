using AutoMapper;
using MediatR;
using Ward.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Contracts.Ads;
using Ward.Application.Contracts.Ward;
using Ward.Application.Dtos.Ads;
using Ward.Application.Feature.Ads.Requests;

namespace Ward.Application.Feature.Ads.Handlers
{
    public class AddAdsHandler : IRequestHandler<AddAdsRequest, BaseResponse<AdsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAdsRepository _adsRepository;
       // private readonly IWardAds _wardAds;
        public AddAdsHandler(IAdsRepository adsRepository, IMapper mapper)
        {
            _adsRepository = adsRepository;
            _mapper = mapper;
           // _wardAds = wardAds;
        }
        public async Task<BaseResponse<AdsDto>> Handle(AddAdsRequest request, CancellationToken cancellationToken)
        {
            BaseResponse<AdsDto> rs = new();
            try
            {

                Domain.Ads ads = await _adsRepository.Add(_mapper.Map<Domain.Ads>(request.Ads));
                await _adsRepository.SaveChange();
                rs.Status = 200;
                rs.Data = _mapper.Map<AdsDto>(ads);
                //var resultWard = await _wardAds.PushToWard(_mapper.Map<AdsDto>(ads));
                //if (resultWard.IsError)
                //{
                //    rs.Status = 500;
                //    rs.ErrorMessage = resultWard.ErrorMessage;
                //    return rs;
                //}
            }
            catch(Exception ex)
            {
                rs.IsError = true;
                rs.ErrorMessage = ex.Message;
                rs.Status = 500;
            }
            return rs;
        }
    }
}
