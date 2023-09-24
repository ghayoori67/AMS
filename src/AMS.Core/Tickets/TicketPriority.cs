using System.ComponentModel.DataAnnotations;

namespace AMS.Tickets
{

        public enum TicketPriority
        {
            [Display(Name = "TicketPriorityLow")]
            Low =1,
            [Display(Name = "TicketPriorityHigh")]
            High =2
        }

}
