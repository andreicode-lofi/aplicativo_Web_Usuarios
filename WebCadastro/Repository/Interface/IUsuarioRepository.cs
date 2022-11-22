using WebCadastro.Models;

namespace WebCadastro.Repository.Interface
{
    public interface IUsuarioRepository
    {
        UsuarioModel Adicionar(UsuarioModel usuarioId);
        List<UsuarioModel> BuscarListaUsuario();
        UsuarioModel BuscarId(int usuarioId);
        UsuarioModel Editar(UsuarioModel usuario);
        bool Remover(int buscarId);

        UsuarioModel BuscarPorLogin(string id);

    }
}
