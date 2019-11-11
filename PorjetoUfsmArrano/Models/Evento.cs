using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PorjetoUfsmArrano.Models
{
    [Table("arrano.Evento")]
    public class Evento
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime? DataFinal { get; set; }

        public string Cor { get; set; }

     
           
    }
}