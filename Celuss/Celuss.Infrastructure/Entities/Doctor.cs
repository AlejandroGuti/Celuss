using System;
using System.Collections.Generic;
using System.Text;

namespace Celuss.Infrastructure.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Code { get; set; }
        public int CC { get; set; }
        public ICollection< Appointment> Appointment { get; set; }
        public IPS IPS { get; set; }
    }
}
