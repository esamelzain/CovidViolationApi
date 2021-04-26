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
    public class FinesController : ControllerBase
    {
        private readonly IFineService fineService;
        /// <summary>
        /// Inject IFineService Into Controller Constructure
        /// </summary>
        /// <param name="_fineService"></param>
        public FinesController(IFineService _fineService)
        {
            fineService = _fineService;
        }
        /// <summary>
        /// Get All Fines 
        /// Method Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<FineResponse> GetFines()
        {
            return await fineService.GetAll();
        }

    }
}
