using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PorjetoUfsmArrano.Models
{
    public enum TipoBase
    {
        [Display(Name = "Base Áerea")]
        BaseAerea,
        [Display(Name = "Base Naval")]
        BaseNaval,
        [Display(Name = "Base Temporária")]
        BaseTemporaria,
        [Display(Name = "Base Militar")]
        BaseMilitar
    }
}