using CovidViolation.Authentication;
using CovidViolation.Handlers;
using CovidViolation.Models.vModels;
using CovidViolation.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidViolation.Services
{

    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _db;
        /// <summary>
        /// Inject DbContext
        /// </summary>
        /// <param name="db"></param>
        public PaymentService(ApplicationDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Get All Payments Service
        /// </summary>
        /// <returns></returns>
        public async Task<PaymentsResponse> GetAll()
        {
            try
            {
                /////We Assume Here we can take the violtion id and go to the payment portal 
                ///to insure this transaction has been paid successfully and get the payment Transcti.on Id
                var dbViolations = await _db.Violation.Include("Violator").Include("Fine").Where(vio=>vio.IsPaid).ToListAsync();
                if (dbViolations.Count > 0)
                {
                    PaymentsResponse response = new PaymentsResponse();
                    response.PaymentResponse = new List<PaymentResponse>();

                    foreach (var item in dbViolations)
                    {
                        ViolatorResponse violarorResponse = new ViolatorResponse
                        {
                            FineAmount = item.Fine.FineAmount,
                            FineName = item.Fine.FineName,
                            IsPaid = item.IsPaid,
                            IssueDate = item.IssueDate,
                            Issuer = item.Issuer,
                            Location = item.Location,
                            Notes = item.Notes,
                            Violator = item.Violator
                        };
                        response.PaymentResponse.Add(new PaymentResponse()
                        {
                            Violator = violarorResponse,
                            PaymentDate = DateTime.Now,
                            TransactionId = new Guid().ToString()
                        });
                    }
                    response.Message = Helper.GetResponseMessage(200);
                    return response;
                }
                else
                {
                    return new PaymentsResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new PaymentsResponse
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }

    }
}
