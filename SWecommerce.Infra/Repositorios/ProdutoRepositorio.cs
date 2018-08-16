using SWecommerce.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWecommerce.Infra.Contextos;
using System.Data.Entity;
using SWecommerce.Dominio.Entidades;

namespace SWecommerce.Infra
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly SWecommerceContexto _contexto;

        public ProdutoRepositorio(SWecommerceContexto contexto)
        {
            _contexto = contexto;
        }

        public Produto BuscarPorId(Guid id)
        {
            try
            {
                return _contexto.Produtos.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Inserir(Produto produto)
        {
            try
            {
                _contexto.Produtos.Add(produto);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Atualizar(Produto produto)
        {
            try
            {
                _contexto.Entry(produto).State = EntityState.Modified;
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Excluir(Guid id)
        {
            try
            {
                var produto = BuscarPorId(id);
                _contexto.Produtos.Remove(produto);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<BuscarProdutosDominio> BuscarProdutos()
        {
            try
            {
                return _contexto.Produtos.AsNoTracking()
                                     .Select(x => new BuscarProdutosDominio
                                     {
                                         Id = x.Id,
                                         Nome = x.Nome,
                                         Preco = x.Preco,
                                         TipoPromocao = x.TipoPromocao
                                     }).OrderByDescending(x => x.Nome).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }
    }
}
