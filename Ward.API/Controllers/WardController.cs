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
    public class WardController : ControllerBase
    {
        private IMediator _mediator;
        public WardController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get List by Ward name with status is Active
        /// </summary>
        /// 
        /// <returns></returns>
        [HttpGet("GetListByWardAsync")]
        public async Task<ActionResult<BaseResponse<List<AdsDto>>>> GetListByWardAsync(string wardName)
        {
            BaseResponse<List<AdsDto>> rs = new();
            rs = await _mediator.Send(new GetAdsListByWardRequest {  WardName = wardName});
            return rs;
        }
        /// <summary>
        /// Get List by Ward name with status is Active, status
        /// </summary>
        /// 
        /// <returns></returns>
        [HttpGet("GetListByWardStatusAsync")]
        public async Task<ActionResult<BaseResponse<List<AdsDto>>>> GetListByWardStatusAsync(string wardName, string status)
        {
            BaseResponse<List<AdsDto>> rs = new();
            rs = await _mediator.Send(new GetAdsListByWardStatusRequest {  WardName = wardName, Status = status});
            return rs;
        }
    }
}
