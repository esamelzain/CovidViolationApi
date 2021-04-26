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
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService PaymentService;
        /// <summary>
        /// Inject IPaymentService Into Controller Constructure
        /// </summary>
        /// <param name="_PaymentService"></param>
        public PaymentsController(IPaymentService _PaymentService)
        {
            PaymentService = _PaymentService;
        }
        /// <summary>
        /// Get All Payments 
        /// Method Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public async Task<PaymentsResponse> GetPayments()
        {
            return await PaymentService.GetAll();
        }

    }
}
