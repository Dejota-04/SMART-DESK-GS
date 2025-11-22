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

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Column("nome")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
        [Column("email")]
        [Display(Name = "E-mail Corporativo")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [Column("senha_hash")]
        [Display(Name = "Senha")]
        public string SenhaHash { get; set; } = string.Empty;

        // REGRA DE NEGÓCIO (INVARIANTE)
        [Column("altura")]
        [Range(1.00, 2.50, ErrorMessage = "A altura deve estar entre 1,00m e 2,50m.")]
        [Display(Name = "Altura (m)")]
        public decimal Altura { get; set; }

        // REGRA DE NEGÓCIO (INVARIANTE)
        [Column("peso")]
        [Range(30, 300, ErrorMessage = "O peso deve estar entre 30kg e 300kg.")]
        [Display(Name = "Peso (kg)")]
        public decimal Peso { get; set; }

        [Column("sexo")]
        [Display(Name = "Sexo Biológico")]
        public SexoEnum Sexo { get; set; }

        [Column("modelo_trabalho")]
        [Display(Name = "Modelo de Trabalho")]
        public ModeloTrabalhoEnum ModeloTrabalho { get; set; }

        [Column("role")]
        [Display(Name = "Perfil de Acesso")]
        public RoleEnum Role { get; set; }

        [Column("data_cadastro")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        // FK para Dispositivo
        [Column("dispositivo_id")]
        [Display(Name = "Dispositivo IoT")]
        public string DispositivoId { get; set; } = string.Empty;

        public Dispositivo? Dispositivo { get; set; }
    }
}