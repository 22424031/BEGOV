using MediatR;
using Ward.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Dtos.Ads;
using Ward.Domain;

namespace Ward.Application.Feature.Ads.Requests
{
    public class AddAdsRequest : IRequest<BaseResponse<AdsDto>>
    {
        public CreateAdsDto Ads { get; set; }
    }
}
