using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LAB4_API
{
    public class Teams
    {
        [Key]
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string School { get; set; }
        public string Team { get; set; }
        public string Mascot { get; set; }
        //musi być foreign key jakiś
        [ForeignKey("KONFA")]
        public string Conference { get; set; } 
        

    }
}
