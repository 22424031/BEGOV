using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ward.Application.Dtos.Common;
using Ward.Application.Dtos.Ads;
using Ward.Application.Feature.Ads.Requests;
using Ward.Application.Dtos;
using Ward.Application.Constants;

namespace Ward.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private IMediator _mediator;
        public AdsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("ReceiveAds")]
        public async Task<ActionResult<BaseResponse<AdsDto>>> AddAdsAsync([FromBody] CreateAdsDto ads)
        {
            BaseResponse<AdsDto> rs = new();
            rs = await _mediator.Send(new AddAdsRequest { Ads = ads });
            return rs;
        }
        [HttpGet("GetListAsync")]
        public async Task<ActionResult<BaseResponse<List<AdsDto>>>> GetListAsync()
        {
            BaseResponse<List<AdsDto>> rs = new();
            rs = await _mediator.Send(new GetAdsListRequest());
            return rs;

        }
      
        /// <summary>
        /// Get ADs by ADSID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <responses status="500">Error Internal server</responses>
        /// <responses status="204">No content</responses>
        /// <responses status="200">Result have data</responses>
        [HttpGet("GetByAdsIDAsync")]
        public async Task<ActionResult<BaseResponse<AdsDto>>> GetByAdsIDAsync(int id)
        {
            BaseResponse<AdsDto> rs = new();
            rs = await _mediator.Send(new GetAdsByIDRequest { adsID = id });
            if (rs.Data is null) return Ok(rs);
            return rs;
        }
        /// <summary>
        /// Update status : Đang xử lý, Đã xử lý xong, từ chối
        /// </summary>
        /// <param name="statusFeedbackDto"></param>
        /// <returns></returns>
        [HttpPost("UpdateStatus")]
        public async Task<ActionResult<BaseResponse< bool>>> UpdateStatus(StatusFeedbackDto statusFeedbackDto)
        {
            BaseResponse<bool> rs = new();
            if(statusFeedbackDto.Status.ToLower() != StatusFeedbackConst.TuChoi.ToLower() 
                && statusFeedbackDto.Status.ToLower() != StatusFeedbackConst.DangXuLy.ToLower()
              &&  statusFeedbackDto.Status.ToLower() != StatusFeedbackConst.DaXuLy.ToLower()
                )
            {
                rs.IsError = true;
                rs.ErrorMessage = "Status required is Đang xử lý, Đã xử lý xong, từ chối";
                rs.Status = 400;
                return rs;
            }
             rs = await _mediator.Send(new UpdateAdsStatusRequest { StatusFeedback = statusFeedbackDto });
            return rs;
        }
    }
}
