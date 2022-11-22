using WebCadastro.Models;

namespace WebCadastro.Repository.Interface
{
    public interface IContatoRepository
    {
        ContatoModel Adicionar(ContatoModel contato);
        List<ContatoModel> BuscarListaContato();
        ContatoModel BuscarId(int id);
        ContatoModel Atualizar(ContatoModel contatoId);
        bool Remover(int id); 
    }
}
