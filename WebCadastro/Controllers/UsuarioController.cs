using Microsoft.AspNetCore.Mvc;
using WebCadastro.Models;
using WebCadastro.Repository;
using WebCadastro.Repository.Interface;

namespace WebCadastro.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _iusuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _iusuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            List<UsuarioModel>  listUsuario = _iusuarioRepository.BuscarListaUsuario();
            return View(listUsuario);
        }



        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel id)
        {
            try
            {
                _iusuarioRepository.Adicionar(id);
                TempData["MensagemDeSucesso"] = $"O Usuário {id.Nome} foi criado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                TempData["MensagemDeErro"] = $"Não foi possivel criar o usuário {id.Nome}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuarioBd = _iusuarioRepository.BuscarId(id);
            return View(usuarioBd);
        }
        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenha)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenha.Id,
                        Nome = usuarioSemSenha.Nome,
                        Login = usuarioSemSenha.Login,
                        Email = usuarioSemSenha.Email,
                        Perfil = usuarioSemSenha.Perfil,
                    };

                    usuario = _iusuarioRepository.Editar(usuario);
                    TempData["MensagemSucesso"] = "Usuário atualizado com sucesso";
                    return RedirectToAction("Index");
                }

               return View(usuario);

            }
            catch (Exception)
            {

                TempData["MensagemErro"] = "Erro ao apagar o usuário}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            UsuarioModel usuarioDb = _iusuarioRepository.BuscarId(id);
            return View(usuarioDb);
        }
        [HttpPost]
        public IActionResult ApagarConfirma(int id)
        {   
            try
            {
                var apagar = _iusuarioRepository.Remover(id);

                if(apagar == null)
                {
                    TempData["MensagemDeSucesso"] = "O Usuário foi apagado com sucesso";
                }

                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                TempData["MensagemErro"] = $"Não foi possivel apagar o usuario";
                return RedirectToAction("Index");
            }
        }
    }
}
