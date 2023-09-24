using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AMS.Authorization.Users;
using AMS.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.ReplyTickets
{
    public class TicketMessage: Entity, IAudited
    {
        public string Message { get; set; }

        #region Relations
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public User CreatorUser { get; set; }
        #endregion

        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
