using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P4_LAB4_API
{
    public class Seasons
    {
        [Key]
        public int Season_Id { get; set; }
        public string School { get; set; }
    }
}