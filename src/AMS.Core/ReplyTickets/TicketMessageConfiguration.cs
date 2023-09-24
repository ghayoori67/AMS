using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ReplyTickets
{
    public class TicketMessageConfiguration : IEntityTypeConfiguration<TicketMessage>
    {
        public void Configure(EntityTypeBuilder<TicketMessage> builder)
        {

            builder.ToTable("TicketMessages");
            builder.HasKey(t => t.Id);
            builder.Property(x=>x.Message).HasMaxLength(2500).IsRequired();
            builder.HasOne(u => u.CreatorUser).WithMany(t => t.TicketMessages).HasForeignKey(t => t.CreatorUserId);
            

        }
    }
}
