using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Tickets.Dto
{
    public class ReplyTicketInput
    {
        public int TicketId { get; set; }
        public string Message { get; set; }
    }
}
