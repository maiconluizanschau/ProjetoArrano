using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PorjetoUfsmArrano.Models
{
    public enum TipoTreinamento
    {
        [Display(Name = "Treinamento físico")]
        fisico,
        [Display(Name = "treinamento Psíquicos")]
        psiquico,
        [Display(Name = "Treinamento de Campo(Guerra)")]
        campo,
        [Display(Name = "Treinamento de salvamento")]
        salvamento,
        [Display(Name = "Treinamento Tático")]
        tatico,
        [Display(Name = "Treinamento de tomada de decisão")]
        decisao,
        [Display(Name = "Treinamento de ações de pronta-tarefa")]
        pronta,
        [Display(Name = "Treinamento atividades de intendência")]
        interdencia,
        [Display(Name = "Treinamento de engenharia militar")]
        engenharia

    }
}