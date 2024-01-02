﻿using AutoMapper;
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
    public class GetAdsListByWardHandler : IRequestHandler<GetAdsListByWardRequest, BaseResponse<List<AdsDto>>>
    {
        private readonly IAdsRepository _adsRepository;
        private readonly IMapper _mapper;
        public GetAdsListByWardHandler(IAdsRepository adsRepository, IMapper mapper)
        {
            _adsRepository = adsRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<AdsDto>>> Handle(GetAdsListByWardRequest request, CancellationToken cancellationToken)
        {
            BaseResponse<List<AdsDto>> rs = new();
            try
            {
                var adss = await _adsRepository.GetByWardListAsync(request.WardName);
                var resultDto = _mapper.Map<List<AdsDto>>(adss);
                rs.Data = resultDto;

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
