using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Contracts.Ads;
using Ward.Application.Dtos.Ads;
using Ward.Application.Dtos.Common;
using Ward.Application.Feature.Ads.Requests;

namespace Ward.Application.Feature.Ads.Handlers
{
    public class GetAdsListByDistrictStatusHandler : IRequestHandler<GetAdsListByDistrictStatusRequest, BaseResponse<List<AdsDto>>>
    {
        private readonly IAdsRepository _adsRepository;
        private readonly IMapper _mapper;
        public GetAdsListByDistrictStatusHandler(IAdsRepository adsRepository, IMapper mapper)
        {
            _adsRepository = adsRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<AdsDto>>> Handle(GetAdsListByDistrictStatusRequest request, CancellationToken cancellationToken)
        {
            BaseResponse<List<AdsDto>> rs = new();
            try
            {
                var adsList = await _adsRepository.GetByDistrictStatusListAsync(request.DistrictName, request.Status);
                rs.Data =  _mapper.Map<List<AdsDto>>(adsList);
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
