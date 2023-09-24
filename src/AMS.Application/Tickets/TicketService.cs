using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using AMS.Authorization;
using AMS.Authorization.Roles;
using AMS.Authorization.Users;
using AMS.ReplyTickets;
using AMS.Tickets.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;


namespace AMS.Tickets
{
    [AbpAuthorize(PermissionNames.Pages_Ticket)]
    public class TicketService: AMSAppServiceBase‏,ITicketService
    {

        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<TicketMessage> _ticketMessageRepository;
        private readonly UserManager _userManager;
        private readonly IAbpSession _abpSession;


        public TicketService(IRepository<Ticket> ticketRepository , IRepository<TicketMessage> ticketMessageRepository,
            UserManager userManager, IAbpSession abpSession) {
            _ticketRepository = ticketRepository;
            _ticketMessageRepository = ticketMessageRepository;
            _userManager = userManager;
            _abpSession = abpSession;
        }

        public async Task<UpsertTicketOutput> UpsertTicket(UpsertTicketInput input)
        {

            //Ticket newTicket = new Ticket
            //{
            //    Department = input.Department,
            //    Priority = input.Priority,
            //    Status = TicketStatus.Open,
            //    TicketMessages = new List<TicketMessage>()
            //    {

            //    }
            //};

            TicketMessage newMessage = new TicketMessage
            {
                Message = input.Message
            };

            Ticket newTicket = new Ticket();
            newTicket.Department = input.Department;
            newTicket.Priority = input.Priority;
            newTicket.Status = input.Status;
            newTicket.TicketMessages = new List<TicketMessage>()
            {
               new TicketMessage { Message = input.Message }
            };

            await _ticketRepository.InsertAsync(newTicket);

            return new UpsertTicketOutput() { Result = true};
        }
        //public async Task<UpdateTicketOutput> UpdateTicket(UpdateTicketInput input)
        //{


        //    var ticket = await _ticketRepository.GetAll().Where(x => x.Id == input.TicketId).Select(x => new Ticket
        //    {
        //        Id = x.Id,
        //    }).FirstOrDefaultAsync();

        //    ticket.Title = input.Title;
        //    ticket.Subject = input.Subject;
        //    ticket.Priority = input.Priority;
        //    ticket.Description = input.Description;

        //    await _ticketRepository.UpdateAsync(ticket);

        //    return new UpdateTicketOutput();
        //}
        public async Task<GetTicketOutput> GetTicket(GetTicketInput input)
        {
            //پرسیده شود برای اینام ها
            //var res = new GetTicketOutput()
            //{
            //    Priorities = AMSHelper.GetEnumValues(typeof(Priority), LocalizationManager),
            //    Statuses = AMSHelper.GetEnumValues(typeof(TicketStatus), LocalizationManager)
            //};

            var res = new GetTicketOutput();

            var ticket = await _ticketRepository.GetAll().Where(x => x.Id == input.TicketId).Select(r => new
            {
                r.Id,
                r.Department,
                r.CreationTime,
                r.Status,
                r.Priority
            }
            ).FirstOrDefaultAsync();

            if (ticket == null)
            {
                throw new UserFriendlyException(L("Error"), L("TheItemWasNotFound"));
            }

            var messagesTicket = await _ticketMessageRepository.GetAll().Where(x => x.TicketId == ticket.Id).Select(t => new
            {
                t.Id,
                t.Message,
                t.CreationTime,
                t.CreatorUser.FullName
            }).ToArrayAsync();

            res.Ticket = new TicketDto
            {
                TicketId = ticket.Id,
                Department = ticket.Department,
                CreationTime = ticket.CreationTime.ToString(),
                Status = ticket.Status,
                Priority = ticket.Priority,
                TicketMessageDto = messagesTicket.Select(x => new TicketMessageDto
                { 
                    Message = x.Message,
                    CreationTime=x.CreationTime
                }).ToArray()
            };

            return res;
        }
        
        public async Task<GetTicketsOutput> GetTickets(GetTicketsInput input)
        {
            var currentUser = await _userManager.GetUserByIdAsync(_abpSession.GetUserId());
            var roles = await _userManager.GetRolesAsync(currentUser);
            
            var query = _ticketRepository
              .GetAll();

            //paging

            if (roles.Contains(StaticRoleNames.Tenants.User))
            {
                query = query.Where(x => x.CreatorUserId == currentUser.Id);
            }

            var data = await query.Select(t => new
            {
                t.Id,
                t.Department,
                t.CreationTime,
                t.Status
            }).ToListAsync();


            return new GetTicketsOutput()
                {
                    Tickets = query
                .Select(p => new TicketDto()
                {
                    Department = p.Department,
                    CreationTime = p.CreationTime.ToString(),
                    Status = p.Status
                }).ToArray()
            };
            

            //else
            //{
            //  //var query = await _ticketRepository
            //  //      .GetAll()
            //  //      .Select(t => new
            //  //      {
            //  //          t.Id,
            //  //          t.Subject,
            //  //          t.Title,
            //  //          t.CreationTime,
            //  //          t.Status,
            //  //      }).ToListAsync();

            //    return new GetTicketsOutput()
            //    {
            //        Tickets = query
            //    .Select(p => new TicketDto()
            //    {
            //        TicketId = p.Id,
            //        Title = p.Title,
            //        Subject = p.Subject,
            //        CreationTime = p.CreationTime.ToString(),
            //        Status = p.Status
            //    }).ToArray()
            //    };
            //}
        }
        public async Task<ReplyTicketOutput> ReplyTicket(ReplyTicketInput input)
        {

            await _ticketMessageRepository.InsertAsync(new TicketMessage
            {
                TicketId = input.TicketId,
                Message = input.Message,
            });

            var ticket =await _ticketRepository.FirstOrDefaultAsync(x => x.Id == input.TicketId);
            ticket.Status = TicketStatus.Answer;

            return new ReplyTicketOutput() { Result = true};
        }

        [AbpAuthorize(PermissionNames.Pages_Tickets_Admin)]
        public async Task<CloseTicketOutput> CloseTicket(CloseTicketInput input)
        {
            var res = await _ticketRepository.GetAll().Where(x => x.Id == input.TicketId).FirstOrDefaultAsync();

            res.Status = TicketStatus.Close;


            return new CloseTicketOutput() { Result = true};
        }

    }
}
