using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Dtos.Common;
using Ward.Application.Dtos.Reports;

namespace Ward.Application.Feature.ReportWarms.Requests
{
    public class AddReportWarmRequest : IRequest<BaseResponse<bool>>
    {
        public CreateReportWarmDto CreateReportWarmDto { get; set; } = new();
    }
}
