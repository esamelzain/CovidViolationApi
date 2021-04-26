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

    public class FineService : IFineService
    {
        private readonly ApplicationDbContext _db;
        /// <summary>
        /// Inject DbContext
        /// </summary>
        /// <param name="db"></param>
        public FineService(ApplicationDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Get All Fines Service
        /// </summary>
        /// <returns></returns>
        public async Task<FineResponse> GetAll()
        {
            try
            {
                var dbFines = await _db.Fine.ToListAsync();
                if (dbFines.Count > 0)
                {
                    return new FineResponse
                    {
                        Fines = dbFines,
                        Message = Helper.GetResponseMessage(200)
                    };
                }
                else
                {
                    return new FineResponse
                    {
                        Message = Helper.GetResponseMessage(402)
                    };
                }

            }
            catch (Exception ex)
            {
                return new FineResponse
                {
                    Message = Helper.GetResponseMessage(500)
                };
            }
        }

    }
}
