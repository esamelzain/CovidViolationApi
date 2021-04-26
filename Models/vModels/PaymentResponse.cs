using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidViolation.Models.vModels
{
    public class PaymentsResponse : BaseResponse
    {
        public List<PaymentResponse> PaymentResponse { get; set; }
    }
    public class PaymentResponse 
    {
        public DateTime PaymentDate { get; set; }
        public string TransactionId { get; set; }
        public ViolatorResponse Violator { get; set; }
    }
}
