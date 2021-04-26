using CovidViolation.Models.dbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidViolation.Models.vModels
{
    public class FineResponse : BaseResponse
    {
        public List<Fine> Fines { get; set; }
    }
}
