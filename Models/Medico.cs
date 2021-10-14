using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico{ get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Nombre", Prompt = "Ingrese el campo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Apellido", Prompt = "Ingrese el campo")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Dirección", Prompt = "Ingrese el campo")]
        public string  Direccion{ get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Telefono", Prompt = "Ingrese el campo")]
        public string  Telefono{ get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Email", Prompt = "Ingrese el campo")]
        [EmailAddress(ErrorMessage = "No es una dirección de email válida")]
        public string  Email{ get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Horario desde", Prompt = "Ingrese el campo")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionDesde {get;set;}
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Horario hasta", Prompt = "Ingrese el campo")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime HorarioAtencionHasta {get;set;}
        public virtual List<MedicoEspecialidad> MedicoEspecialidad { get; set; } 
        public virtual List<Turno> Turno { get; set; }
        
    }
}