using System;
using System.Collections.Generic;
using System.Text;

namespace Celuss.Domain.DTOs
{
    public class AppointmentRequest
    {
        public string Diagnostic { get; set; }
        public string Hour { get; set; }
        public int DoctorId { get; set; }
        public int CustomerId { get; set; }
        public int IPSId { get; set; }
    }
}
