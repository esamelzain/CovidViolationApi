using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidViolation.Models.dbModels
{
    public class Fine
    {
        public int Id { get; set; }
        public string FineName { get; set; }
        public decimal FineAmount { get; set; }
    }
}
