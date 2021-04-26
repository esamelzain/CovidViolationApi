using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidViolation.Models.vModels
{
    public class ViolationRequest
    {
        public int ViolatorId { get; set; }
        public int FineId { get; set; }
        public DateTime IssueDate { get; set; }
        public string Location { get; set; }
        public string Issuer { get; set; }
        public string Notes { get; set; }
    }
}
