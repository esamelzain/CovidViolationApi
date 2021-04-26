using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CovidViolation.Models.dbModels
{
    public class Violation
    {
        public int Id { get; set; }
        public int ViolatorId { get; set; }
        [JsonIgnore]
        public virtual Violator Violator { get; set; }
        public int FineId { get; set; }
        [JsonIgnore]
        public virtual Fine Fine { get; set; }
        public DateTime IssueDate { get; set; }
        public string Location { get; set; }
        public string Issuer { get; set; }
        public string Notes { get; set; }
        public bool IsPaid { get; set; }
    }
}
