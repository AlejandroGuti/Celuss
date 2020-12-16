using System;
using System.Collections.Generic;
using System.Text;

namespace Celuss.Infrastructure.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Diagnostic { get; set; }
        public string Hour { get; set; }
        public Doctor Doctor { get; set; }
        public Customer Customer { get; set; }
        public IPS IPS { get; set; }
    }
}
