using Abp.Application.Services;
using AMS.PaymentPlans.Dto;
using AMS.Tickets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.PaymentPlans
{
    public interface IPaymentPlanService: IApplicationService‏
    {
        Task<GetPaymentPlansOutput> GetPaymentPlans(GetPaymentPlansInput input);
    }
}
