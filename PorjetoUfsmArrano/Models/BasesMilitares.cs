using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PorjetoUfsmArrano.Models
{
    [Table("arrano.basesmilitares")]
    public partial class BasesMilitares
    {
        [Key]
        [Column(Order = 0)]
        public int id_BasesMilitares { get; set; }

        [Required(ErrorMessage = "Nome da Base militar é Obrigatória")]
        [StringLength(300)]
        [Display(Name = "Nome Base Militar")]
        public string nome { get; set; }


        [StringLength(1300)]
        [Display(Name = "Descricao")]
        public string descricao { get; set; }

        [Display(Name = "Designação")]
        public TipoBase TipoBase { get; set; }

        [Display(Name = "Logradouro")]
        public Tipologradouro Tipologradouro { get; set; }


        [Display(Name = "Rua")]
        [StringLength(80)]
        public string Rua { get; set; }

        [Display(Name = "Endereço")]
        [StringLength(45)]
        public string endereco { get; set; }

        [Display(Name = "Complemento")]
        [StringLength(100)]
        public string complemento { get; set; }


        [Display(Name = "Número")]
        public string numero { get; set; }

        [Display(Name = "Bairro")]
        [StringLength(90)]
        public string bairro { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(100)]
        public string cidade { get; set; }

        [Display(Name = "Estado")]
        [StringLength(2)]
        public string uf { get; set; }


        [Display(Name = "Email")]
        [StringLength(50)]
        public string email { get; set; }

        [Display(Name = "Nome Contato")]
        [StringLength(100)]
        public string nome_contato { get; set; }

        [Display(Name = "País")]
        [StringLength(50)]
        public string pais { get; set; }


        [Display(Name = "Logo")]
        public byte[] logo { get; set; }

        [Display(Name = "Latitude/longitude")]
        [StringLength(70)]
        public string latlon { get; set; }

        [Display(Name = "CEP")]
        [StringLength(25)]
        public string Cep { get; set; }


        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Fantasia é obrigatório")]
        [Display(Name = "Nome Fantasia")]
        [StringLength(45)]
        public string NomeFantasia { get; set; }
    }
}