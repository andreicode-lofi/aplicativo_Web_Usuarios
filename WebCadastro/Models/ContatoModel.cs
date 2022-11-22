using System.ComponentModel.DataAnnotations;

namespace WebCadastro.Models
{
    public class ContatoModel
    {
        [Key]
        public int ContatoId { get; set; }

        [Required(ErrorMessage ="Informe o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Informe o email")]
        [EmailAddress(ErrorMessage ="Email invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Informe o telefone")]
        [Phone(ErrorMessage ="Telefone invalido")]
        public string Telefone { get; set; }

    }
}
