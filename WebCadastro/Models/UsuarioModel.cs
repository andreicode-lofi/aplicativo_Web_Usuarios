using System.ComponentModel.DataAnnotations;
using WebCadastro.Enums;

namespace WebCadastro.Models
{
    public class UsuarioModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }//guarda o email do usuario caso precise enviar uma msg para o usuario

        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Informe uma senha")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; } //guarda a data que o cadastro foi feito

        public DateTime? DataAtualização { get; set; } //Guarda a data de atualização ?não obrigatorio


        //vamos criar um método bool para verificar se a senha esta correta 
        public bool SenhaValida(string senha)
        {
            return Senha == Senha;
        }

    }
}
