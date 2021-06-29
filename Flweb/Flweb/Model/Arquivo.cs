using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flweb.Model
{
    [Table("arquivo")]
    public class Arquivo
    {
        [Key]
        [Column("id_arquivo")]
        public long IdArquivo { get; set; }

        [Column("nome")]
        public string Name { get; set; }

        [ForeignKey("id_atualizacao")]
        [Column("id_atualizacao")]
        public long Id_Atualizacao { get; set; }

    }
}
