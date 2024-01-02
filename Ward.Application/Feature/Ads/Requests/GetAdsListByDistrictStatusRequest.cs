using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Dtos.Ads;
using Ward.Application.Dtos.Common;

namespace Ward.Application.Feature.Ads.Requests
{
    public class GetAdsListByDistrictStatusRequest : IRequest<BaseResponse<List<AdsDto>>>
    {
        public string DistrictName { get; set; }
        public string Status { get; set; }
    }
}
