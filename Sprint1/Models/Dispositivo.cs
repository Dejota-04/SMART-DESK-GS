using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprint1.Models
{
    [Table("dispositivo")]
    public class Dispositivo
    {
        [Key]
        [Column("uuid")]
        public string Uuid { get; set; } 

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}