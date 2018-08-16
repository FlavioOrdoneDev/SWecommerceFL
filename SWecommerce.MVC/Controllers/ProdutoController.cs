using SWecommerce.Dominio;
using SWecommerce.Dominio.Entidades;
using SWecommerce.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SWecommerce.MVC.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ComandoInserirProduto        _comandoInserirProduto;
        private readonly ComandoAtualizarProduto      _comandoAtualizarProduto;
        private readonly ComandoExcluirProduto        _comandoExcluirProduto;
        private readonly ConsultaBuscarTodosProdutos  _consultaBuscarTodosProdutos;
        private readonly ProdutoRepositorio           _repositorio;

        public ProdutoController(ComandoInserirProduto        comandoInserirProduto,
                                 ComandoAtualizarProduto      comandoAtualizarProduto,
                                 ConsultaBuscarTodosProdutos  consultaBuscarTodosProdutos,
                                 ComandoExcluirProduto        comandoExcluirProduto,
                                 ProdutoRepositorio           repositorio)
        {
            _comandoInserirProduto        = comandoInserirProduto;
            _comandoAtualizarProduto      = comandoAtualizarProduto;
            _consultaBuscarTodosProdutos  = consultaBuscarTodosProdutos;
            _comandoExcluirProduto        = comandoExcluirProduto;
            _repositorio = repositorio;
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var produtos = _consultaBuscarTodosProdutos.Executar();

                var modelo = produtos.Select(x => new BuscarProdutosDominio
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Preco = x.Preco,
                    TipoPromocao = x.TipoPromocao
                }).OrderBy(x => x.Nome)
                  .ToList();

                return View(modelo);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult PartialCadastrarProduto()
        {
            try
            {
                return PartialView("_partialDadosProduto");
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult CadastrarProduto(ProdutoDominio entidade)
        {
            try
            {
                var resultado = _comandoInserirProduto.Executar(entidade);

                return Json(new { Result = "OK", Data = "Produto cadastrado com sucesso!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult PartialAlterarProduto(Guid produtoId)
        {
            try
            {
                var produto = _repositorio.BuscarPorId(produtoId);

                return PartialView("_partialDadosProduto", produto);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AlterarProduto(ProdutoDominio modelo)
        {
            try
            {
                var resultado = _comandoAtualizarProduto.Executar(modelo);

                return Json(new { Result = "OK", Data = "Produto alterado com sucesso!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpDelete]
        public JsonResult ExcluirProduto(Guid produtoId)
        {
            try
            {
                _comandoExcluirProduto.Executar(produtoId);

                return Json(new { Result = "OK", Data = "Produto excluído com sucesso!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}