using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RHSoft.Study.Monitoring.Models
{
    public class SiteModel
    {
        [Required( ErrorMessage = "Не указан адрес" )]
        [RegularExpression( @"[https://]+[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес" )]
        public string url { get; set; }
        public int LastStatus { get; set; }
        public Guid userId { get; set; }
        public Guid id { get; set; }
        public DateTime timeAdd { get; set; }
    }
}
