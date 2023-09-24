using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.UserPayments;

namespace AMS.PaymentPlans
{
    public class PaymentPlan : Entity, IAudited
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public List<UserPayment> UserPayments { get; set; }


        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get;set; }
        public long? LastModifierUserId { get;set; }
        public DateTime? LastModificationTime { get;set; }
    }
}
