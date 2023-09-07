using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CallRecord
    {
        public int Id { get; set; }
        public string? IP {  get; set; }
        public DateTime DateTime { get; set; }
        public string? RequestMethod { get; set; }
        public string? RequestPath { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
