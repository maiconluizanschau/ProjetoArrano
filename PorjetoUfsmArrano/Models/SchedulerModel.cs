using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PorjetoUfsmArrano.Models
{
     [Table("arrano.event")]
    public class CalendarEvent
    {
        //id, text, start_date and end_date properties are mandatory
        public int id { get; set; }
        [Display(Name = "Descrição")]
        [StringLength(850)]
        public string text { get; set; }
          [Display(Name = "Data Inicial")]
        public DateTime start_date { get; set; }
          [Display(Name = "Data Final")]
        public DateTime end_date { get; set; }
    }
}