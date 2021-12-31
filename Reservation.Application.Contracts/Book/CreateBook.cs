using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Application.Contracts.Book
{
    public class CreateBook
    {
        public string Name { get; set; }
        public int BookPrice { get; set; }
        public int CategoryId { get; set; }
        public string Author { get; set; }
    }
}
