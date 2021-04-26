using CovidViolation.Models.vModels;
using CovidViolation.Repositories;
using CovidViolation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidViolation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViolatorsController : ControllerBase
    {
        private readonly IViolatorsService violatorsService;
        /// <summary>
        /// Inject IViolatorsService Into Controller Constructure
        /// </summary>
        /// <param name="_violatorsService"></param>
        public ViolatorsController(IViolatorsService _violatorsService)
        {
            violatorsService = _violatorsService;
        }
        /// <summary>
        /// Get All Violators 
        /// Method Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<ViolatorsResponse> GetFines()
        {
            return await violatorsService.GetAll();
        }
        /// <summary>
        /// Issue Violation
        /// Method POST
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("IssueViolation")]
        public async Task<BaseResponse> IssueViolation(ViolationRequest violationRequest)
        {
            return await violatorsService.IssueViolation(violationRequest);
        }
    }
}
