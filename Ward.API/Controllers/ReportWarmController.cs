using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ward.Application.Dtos;
using Ward.Application.Dtos.Common;
using Ward.Application.Dtos.Reports;
using Ward.Application.Feature.ReportWarms.Requests;

namespace Ward.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportWarmController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReportWarmController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("ReceiveReportWarm")]
        public async Task<BaseResponse<bool>> AddAsync([FromBody] CreateReportWarmDto createReportWarm)
        {
            var result = await _mediator.Send(new AddReportWarmRequest { CreateReportWarmDto = createReportWarm });
            return result;
        }
        [HttpPost("UpdateStatus")]
        public async Task<BaseResponse<bool>> UpdateStatus(StatusFeedbackDto statusFeedbackDto)
        {
            var data = await _mediator.Send(new UpdateReportWarmStatusRequest { StatusFeedback = statusFeedbackDto });
            return data;
        }
    }
}
