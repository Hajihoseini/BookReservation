using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Application.Contracts.BookCategory
{
    public class EditBookCategory : CreateBookCategory
    {
        public int Id { get; set; }
    }
}
