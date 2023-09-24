using AMS.PaymentPlans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.UserPayments
{
    public class UserPaymentConfiguration : IEntityTypeConfiguration<UserPayment>
    {
        public void Configure(EntityTypeBuilder<UserPayment> builder)
        {
            builder.ToTable("UserPayments");
            builder.HasKey(x => x.Id);

            builder.HasOne(x=>x.PaymentPlan).WithMany(x=>x.UserPayments).HasForeignKey(x=>x.PaymentPlanId);
        }
    }
}
