using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Nombre", Prompt = "Ingrese el nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Apellido", Prompt = "Ingrese el apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Dirección", Prompt = "Ingrese la dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Teléfono", Prompt = "Ingrese el número teléfonico")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Email", Prompt = "Ingrese el email")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        public virtual List<Turno> Turno { get; set; }
    }
}