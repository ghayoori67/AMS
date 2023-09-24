using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using AMS.Authorization.Users;
using AMS.ReplyTickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Tickets
{
    public class Ticket: Entity,IAudited
    {
        //TicketDepartment
        public string Department  { get; set; }

        /// <summary>
        /// اهمیت تیکت
        /// </summary>
        public TicketPriority Priority { get; set; }

        /// <summary>
        /// وضعیت تیکت
        /// </summary>
        public TicketStatus Status { get; set; }


        //public string File { get; set; }

        #region Relations
        public User User { get; set; }
        public ICollection<TicketMessage> TicketMessages { get; set; }
        #endregion


        //foreign key
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set ; }


        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
