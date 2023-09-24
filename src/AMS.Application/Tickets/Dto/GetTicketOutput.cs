using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Tickets.Dto
{
    public class GetTicketOutput
    {
        public GetTicketOutput()
        {
            Ticket = new TicketDto();
        }
        public TicketDto Ticket { get; set; }
        public NameValueDto<int>[] Priorities { get; set; }
        public NameValueDto<int>[] Statuses { get; set; }
        //public int TicketId { get; set; }
        //public string Title { get; set; }
        //public string Subject { get; set; }
        //public string Description { get; set; }
        //public short Priority { get; set; }
        //public bool Close { get; set; }
        //public long UserId { get; set; }
        //public string CreateDate { get; set; }
    }
}
