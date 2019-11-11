using MySql.Web.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using MySql.Web.Properties;

namespace PorjetoUfsmArrano.Models
{
     [Table("arrano.cameras")]
    public partial class Cameras
    {

        [Key]
        [Column(Order = 0)]
        public int id { get; set; }


        [Required(ErrorMessage = "Campo Descrição é obrigatório")]
        [StringLength(445)]
        public string descricao { get; set; }


        [Required(ErrorMessage = "Campo IP é obrigatório")]
        [StringLength(45)]
        public string ip { get; set; }



        [Required(ErrorMessage = "Campo Login é obrigatório")]
        [StringLength(45)]
        public string login { get; set; }


        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        [StringLength(45)]
        public string senha { get; set; }

        [Display(Name = "Modelo:")]
        public PorjetoUfsmArrano.Controllers.ToolCameras.Marcas id_tipo { get; set; }

      


        [Display(Name = "Treinamento:")]
        public int id_treinamentos { get; set; }

        [NotMapped]
        public string Stream
        {
            get
            {
                return Controllers.ToolCameras.GetStream(id);
            }
        }

    }

}