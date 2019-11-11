using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PorjetoUfsmArrano.Models
{
    public enum TipoMilitar
    {
        [Display(Name = "Soldado")]
        Soldado,
        [Display(Name = "Cabo")]
        Cabo,
        [Display(Name = "Terceiro Sargento")]
        TerceiroSargento,
        [Display(Name = "Segundo Sargento")]
        SegundoSargento,
        [Display(Name = "Primeiro Sargento")]
        PrimeiroSargento,
        [Display(Name = "Subtenente")]
        Subtenente,
        [Display(Name = "Aspirante")]
        Aspirante,
        [Display(Name = "Segundo Tenente")]
        SegundoTenente,
        [Display(Name = "Primeiro Tenente")]
        PrimeiroTenente,
        [Display(Name = "Capitão")]
        Capitão,
        [Display(Name = "Major")]
        Major,
        [Display(Name = "Tenente Coronel")]
        TenenteCoronel,
        [Display(Name = "Coronel")]
        Coronel,
        [Display(Name = "General de Brigada")]
        GeneraldeBrigada,
        [Display(Name = "General de Divisão")]
        GeneraldeDivisao,
        [Display(Name = "General do Exército")]
        GeneraldoExercito,
        [Display(Name = "Marechal")]
        Marechal

    }
}