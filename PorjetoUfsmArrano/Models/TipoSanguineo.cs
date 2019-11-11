using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PorjetoUfsmArrano.Models
{
    public enum TipoSanguineo
    {
        [Display(Name = "Sangue tipo A+")]
        amais,
        [Display(Name = "Sangue tipo A-")]
        amenos,
        [Display(Name = "Sangue tipo B+")]
        bmais,
        [Display(Name = "Sangue tipo B-")]
        abmais,
        [Display(Name = "Sangue tipo AB+")]
        Viúvo,
        [Display(Name = "Sangue tipo AB-")]
        abmenos,
        [Display(Name = "Sangue tipo O+")]
        omais,
        [Display(Name = "Sangue tipo O-")]
        omenos

    }
}