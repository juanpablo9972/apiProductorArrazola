using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fncConsumidorParcial2.Models
{
    class ModelParcial
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Estudiante { get; set; }
        [Required]
        public float Temperatura { get; set; }
        [Required]
        public string Fecha { get; set; }
        [Required]
        public string Hora { get; set; }
    }
}
