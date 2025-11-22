using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint1.Models
{
    public enum SexoEnum { M, F }
    public enum ModeloTrabalhoEnum { PRESENCIAL, HÍBRIDO, REMOTO }
    public enum RoleEnum { USER, PREMIUM, ADM }

    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("senha_hash")]
        public string SenhaHash { get; set; }

        [Column("altura")]
        public decimal Altura { get; set; }

        [Column("peso")]
        public decimal Peso { get; set; }

        [Column("sexo")]
        public SexoEnum Sexo { get; set; }

        [Column("modelo_trabalho")]
        public ModeloTrabalhoEnum ModeloTrabalho { get; set; }

        [Column("role")]
        public RoleEnum Role { get; set; }

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        // FK para Dispositivo
        [Column("dispositivo_id")]
        public string DispositivoId { get; set; }
        public Dispositivo? Dispositivo { get; set; }
    }
}