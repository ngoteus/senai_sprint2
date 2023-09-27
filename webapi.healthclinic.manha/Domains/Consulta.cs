using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]

        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Medico obrigatorio!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]

        public Medico? Medico { get; set; }

        [Required(ErrorMessage = "Paciente e obrigatorio!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]

        public Paciente? Paciente { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data da consulta obrigatoria!")]
        public DateTime DataConsulta { get; set; }

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horario da consulta obrigatoria!")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"hh\:mm")]
        public TimeSpan HorarioConsulta { get; set; }

        [Column(TypeName = "VARCHAR(256)")]
        [Required(ErrorMessage = "Prontuario obrigatorio!")]
        public string? Prontuario { get; set; }
        

    }
}
