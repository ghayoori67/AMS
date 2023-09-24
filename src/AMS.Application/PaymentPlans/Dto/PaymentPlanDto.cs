using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.PaymentPlans.Dto
{
    public class PaymentPlanDto
    {
        public int PaymentPlanId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int[] Prices { get; set; }
    }
}
