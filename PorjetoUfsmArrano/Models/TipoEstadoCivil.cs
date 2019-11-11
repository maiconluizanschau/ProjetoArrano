using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PorjetoUfsmArrano.Models
{
    public enum tipoestadocivil
    {
        [Display(Name = "Solteiro(a)")]
        Solteiro,
        [Display(Name = "Casado(a)")]
        Casado,
        [Display(Name = "Separado")]
        Separado,
        [Display(Name = "Divorciado(a)")]
        Divorciado,
        [Display(Name = "Viúvo(a)")]
        Viúvo,
        [Display(Name = "Companheiro(a)")]
        Companheiro
    }
}