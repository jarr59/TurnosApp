using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Especialidad
    {
        [Key]
        public int IdEspecialidad { get; set; }
        [Required(ErrorMessage = "Debe ingresar una descripción")]
        [Display(Name = "Descripción", Prompt = "Ingrese una descripción")]
        [StringLength(200,ErrorMessage = "Debe contener menos de 200 de carácteres")]
        public string Descripcion { get; set; }
        public virtual List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}