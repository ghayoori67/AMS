using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AMS.Tickets.Dto;
using AMS.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Tickets
{
    public interface ITicketService: IApplicationService‏
    {
        Task<GetTicketsOutput> GetTickets(GetTicketsInput input);
        Task<GetTicketOutput> GetTicket(GetTicketInput input);
        //Task<UpdateTicketOutput> UpdateTicket(UpdateTicketInput input);
        Task<ReplyTicketOutput> ReplyTicket(ReplyTicketInput reply);
        Task<CloseTicketOutput> CloseTicket(CloseTicketInput input);
        Task<UpsertTicketOutput> UpsertTicket(UpsertTicketInput input);
    }
}
