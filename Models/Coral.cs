using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace gsnet.Models
{
    [Table("Corais")]
    public class Coral
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string Especie { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "DATE")]
        public DateTime dt_cadastro { get; set; }

        [ForeignKey("Projeto")]
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
        public ICollection<Localizacao> Localizacoes { get; set; }
    }
}
