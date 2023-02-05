using Microsoft.EntityFrameworkCore;
using CosmeticApp5.Data;
using CosmeticApp5.Models;
using CosmeticApp5.View;
using System.Net;


namespace CosmeticApp5.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public void AddEmployee(ProductVM product)
        {
            var _product = new Product()
            {
                Name = product.Name,
                Price = product.Price,
                Address = product.Address,
                ModifiedDate = product.ModifiedDate,

            };
            _context.Products.Add(_product);
            _context.SaveChanges();
        }

        public List<Product> GetAllEmployees() => _context.Products.ToList();
#pragma warning disable CS8603 // Possible null reference return.
        public Product GetEmployeeById(int? id) => _context.Products.FirstOrDefault(x => x.Id == id);

        public Product UpdateEmployeeById(int id, ProductVM product)
        {
            var _product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (_product != null)
            {
                product.Name = product.Name;
                product.Price = product.Price;
                product.Address = product.Address;
                product.ModifiedDate = product.ModifiedDate;

                _context.SaveChanges();
            }
#pragma warning disable CS8603 // Possible null reference return.
            return _product;
        }

        public void DeleteEmployeeById(int id)
        {
            var _product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (_product != null)
            {
                _context.Products.Remove(_product);
                _context.SaveChanges();
            }
        }
    }

}
