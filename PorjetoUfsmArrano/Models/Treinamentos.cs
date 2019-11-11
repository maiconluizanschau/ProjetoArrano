using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;

namespace PorjetoUfsmArrano.Models
{

    [Table("arrano.treinamentos")]
    public partial class Treinamentos
    {
        [Key]
        [Column(Order = 0)]
        public int id_treinamentos { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Treinamento")]
        public string data { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Previsão Inicio do Treinamento")]
        public string datainicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Previsão Fim do Treinamento")]
        public string datafim { get; set; }


        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH-MM-ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Duração Prevista")]
        public string duracao { get; set; }

        [Display(Name = "Status Treinamento")]
        public statustreinamento statustreinamento { get; set; }

        [Display(Name = "Hora")]
        public string hora { get; set; }



        [Display(Name = "Tipo Treinamento")]
        public TipoTreinamento tipotreinamento { get; set; }

        [Display(Name = "Nome da Base Militar Vinculada")]
        [Column(Order = 1)]
        public int id_base { get; set; }

     


        //[Display(Name = "Equipamentos")]
        //public bool TipoEquipamento{ get; set; }

        //[Display(Name = "Equipamentos Utilizados no Treinamento")]
        //[StringLength(525)]
        //public string Equipamentos { get; set; }


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