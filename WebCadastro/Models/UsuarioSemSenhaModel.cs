using System.ComponentModel.DataAnnotations;
using WebCadastro.Enums;

namespace WebCadastro.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }//guarda o email do usuario caso precise enviar uma msg para o usuario

        [Required(ErrorMessage = "Informe o Perfil")]
        public PerfilEnum? Perfil { get; set; }
    }
}
