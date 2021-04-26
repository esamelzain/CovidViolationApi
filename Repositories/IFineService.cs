using CovidViolation.Models.vModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidViolation.Repositories
{
    public interface IFineService
    {
        public Task<FineResponse> GetAll();
    }
}
