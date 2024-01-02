using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ward.Application.Dtos
{
    public class StatusFeedbackDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
        public string FeedbackBy { get; set; } = "Admin";
    }
}
