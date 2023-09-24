using AMS.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.PaymentPlans
{
    public class PaymentPlanConfiguration : IEntityTypeConfiguration<PaymentPlan>
    {
        public void Configure(EntityTypeBuilder<PaymentPlan> builder)
        {
            builder.ToTable("PaymentPlans");
            builder.HasKey(t => t.Id);

            builder.Property(x=>x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Description).HasMaxLength(1500);
            builder.Property(x=>x.Price).IsRequired();
        }
    }
}
