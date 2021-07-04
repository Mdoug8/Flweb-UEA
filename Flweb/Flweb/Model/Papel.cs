using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flweb.Model
{
    [Table("papel")]
    public class Papel
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("normalized_name")]
        public string NormalizedName { get; set; }
    }
}
