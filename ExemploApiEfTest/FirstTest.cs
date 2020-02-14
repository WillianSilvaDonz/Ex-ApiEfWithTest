using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories;
using Xunit;

namespace ExemploApiEfTest
{
    public class FirstTest
    {
        [Fact]
        public void VerificaGravacaoProduct()
        {
            var options = new DbContextOptionsBuilder<StoreDataContext>()
                                .UseInMemoryDatabase(databaseName: "TesteUnitario").Options;

            using(var context = new StoreDataContext(options)){
                ProductRepository repository = new ProductRepository(context);
                Product product = new Product();
                product.Price = 2.99M;
                product.Title = "Mouse Razer";
                product.Description = "Mouse Vamos ver Gamer";
                repository.Create(product);
            }

            using(var context = new StoreDataContext(options)){
                ProductRepository repository = new ProductRepository(context);
                Product product = repository.Get(1);
                Assert.Equal(1, context.Products.Count());
                Assert.Equal("Mouse Razer", context.Products.Single().Title);
                Assert.Equal("Mouse Vamos ver Gamer", context.Products.Single().Description);
                Assert.Equal(2.99M, context.Products.Single().Price);
            }
        }
    }
}
