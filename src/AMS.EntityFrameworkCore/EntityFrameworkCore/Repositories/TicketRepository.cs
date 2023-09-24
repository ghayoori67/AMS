using AMS.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.EntityFrameworkCore.Repositories
{

    public class TicketRepository
    {
        public readonly AMSDbContext _aMSDbContext;
        public TicketRepository(AMSDbContext aMSDbContext)
        {
            _aMSDbContext = aMSDbContext;
        }

    }
}
