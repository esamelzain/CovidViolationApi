using CovidViolation.Models.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidViolation.Models.vModels
{
    public class ViolatorsResponse : BaseResponse
    {
        public List<ViolatorResponse> Violators { get; set; }
    }
    public  class ViolatorResponse
    {
        public Violator Violator { get; set; }
        public string FineName { get; set; }
        public decimal FineAmount { get; set; }
        public DateTime IssueDate { get; set; }
        public string Issuer { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public bool IsPaid { get; set; }
    }
}
