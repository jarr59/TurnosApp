namespace Turnos.Models
{
    public class MedicoEspecialidad
    {
        public int IdMedico { get; set; }
        public int IdEspecialidad { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Especialidad Especialidad { get; set;}
    }
}