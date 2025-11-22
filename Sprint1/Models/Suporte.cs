using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint1.Models
{
    public enum StatusSuporte { AGUARDANDO, EM_AVALIACAO, EM_TRATAMENTO, RESOLVIDO, ENCERRADO, CANCELADO }

    [Table("suporte")]
    public class Suporte
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("titulo")]
        public string Titulo { get; set; }

        [Required]
        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("data_reclamacao")]
        public DateTime DataReclamacao { get; set; } = DateTime.Now;

        [Column("data_resolucao")]
        public DateTime? DataResolucao { get; set; }

        [Column("status")]
        public StatusSuporte Status { get; set; } = StatusSuporte.AGUARDANDO;

        // Relacionamento 1: Quem abriu o chamado (Usuario)
        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        public Usuario? Solicitante { get; set; }

        // Relacionamento 2: Quem atendeu (Admin)
        [Column("admin_id")]
        public int? AdminId { get; set; }
        public Usuario? Atendente { get; set; }
    }
}