using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.PaymentPlans;

namespace AMS.UserPayments
{
    public class UserPayment : Entity, IAudited
    {
        public long? TrackingNumber { get; set; }
        public int Amount { get; set; }
        public string TransactionCode { get; set; }
        public string GatewayName { get; set; }
        public bool IsSucceed { get; set; }
        public string Message { get; set; }

        public int PaymentPlanId { get; set; }
        public PaymentPlan PaymentPlan { get; set; }

        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
