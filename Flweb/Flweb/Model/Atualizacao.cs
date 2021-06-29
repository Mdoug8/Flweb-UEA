using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flweb.Model
{
    [Table("atualizacao")]
    public class Atualizacao
    {
        [Key]
        [Column("id_atualizacao")]
        public long IdAtualizacao { get; set; }

        [Column("versao")]
        public long Versao { get; set; }

        [Column("nome")]
        public string Name { get; set; }

        [Column("modelo")]
        public string Modelo { get; set; }

        [Column("status_atualizacao")]
        public long StatusAtualizacao { get; set; }

    }
}
