using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Tickets
{


        public enum TicketStatus
        {
            [Display(Name ="TicketStatusOpen")]
            Open=1,
            [Display(Name = "TicketStatusAnswer")]
            Answer = 2,
            [Display(Name = "TicketStatusClose")]
            Close =3
        }
  
}
