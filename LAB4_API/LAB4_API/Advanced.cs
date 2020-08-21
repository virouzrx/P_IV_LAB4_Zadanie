using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LAB4_API
{
    public class Advanced
    {

        [Key]
        public int Id { get; set; }
        public string Team { get; set; }
        public string Conference { get; set; }
        public string Mascot { get; set; }
    }
}
