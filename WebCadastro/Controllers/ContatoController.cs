using Microsoft.AspNetCore.Mvc;
using WebCadastro.Models;
using WebCadastro.Repository.Interface;

namespace WebCadastro.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _icontatoRepository;

        public ContatoController(IContatoRepository contatoRepository)
        {
            _icontatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
            List<ContatoModel> listContatos = _icontatoRepository.BuscarListaContato();
            return View(listContatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel id)
        {
            try
            {

                _icontatoRepository.Adicionar(id);

                TempData["MensagemDeSucesso"] = $"O contato {id.Nome} foi criado com sucesso";
                return RedirectToAction("Index");


            }
            catch (System.Exception erro)
            {
                TempData["MensagemDeErro"] = $"Não foi possivel criar o contato {id.Nome}";
                return View("Criar");
            }
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contatoDb = _icontatoRepository.BuscarId(id);
            return View(contatoDb);
        }

        [HttpPost]
        public IActionResult Atualizar(ContatoModel id)
        {
            try
            {
                _icontatoRepository.Atualizar(id);
                TempData["MensagemDeSucesso"] = $"O Contato {id.Nome} foi atualizado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                TempData["MensagemDeErro"] = $"Não foi possivel atualizar o contato {id.Nome}";
                return View("Editar");
            }
        }

        public IActionResult Apagar(int id)
        {
            ContatoModel contadoDb = _icontatoRepository.BuscarId(id);
            return View(contadoDb);
        }

        
        public IActionResult ApagarConfirma(int id)
        {
            try
            {
                var apagar = _icontatoRepository.Remover(id);
                if(apagar == true)
                {
                    TempData["MensagemDeSucesso"] = $"O Contato foi apagado com sucesso";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {
                TempData["MensagemDeErro"] = "Não foi possivel apagar esta contato";
                return View("Apagar");
            }
            return RedirectToAction("Index");
        }
    }
}
