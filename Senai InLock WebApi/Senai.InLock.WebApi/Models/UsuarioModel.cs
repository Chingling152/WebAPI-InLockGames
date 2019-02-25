using System.ComponentModel.DataAnnotations;

namespace Senai.InLock.WebApi.Models {

    public class UsuarioModel {

        public int ID;

        [Required(ErrorMessage = "Insira um email")]
        [StringLength(maximumLength: 200,MinimumLength = 5,ErrorMessage = "Email invalido")]
        [DataType(DataType.EmailAddress,ErrorMessage = "O tipo de valor informado não é um Email")]
        public string Email;

        [Required(ErrorMessage = "Insira uma senha")]
        [StringLength(maximumLength: 200, MinimumLength = 8, ErrorMessage = "Senhas invalida")]
        public string Senha;

        public string TipoUsuario = "Cliente";
    }
}
