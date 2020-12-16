using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Celuss.Domain.DTOs
{
    public class IPSRequest
    {
        [Required]
        public string NIT { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
