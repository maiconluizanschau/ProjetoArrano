using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PorjetoUfsmArrano.Models
{
    public class Event
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }


        [Display(Name = "Descrição")]
        [StringLength(850)]
        public string text { get; set; }

        [Display(Name = "Descrição")]
        public DateTime start_date { get; set; }


        [Display(Name = "Descrição")]
        public DateTime end_date { get; set; }
    }
}