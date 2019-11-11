using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PorjetoUfsmArrano.Models
{
     [Table("arrano.avaliar")]
    public partial class Avaliar
    {
        [Key]
        [Column(Order = 0)]
        public int id_avaliacao { get; set; }


        [Display(Name = "Nome")]
        [StringLength(850)]
        public string nome { get; set; }


        [Display(Name = "Descricao")]
        [StringLength(850)]
        public string descricao { get; set; }


        [Display(Name = "Nota")]
        public float nota { get; set; }

        [Display(Name = "Nome Militar")]
  
        public int id_militar { get; set; }


        [Display(Name = "Treinamento")]
     
        public int id_treinamento { get; set; }


        [Display(Name = "Base Militar")]
  
        public int id_basemilitar { get; set; }


        [NotMapped]
        public string Base
        {
            get
            {
                BasesMilitaresContext db = new BasesMilitaresContext();
                BasesMilitares b = db.BasesMilitares.Find(id_basemilitar);
                if (b != null)
                    return b.NomeFantasia;
                return "Não cadastrado";
            }
        }

        [NotMapped]
        public string Militar
        {
            get
            {
                BasesMilitaresContext db = new BasesMilitaresContext();
                BasesMilitares b = db.BasesMilitares.Find(id_militar);
                if (b != null)
                    return b.NomeFantasia;
                return "Não cadastrado";
            }
        }



        [NotMapped]
        public string Treinamento
        {
            get
            {
                BasesMilitaresContext db = new BasesMilitaresContext();
                BasesMilitares b = db.BasesMilitares.Find(id_treinamento);
                if (b != null)
                    return b.NomeFantasia;
                return "Não cadastrado";
            }
        }


    }
}