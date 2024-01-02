using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Contracts.Ads;
using Ward.Application.Contracts.Mail;
using Ward.Application.Contracts.ReportWarm;
using Ward.Application.Contracts.UserMap;
using Ward.Application.Dtos.Common;
using Ward.Application.Feature.Ads.Requests;
using Ward.Application.Feature.ReportWarms.Requests;

namespace Ward.Application.Feature.ReportWarms.Handlers
{
    public class UpdateReportWarmStatusHandler : IRequestHandler<UpdateReportWarmStatusRequest, BaseResponse<bool>>
    {
        private readonly IReportWarmRepository _repository;
        private readonly IUserMapAds _userMapAds;
        private readonly ISendMail _sendMail;
        public UpdateReportWarmStatusHandler(IReportWarmRepository repository, IUserMapAds userMapAds, ISendMail sendMail) {
            _repository = repository;
            _userMapAds = userMapAds;
            _sendMail = sendMail;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateReportWarmStatusRequest request, CancellationToken cancellationToken)
        {
            BaseResponse<bool> rs = new();
            try
            {
                var data = await _repository.GetById(request.StatusFeedback.Id);
                if(data == null)
                {
                    rs.Status = 204;
                    rs.ErrorMessage = "ReportWarmID not found in database";
                    
                }
                data.Status = request.StatusFeedback.Status;
                data.Feedback = request.StatusFeedback.Comment;
                await _repository.Update(data);
                await _repository.SaveAsync();
                await _userMapAds.UpdateStatusReportWarm(request.StatusFeedback);
                await _sendMail.SendMailTo(data.Email, $"Báo cáo của quý vị {data.Status}");
            }
            catch (Exception ex)
            {
                rs.IsError = true;
                rs.ErrorMessage = ex.Message;
                rs.Status = 500;
            }
            return rs;
        }
    }
}
