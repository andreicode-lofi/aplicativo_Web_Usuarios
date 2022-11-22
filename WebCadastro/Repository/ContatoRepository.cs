using WebCadastro.Contexto;
using WebCadastro.Models;
using WebCadastro.Repository.Interface;

namespace WebCadastro.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly appContext _context;

        public ContatoRepository(appContext context)
        {
            _context = context;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contatoId)
        {
            ContatoModel contatoDb = BuscarId(contatoId.ContatoId);

            contatoDb.Nome = contatoId.Nome;
            contatoDb.Email = contatoId.Email;
            contatoDb.Telefone = contatoId.Telefone;

            _context.Contatos.Update(contatoDb);
            _context.SaveChanges();
            return contatoDb;
        }

        public ContatoModel BuscarId(int id)
        {
            return _context.Contatos.FirstOrDefault(x => x.ContatoId == id);
           
        }

        public List<ContatoModel> BuscarListaContato()
        {
            return _context.Contatos.ToList();
        }

        public bool Remover(int id)
        {
            ContatoModel contatoDb = BuscarId(id);

            if (contatoDb == null) throw new System.Exception("Ouve um erro para apagar o contato");

            _context.Contatos.Remove(contatoDb);
            _context.SaveChanges();
            return true;
        }
    }
}
