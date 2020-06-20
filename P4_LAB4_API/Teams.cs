using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace P4_LAB4_API
{
    public class Teams
    {
        [JsonIgnore]
        [Key]
        public int Team_Id { get; set; }
        public string School { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public List<Coaches> Coaches { get; set; } 




    }
}