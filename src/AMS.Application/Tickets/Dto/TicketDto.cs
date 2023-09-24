using AMS.ReplyTickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Tickets.Dto
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public string Department { get; set; }
        public TicketPriority Priority { get; set; }
        public TicketStatus Status { get; set; }
        public long UserId { get; set; }
        public string CreationTime { get; set; }

        //dto ReplyTicket
        public TicketMessageDto[] TicketMessageDto { get; set; }
    }
}
