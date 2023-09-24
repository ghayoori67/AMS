using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Tickets.Dto
{
    public class UpdateTicketInput
    {
        public int TicketId { get; set; }
        public string Title { get; set; }
        public short Priority { get; set; }
        public bool Close { get; set; }
        public int UserId { get; set; }
    }
}
