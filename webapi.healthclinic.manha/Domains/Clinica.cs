using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.manha.Domains
{
    

        [Table(nameof(Clinica))]
        public class Clinica
        {
            [Key]

            public Guid IdClinica { get; set; } = Guid.NewGuid();

            [Column(TypeName = "VARCHAR(150)")]
            [Required(ErrorMessage = "Nome fantasia obrigatorio!")]
            public string? NomeFantasia { get; set; }

            [Column(TypeName = "VARCHAR(150)")]
            [Required(ErrorMessage = "Endereco obrigatorio!")]
            public string? Endereco { get; set; }

            [Column(TypeName = "VARCHAR(14)")]
            [Required(ErrorMessage = "CNPJ obrigatorio!")]
            [StringLength(14)]
            public string? CNPJ { get; set; }
        }
    }

