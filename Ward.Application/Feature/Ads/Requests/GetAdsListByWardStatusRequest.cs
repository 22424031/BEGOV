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
    public class GetAdsListByWardStatusRequest : IRequest<BaseResponse<List<AdsDto>>>
    {
        public string WardName { get; set; }
        public string Status { get; set; }
    }
}
