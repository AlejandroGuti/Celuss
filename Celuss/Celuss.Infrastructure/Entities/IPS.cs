using System;
using System.Collections.Generic;
using System.Text;

namespace Celuss.Infrastructure.Entities
{
    public class IPS
    {
        public int Id { get; set; }
        public string NIT { get; set; }
        public string Name { get; set; }
        public ICollection<Doctor> Doctor { get; set; }
        public ICollection<Customer> Customer { get; set; }
        public ICollection< Appointment> Appointments { get; set; }
    }
}
