using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Tickets.Dto
{
    public class GetTicketsOutput
    {
        public TicketDto[] Tickets {  get; set; }
    }
}
