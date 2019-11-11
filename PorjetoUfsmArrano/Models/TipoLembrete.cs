using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PorjetoUfsmArrano.Models
{
    public enum tipolembrete
    {
        [Display(Name = "Diário")]
        Dia,
        [Display(Name = "Hora em Hora")]
        Hora,
        [Display(Name = "Semanal")]
        Semanal,
        [Display(Name = "Mensal")]
        Mensal,
        [Display(Name = "Anual")]
        Anual,
        [Display(Name = "4 em 4 dias")]
        dias
    }
}