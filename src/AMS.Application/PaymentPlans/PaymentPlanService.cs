using Abp.Domain.Repositories;
using AMS.PaymentPlans.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.PaymentPlans
{
    public class PaymentPlanService : AMSAppServiceBase‏, IPaymentPlanService
    {
        private readonly IRepository<PaymentPlan> _paymentPlanRepository;
        public PaymentPlanService(IRepository<PaymentPlan> paymentPlanRepository)
        {
                _paymentPlanRepository = paymentPlanRepository;
        }

        public async Task<GetPaymentPlansOutput> GetPaymentPlans(GetPaymentPlansInput input)
        {
            var query = _paymentPlanRepository
              .GetAll();

            var data = await query.Select(p => new
            {
                p.Title,
                p.Price,
                p.Id,
                p.Description
            }).ToListAsync();

            return new GetPaymentPlansOutput()
            {
                PaymentPlansDto = query
                .Select(p => new PaymentPlanDto()
                {
                    Title = p.Title,
                    Price = p.Price,
                    PaymentPlanId = p.Id,
                    Description = p.Description
                }).ToArray()
            };
        }
    }
}
