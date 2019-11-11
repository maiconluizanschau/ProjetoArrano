using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PorjetoUfsmArrano.Models
{
    public enum statustreinamento
    {
        [Display(Name = "Aberto")]
        Aberto,
        [Display(Name = "Em Execução")]
        Execução,
        [Display(Name = "Em Atraso")]
        Atraso,
        [Display(Name = "Reaberto")]
        Reaberto,
        [Display(Name = "Fechado")]
        Fechado
    }
}