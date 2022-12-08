using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anniversary.Models
{
    public class Anniversary
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }
        public int ActiveStatus { get; set; }
    }
}