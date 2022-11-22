using Microsoft.AspNetCore.Mvc;
using WebCadastro.Contexto;
using WebCadastro.Models;
using WebCadastro.Repository.Interface;

namespace WebCadastro.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _iusuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _iusuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entar(LoginModel id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioDb = _iusuarioRepository.BuscarPorLogin(id.Login);//aqui vamos buscar o login e guarda na variavel 

                    if (usuarioDb != null)//se a senha for valida loga
                    {
                        if (usuarioDb.SenhaValida(id.Senha))
                        {
                            return RedirectToAction("Index", "Contato");
                        }

                    }
                    TempData["MensagemDeSucesso"] = "Login e senha validos";
                }
                return View("Index");
            }
            catch (Exception)
            {

                TempData["MensagemDeErro"] = "Login invalid ou senha invalidos";
                return RedirectToAction("Index");
            }
        }
    }
}
