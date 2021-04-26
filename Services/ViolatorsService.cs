using CovidViolation.Authentication;
using CovidViolation.Handlers;
using CovidViolation.Models.dbModels;
using CovidViolation.Models.vModels;
using CovidViolation.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidViolation.Services
{
    public class ViolatorsService : IViolatorsService
    {
        private readonly ApplicationDbContext _db;
        /// <summary>
        /// Inject DbContext
        /// </summary>
        /// <param name="db"></param>
        public ViolatorsService(ApplicationDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Get All Violators Service
        /// </summary>
        /// <returns></returns>
        public async Task<ViolatorsResponse> GetAll()
        {
            try
            {
                var dbViolations = await _db.Violation.Include(v=>v.Violator).Include(v => v.Fine).ToListAsync();
                if (dbViolations.Count > 0)
                {
                    ViolatorsResponse response = new ViolatorsResponse();
                    response.Violators = new List<ViolatorResponse>();
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
                        response.Violators.Add(violarorResponse);
                    }
                    response.Message = Helper.GetResponseMessage(200);
                    return response;
                }
                else
                {
                    return new ViolatorsResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }
            }
            catch (Exception ex)
            {
                return new ViolatorsResponse
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }
        /// <summary>
        /// Add Violation (Registration)
        /// </summary>
        /// <param name="violationRequest"></param>
        /// <returns></returns>

        public async Task<BaseResponse> IssueViolation(ViolationRequest violationRequest)
        {
            try
            {
                Violation violation = new Violation()
                {
                    FineId = violationRequest.FineId,
                    ViolatorId = violationRequest.ViolatorId,
                    IssueDate = violationRequest.IssueDate,
                    Notes = violationRequest.Notes,
                    Location = violationRequest.Location,
                    Issuer = violationRequest.Issuer,
                    IsPaid = false
                };
                await _db.Violation.AddAsync(violation);
                await _db.SaveChangesAsync();
                return new BaseResponse
                {
                    Message = Helper.GetResponseMessage(200)
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }

    }
}
