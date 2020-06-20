using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P4_LAB4_API
{
    public class Coaches
    {
        [Key]
        public int CoachId { get; set; }
        public string Coach_first_name { get; set; }
        public string Coach_last_name { get; set; }
        public List<Seasons> Seasons { get; set; }
    }
}