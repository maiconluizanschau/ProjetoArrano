using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;

namespace PorjetoUfsmArrano.Models
{

      [Table("arrano.lembretes")]
    public partial class Lembretes
    {
        [Key]
        [Column(Order = 0)]
        public int id_lembretes { get; set; }




        [Display(Name = "Título do Lembrete")]
        [Required(ErrorMessage = "Ops!,Informe o titulo")]
        [DataType(DataType.Text, ErrorMessage = "Ops,Informe somente texto")]
        public string titulo { get; set; }



        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Ops!, Informe a descrição simples.")]
        [DataType(DataType.Text, ErrorMessage = "Ops!, Informe somente texto.")]
        public string descricaosimples { get; set; }


        [Display(Name = "Descrição Completa: ")]
        [Required(ErrorMessage = "Ops!, Informe a descrição completa.")]
        [DataType(DataType.Text, ErrorMessage = "Ops!, Informe somente texto.")]
        public string DescricaoCompleta { get; set; }

        [Display(Name = "Data: ")]
        [Required(ErrorMessage = "Ops!, Informe a data.")]
        [DataType(DataType.Date, ErrorMessage = "Ops!, Informe somente data válida.")]
        public DateTime Data { get; set; }

        public DateTime Gravado { get; set; }


        [Display(Name = "Lembrete")]
        public tipolembrete tipolembrete { get; set; }


        [Display(Name = "Militar")]
        public int id_militar { get; set; }


        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}