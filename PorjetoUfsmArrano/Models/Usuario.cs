using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Web.Security;

namespace PorjetoUfsmArrano.Models
{
    [Table("arrano.usuario")]
    public partial class Usuario
    {
        [Key]
        [Column(Order = 0)]
        public int id_usuario { get; set; }


     
 
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "É necessário digitar a senha", AllowEmptyStrings = false)]
        [StringLength(20)]
        public string senha { get; set; }

        [Display(Name = "Nome da Base Militar Vinculada")]
        [Column(Order = 1)]
        public int id_base { get; set; }

        [Display(Name = "Master")]
        public bool master { get; set; }

        //cookie
        //public System.Web.HttpCookieCollection Cookies { get; }

       

        [Display(Name = "Email")]
        [StringLength(80)]
        public string email { get; set; }


        [Display(Name = "Usuário")]
        [StringLength(80)]
        public string login { get; set; }


        [Display(Name = "Nome")]
        [StringLength(90)]
        public string nome { get; set; }

        [Display(Name = "Sobrenome")]
        [StringLength(100)]
        public string sobrenome { get; set; }

         [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Cadastro")]
        public DateTime Data { get; set; }


        [Display(Name = "Telefone")]
        [StringLength(30)]
        public string telefone { get; set; }

        [NotMapped]
        public string Bases
        {
            get
            {
                BasesMilitaresContext db = new BasesMilitaresContext();
                BasesMilitares b = db.BasesMilitares.Find(id_base);
                if (b != null)
                    return b.NomeFantasia;
                return "Não cadastrado";
            }
        }
    }
}