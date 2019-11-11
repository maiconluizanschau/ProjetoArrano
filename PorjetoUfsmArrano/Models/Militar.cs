using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Web.Security;

namespace PorjetoUfsmArrano.Models
{
    [Table("arrano.militar")]
    public partial class Militar
    {
        [Key]
        [Column(Order = 0)]
        public int id_militar { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "É necessário informar o nome do militar", AllowEmptyStrings = false)]
        [StringLength(60)]
        public string nome { get; set; }


        [Display(Name = "Email")]
        [StringLength(70)]
        public string email { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(40)]
        public string telefone { get; set; }

        [Display(Name = "Identificação")]
        [StringLength(40)]
        public string identificacao { get; set; }


        [Display(Name = "Sobrenome")]
        [StringLength(40)]
        public string sobrenome { get; set; }

        [Display(Name = "Nacionalidade")]
        [StringLength(40)]
        public string nacionalidade { get; set; }


        [Display(Name = "Cpf")]
        [StringLength(40)]
        public string cpf { get; set; }

        [Display(Name = "Carteira de Identidade")]
        [StringLength(40)]
        public string rg { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public DateTime datanascimento { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(40)]
        public string cidadenascimento { get; set; }

        [Display(Name = "Tipo Sanguíneo")]
        public TipoSanguineo tiposanguineo { get; set; }

        [Display(Name = "Altura")]
        public float altura { get; set; }

        [Display(Name = "Peso")]
        public float peso { get; set; }

        [Display(Name = "Imagem Militar")]
        public byte[] foto { get; set; }


        [Display(Name = "Nome Mãe")]
        [Required(ErrorMessage = "É necessário digitar o nome completo da mãe", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string nomemae { get; set; }

        [Display(Name = "Nome Pai")]
        [Required(ErrorMessage = "É necessário digitar o nome completo do pai", AllowEmptyStrings = false)]
        [StringLength(50)]
        public string nomepai { get; set; }

        [Display(Name = "Estado de Origem")]
        public TipoUf tipouf { get; set; }

        [Display(Name = "Selecione Estado Civil")]
        public tipoestadocivil tipoestadocivil { get; set; }

        [Display(Name = "Militar")]
        public TipoMilitar tipomilitar { get; set; }

          [Display(Name = "Idade do Militar")]
        public string idade { get; set; }


        [Display(Name = "Nome da Base Militar Vinculada")]
        [Column(Order = 1)]
        public int id_base { get; set; }











    }
}