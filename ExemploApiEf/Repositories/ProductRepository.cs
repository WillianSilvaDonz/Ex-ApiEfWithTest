using System;
using System.Collections.Generic;
using Store.Data;
using Store.Models;

namespace Store.Repositories
{
    public class ProductRepository{
        private readonly StoreDataContext _context;
        public ProductRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Get(){
            return _context.Products;
        }

        public Product Get(Int32 Id){
            return _context.Products.Find(Id);
        }

        public void Create(Product product){
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product){
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(Product product){
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}