using Microsoft.EntityFrameworkCore;
using WebCadastro.Models;

namespace WebCadastro.Contexto
{
    public class appContext : DbContext
    {
        public appContext(DbContextOptions<appContext> options) : base(options)
        {

        }

        public DbSet<ContatoModel> Contatos { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
