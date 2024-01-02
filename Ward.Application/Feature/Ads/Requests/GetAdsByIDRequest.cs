using MediatR;
using Ward.Application.Dtos.Common;
using Ward.Application.Dtos.Ads;

namespace Ward.Application.Feature.Ads.Requests
{
    public class GetAdsByIDRequest : IRequest<BaseResponse<AdsDto>>
    {
        public int adsID { get; set; }
    }
}
