using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Contracts.ReportWarm;
using Ward.Application.Dtos.Common;
using Ward.Application.Feature.ReportWarms.Requests;
using Ward.Domain;

namespace Ward.Application.Feature.ReportWarms.Handlers
{
    public class AddReportWarmHandler : IRequestHandler<AddReportWarmRequest, BaseResponse<bool>>
    {
        private readonly IReportWarmRepository _reportWarmRepository;
        private readonly IMapper _mapper;
        public AddReportWarmHandler(IReportWarmRepository reportWarmRepository, IMapper mapper)
        {
            _reportWarmRepository = reportWarmRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(AddReportWarmRequest request, CancellationToken cancellationToken)
        {
            BaseResponse<bool> rs = new();
            try
            {
                ReportWarm report = _mapper.Map<ReportWarm>(request.CreateReportWarmDto);
                var data = await _reportWarmRepository.Add(report);
                await _reportWarmRepository.SaveAsync();
            }
            catch(Exception ex)
            {
                rs.IsError = true;
                rs.ErrorMessage = ex.Message;
                rs.Status = 500;
            }
            return rs;
        }
    }
}
