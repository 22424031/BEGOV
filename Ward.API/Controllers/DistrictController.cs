using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ward.Application.Dtos.Ads;
using Ward.Application.Dtos.Common;
using Ward.Application.Feature.Ads.Requests;

namespace Ward.API.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private IMediator _mediator;
        public DistrictController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get List by District name with status is Active
        /// </summary>
        /// 
        /// <returns></returns>
        [HttpGet("GetListByDistrictAsync")]
        public async Task<ActionResult<BaseResponse<List<AdsDto>>>> GetListByDistrictAsync(string districtName)
        {
            BaseResponse<List<AdsDto>> rs = new();
            rs = await _mediator.Send(new GetAdsListByDistrictRequest { DistrictName = districtName});
            return rs;
        }
        /// <summary>
        /// Get List by District name with status is Active, status
        /// </summary>
        /// 
        /// <returns></returns>
        [HttpGet("GetListByDistrictStatusAsync")]
        public async Task<ActionResult<BaseResponse<List<AdsDto>>>> GetListByDistrictStatusAsync(string districtName, string status)
        {
            BaseResponse<List<AdsDto>> rs = new();
            rs = await _mediator.Send(new GetAdsListByDistrictStatusRequest { DistrictName = districtName, Status = status});
            return rs;
        }
    }
}
