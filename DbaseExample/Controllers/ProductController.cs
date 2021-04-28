using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbaseExample.Data;
using DbaseExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbaseExample.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbaseExampleContext _context;
        public ProductController(DbaseExampleContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var productList = _context.Products.ToList();
            return View(productList);
        }

        public IActionResult Delete(int ID)
        {
            var product = _context.Products.SingleOrDefault(p => p.ID == ID);
            _context.Remove(product);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //public IActionResult New()
        //{
            
        //    return View();
        //}
        public IActionResult Edit(int ProductID)
        {
            var product = _context.Products.SingleOrDefault(p => p.ID == ProductID);
            
            return View(product);
        }
        //public IActionResult Create(string Name, int Quantity, string Units, decimal Price)
        //{
        //    var product = new Product() { Name = Name, Quantity = Quantity, Units=Units, Price=Price };
        //    _context.Add(product);
        //    _context.SaveChanges();
        //    var productId = _context.Products.Where(p => p.Name == Name).Single().ID;

        //    return RedirectToAction("Index");
        //}
        public IActionResult Create(Product product)
        {
            if(_context.Products.Contains(product))
            {
                var newProduct = _context.Products.Single(p => p.ID == product.ID);
                newProduct.Name = product.Name;
                newProduct.Price = product.Price;
                newProduct.Quantity = product.Quantity;
                newProduct.Units = product.Units;
                _context.Update(newProduct);
                _context.SaveChanges();
            }
            else
            {
                _context.Add(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
