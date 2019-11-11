using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PorjetoUfsmArrano.Models
{
    public enum Tipologradouro
    {
        [Display(Name = "Avenida")]
        Avenida,
        [Display(Name = "Alameda")]
        Alameda,
        [Display(Name = "Acesso")]
        Acessp,
        [Display(Name = "Boulevard")]
        Boulevard,
        [Display(Name = "Estrada")]
        Estrada,
        [Display(Name = "Largo")]
        Largo,
        [Display(Name = "Loteamento")]
        Loteamento,
        [Display(Name = "Parque")]
        Parque,
        [Display(Name = "Praça")]
        Praca,
        [Display(Name = "Quadra")]
        Quadra,
        [Display(Name = "Rodovia")]
        Rodovia,
        [Display(Name = "Rua")]
        Rua,
        [Display(Name = "Setor")]
        Setor,
        [Display(Name = "Travessa")]
        Travessa
    }
}