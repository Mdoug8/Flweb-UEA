using System.ComponentModel.DataAnnotations;

namespace Flweb.Data.VO
{
    public class UserRegisterVO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "UserName é obrigatório")]
       
        public string UserName { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(256, ErrorMessage =
            "O Nome deve ter no máximo 256 caracteres.")]
      
        public string Name { get; set; }

        [StringLength(11, MinimumLength = 10, ErrorMessage =
            "O Telefone deve ter no mínimo 10 e no máximo 11 caracteres.")]
      
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
      
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório.")]
    
        public string Password { get; set; }

        [Required(ErrorMessage = "Papel é obrigatório.")]
        public string Papel { get; set; }

    }
}
