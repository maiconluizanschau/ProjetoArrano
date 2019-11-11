using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PorjetoUfsmArrano.Models
{
    public enum TipoUf
    {
        [Display(Name = "Acre (AC)")]
        ac,
        [Display(Name = "Alagoas (AL)")]
        al,
        [Display(Name = "Amapá (AP)")]
        ap,
        [Display(Name = "Amazonas (AM)")]
        am,
        [Display(Name = "Bahia (BA)")]
        ba,
        [Display(Name = "Ceará (CE)")]
        ce,
        [Display(Name = "Distrito Federal (DF)")]
        df,
        [Display(Name = "Espírito Santo (ES)")]
        es,
        [Display(Name = "Distrito Federal (DF)")]
        go,
        [Display(Name = "Goiás (GO)")]
        omais,
        [Display(Name = "Maranhão (MA)")]
        ma,
        [Display(Name = "Mato Grosso (MT)")]
        mt,
        [Display(Name = "Mato Grosso do Sul (MS)")]
        ms,
        [Display(Name = "Minas Gerais (MG)")]
        mg,
        [Display(Name = "Pará (PA)")]
        pa,
        [Display(Name = "Paraíba (PB)")]
        pb,
        [Display(Name = "Paraná (PR)")]
        pr,
        [Display(Name = "Piauí (PI)")]
        pi,
        [Display(Name = "Pernambuco (PE)")]
        pe,
        [Display(Name = "Rio de Janeiro (RJ)")]
        rj,
        [Display(Name = "Rio Grande do Norte (RN)")]
        rn,
        [Display(Name = "Rio Grande do Sul (RS)")]
        rs,
        [Display(Name = "Rondônia (RO)")]
        ro,
        [Display(Name = "Roraima (RR)")]
        rr,
        [Display(Name = "Santa Catarina (SC)")]
        sc,
        [Display(Name = "São Paulo (SP)")]
        sp,
        [Display(Name = "Sergipe (SE)")]
        se,
        [Display(Name = "Tocantins (TO)")]
        to
    }
}