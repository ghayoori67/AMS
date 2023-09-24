using Abp.Domain.Repositories;
using AMS.Controllers;
using AMS.PaymentPlans;
using AMS.PaymentPlans.Dto;
using Microsoft.AspNetCore.Mvc;
using Parbad;
using Parbad.AspNetCore;
using Parbad.Gateway.ParbadVirtual;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Web.Host.Controllers
{
    public class TestController : AMSControllerBase
    {
        private readonly IRepository<PaymentPlan> _paymentPlanRepository;
        private readonly IOnlinePayment _onlinePayment;

        public TestController(IRepository<PaymentPlan> paymentPlanRepository, IOnlinePayment onlinePayment)
        {
            _paymentPlanRepository = paymentPlanRepository;
            _onlinePayment = onlinePayment;
        }

        public IActionResult Index()
        {          
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> PaymentPlan(string Price)
        //{
        //    var callbackUrl = Url.Action("Verify", controller: "Payment", null, Request.Scheme);

        //    //  ریزالت زیر حاوی اطلاعاتی مانند کد رهگیری، مبلغ داده شده، درگاه بانکی انتخاب شده، پیام و غیره است
        //    var result = await _onlinePayment.RequestAsync(invoice =>

        //    invoice.SetTrackingNumber(1000)
        //    .SetAmount(Convert.ToInt32(Price))
        //    .SetCallbackUrl(callbackUrl)
        //    .SetGateway(ParbadVirtualGateway.Name)
        //    );

        //    if (result.IsSucceed)
        //    {
        //        // کاربر را به سمت درگاه بانکی هدایت میکند
        //        // همچنین بهتر است کد رهگیری که در شئ ریزالت است را برای فاکتور مورد نظر در پایگاه داده خودتان ذخیره کنید
        //        return result.GatewayTransporter.TransportToGateway();
        //    }

        //    return View("Error", result);
        //}
    }
}
