using System.ComponentModel.DataAnnotations.Schema;

namespace Flweb.Model
{
    [Table("usuariopapel")]
    public class UsuarioPapel
    {
        [Column("UserId")]
        public long UserId { get; set; }

        [Column("RolerId")]
        public long RoleId { get; set; }
    }
}
