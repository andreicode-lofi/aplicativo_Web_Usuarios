using WebCadastro.Contexto;
using WebCadastro.Models;
using WebCadastro.Repository.Interface;

namespace WebCadastro.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly appContext _context;
        public UsuarioRepository(appContext context)
        {
            _context = context;
        }
        public UsuarioModel Adicionar(UsuarioModel usuarioId)
        {
            usuarioId.DataCadastro = DateTime.Now;
            _context.Usuarios.Add(usuarioId);
            _context.SaveChanges();
            return usuarioId;
        }
        public UsuarioModel BuscarId(int usuarioId)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == usuarioId);
        }
        public List<UsuarioModel> BuscarListaUsuario()
        {
            return _context.Usuarios.ToList();
        }
        public UsuarioModel BuscarPorLogin(string id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == x.Login.ToUpper());
        }
        public UsuarioModel Editar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = BuscarId(usuario.Id);

            if(usuarioDb == null) throw new System.Exception("Ouve um erro para editar o contato");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAtualização = DateTime.Now;

            _context.Usuarios.Update(usuarioDb);
            _context.SaveChanges();
            return usuarioDb;
        }
        public bool Remover(int buscarId)
        {
            UsuarioModel usuarioDb = BuscarId(buscarId);

            _context.Remove(usuarioDb);
            _context.SaveChanges();
            return true;
        }
    }
}
