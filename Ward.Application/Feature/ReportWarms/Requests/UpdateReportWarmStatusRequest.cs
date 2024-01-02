using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Dtos;
using Ward.Application.Dtos.Common;

namespace Ward.Application.Feature.ReportWarms.Requests
{
    public class UpdateReportWarmStatusRequest : IRequest<BaseResponse<bool>>
    {
        public StatusFeedbackDto StatusFeedback { get; set; }
    }
}
