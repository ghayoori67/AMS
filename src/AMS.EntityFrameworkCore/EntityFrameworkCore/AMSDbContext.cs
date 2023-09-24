using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AMS.Authorization.Roles;
using AMS.Authorization.Users;
using AMS.MultiTenancy;
using AMS.Tickets;
using AMS.ReplyTickets;
using AMS.PaymentPlans;
using AMS.UserPayments;

namespace AMS.EntityFrameworkCore
{
    public class AMSDbContext : AbpZeroDbContext<Tenant, Role, User, AMSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AMSDbContext(DbContextOptions<AMSDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //config
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new TicketMessageConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentPlanConfiguration());
            modelBuilder.ApplyConfiguration(new UserPaymentConfiguration());
        }

        #region Entities
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessage> ReplyTickets { get; set; }
        public DbSet<PaymentPlan> PaymentPlans { get; set; }
        public DbSet<UserPayment> UserPayments { get; set; }
        #endregion

    }
}
