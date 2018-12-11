using System;
using System.Collections.Generic;

namespace CannabisWeb.Models
{
    public partial class Types
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int PostedBy { get; set; }
        public DateTime PostedDate { get; set; }
        public string Thc { get; set; }
        public string Cbd { get; set; }
        public string SideEffects { get; set; }
        public int? High { get; set; }
        public int? PainReliever { get; set; }
        public int? EaseMigraine { get; set; }
        public int? ReduceAnxiety { get; set; }
        public int? IncreaseApetite { get; set; }

        public User PostedByNavigation { get; set; }
    }
}
