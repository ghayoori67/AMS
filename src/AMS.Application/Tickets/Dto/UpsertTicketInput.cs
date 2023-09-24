using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Tickets.Dto
{
    public class UpsertTicketInput
    {

        public string Department { get; set; }
        public string Message { get; set; }
        public TicketPriority Priority { get; set; }
        public TicketStatus Status { get; set; }
    }
}
