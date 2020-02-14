using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Repositories;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductRepository _repository;
        public HomeController(ProductRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/products")]
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repository.Get();
        }

        [Route("v1/products/{id}")]
        [HttpGet]
        public Product Get(Int32 id)
        {
            Product product = _repository.Get(id);
            if(product == null)
                throw new Exception("Nenhum Produto Encontrado!");

            return product;
        }

        [Route("v1/products")]
        [HttpPost]
        public string Post(Product product)
        {
            if(product == null)
                return "Nenhum dado foi Enviado";
            
            _repository.Create(product);
            return "Produto Salvo com Sucesso!";
        }

        [Route("v1/products")]
        [HttpPut]
        public string Put(Product product)
        {
            if(product == null && product.Id > 0)
                return "Nenhum dado foi Enviado";
            
            _repository.Update(product);
            return "Produto Alterado com Sucesso!";
        }

        [Route("v1/products/{id}")]
        [HttpDelete]
        public string Delete(Int32 id)
        {
            if(id <= 0)
                return "Nenhum dado foi Enviado";

            Product product = _repository.Get(id);
            if(product == null)
                return "Nenhum Usuario encontrado";
            
            _repository.Delete(product);
            return "Produto Deletado com Sucesso!";
        }
    }
}