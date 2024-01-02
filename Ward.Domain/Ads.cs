using Ward.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ward.Domain
{
    public class Ads : BaseDomainEntity
    {
        [Key]
        public int AdsID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
        public string CompanyInfo { get; set; }
        public string Email { get; set; }
        public string CompanyAddress {get;set;}
        public string PhoneNumber { get; set;}
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public string SizeUnit { get; set; } 
        public List<string>? UrlImages { get; set; }
        public string UrlImagesJson { get; set; }
        public string AdsAddress { get; set; }
        public decimal Lat { get; set; }
        public decimal Longt { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public string? Feedback { get; set; }
    }
}
