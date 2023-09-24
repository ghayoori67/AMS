using Abp.Domain.Repositories;
using AMS.Controllers;
using AMS.PaymentPlans;
using AMS.PaymentPlans.Dto;
using AMS.UserPayments;
using Microsoft.AspNetCore.Mvc;
using Parbad;
using Parbad.AspNetCore;
using Parbad.Gateway.ParbadVirtual;
using Parbad.Gateway.ZarinPal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Web.Host.Controllers
{

    public class PaymentController : AMSControllerBase
    {
        private readonly IRepository<PaymentPlan> _paymentPlanRepository;
        private readonly IRepository<UserPayment> _userPaymentRepository;
        private readonly IOnlinePayment _onlinePayment;

        public PaymentController(IRepository<PaymentPlan> paymentPlanRepository, IOnlinePayment onlinePayment, IRepository<UserPayment> userPaymentRepository)
        {
            _paymentPlanRepository = paymentPlanRepository;
            _onlinePayment = onlinePayment;
            _userPaymentRepository = userPaymentRepository;
        }

        public IActionResult Index()
        {
            var query = _paymentPlanRepository
              .GetAll();

            var plans = query.Select(p => new PaymentPlanDto()
            {
                Title = p.Title,
                PaymentPlanId = p.Id,
                Price = p.Price,
                Description = p.Description
            }).ToArray();

            return View(plans);
        }
        [HttpPost]
        public async Task<IActionResult> PaymentPlan([Bind(Prefix = "item")] PaymentPlanDto items)
        {
            //فرم توی حلقه هست و اظلاعات اشتباه میاره بررسی شود


            var callbackUrl = Url.Action("Verify", "Payment", null, Request.Scheme);
            var price = items.Price;
            TempData["PaymentPlanId"] = items.PaymentPlanId;

            #region کانفیگ زرین پال
            //var result = await _onlinePayment.RequestAsync(invoice =>
            //{
            //    invoice
            //        .UseZarinPal()
            //        .SetZarinPalData("خرید پلن های سامانه")
            //        .SetCallbackUrl(callbackUrl)
            //        .UseAutoIncrementTrackingNumber()
            //        .SetAmount(10000); // به ریا ل

            //});
            #endregion

            #region کانفیگ درگاه مجازی تست
            var result = await _onlinePayment.RequestAsync(invoice =>
                    invoice.UseAutoIncrementTrackingNumber()
                    .SetAmount(items.Price)
                    .SetCallbackUrl(callbackUrl)
                    .SetGateway(ParbadVirtualGateway.Name));
            #endregion


            if (result.IsSucceed)
            {
                // کاربر را به سمت درگاه بانکی هدایت میکند
                // همچنین بهتر است کد رهگیری که در شئ ریزالت است را برای فاکتور مورد نظر در پایگاه داده خودتان ذخیره کنید
                return result.GatewayTransporter.TransportToGateway();
            }

            return View("Error", result);
        }

        public async Task<IActionResult> Verify()
        {


            var invoice = await _onlinePayment.FetchAsync();

            var verifyResult = await _onlinePayment.VerifyAsync(invoice);
            string PaymentPlanId = TempData["PaymentPlanId"].ToString();

            //if (verifyResult.IsSucceed)
            //{
            //    var userPayment = new UserPayment()
            //    {
            //        Amount = Convert.ToInt32(verifyResult.Amount),
            //        GatewayName = verifyResult.GatewayName,
            //        IsSucceed = verifyResult.IsSucceed,
            //        Message = verifyResult.Message,
            //        TrackingNumber = verifyResult.TrackingNumber,
            //        TransactionCode = verifyResult.TransactionCode,
            //        PaymentPlanId = Convert.ToInt16(PaymentPlanId)
            //    };

            //    await _userPaymentRepository.InsertAsync(userPayment);

            //}

            if (!IsEveryThinkOk(invoice.TrackingNumber))
            {
                var cancelResult = await _onlinePayment.CancelAsync(invoice, cancellationReason: "متاسفانه عملیات پرداخت ناموفق بود");
                return View("CancelResult", cancelResult);
            }

            return View(verifyResult);
        }
        public bool IsEveryThinkOk(long trackingNumber)
        {
            return true;
        }
    }
}
