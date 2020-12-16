using System;
using System.Collections.Generic;
using System.Text;

namespace Celuss.Domain.DTOs
{
    public class CustomerRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public int CC { get; set; }
        public int IPSId { get; set; }
    }
}
