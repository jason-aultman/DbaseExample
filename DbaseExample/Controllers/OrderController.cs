using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbaseExample.Data;
using DbaseExample.Models;
using DbaseExample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbaseExample.Controllers
{
    public class OrderController : Controller
    {
        private readonly DbaseExampleContext _context;
        public OrderController(DbaseExampleContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var orderID = _context.Orders.Include(o => o.Products).ToList();
           
            return View(orderID);
        }
        //Select Product To Add to Order: ID
        public IActionResult AddProduct(int ID)
        {
            var order = _context.Orders.Where(o => o.ID == ID).Include(p => p.Products).Single();
            var products = _context.Products.ToList();
            var orderProducts = new OrderProductViewModel() { Order = order, Products = products };
            return View(orderProducts);
        }
        
        public IActionResult DeleteFrom(int ID, int ProductID)
        {
            var order = _context.Orders.Single(o => o.ID == ID);
            var product = _context.Products.Single(p => p.ID == ProductID);
            order.Products.Remove(product);
            _context.Update(order);
            _context.SaveChanges();
            return RedirectToAction("Edit", new { ID = ID });
        }
        public IActionResult DeleteOrder(int ID)
        {
            if(_context.Orders.Where(o=>o.ID==ID)!=null)
            {
                _context.Orders.Remove(_context.Orders.Single(o => o.ID == ID));
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int ID)
        {
            var order = _context.Orders.Include(p=>p.Products).SingleOrDefault(o => o.ID == ID);
            if(order==null)
            {
                order = new Order();
                _context.Orders.Add(order);
                _context.SaveChanges();
                var orderId = order.ID;
            }
            return View(order);
        }
        public IActionResult AddProductToOrder(OrderProductViewModel model)
        {
            var order = _context.Orders.Single(c => c.ID == model.Order.ID);
            var product = _context.Products.Single(p => p.ID == model.SelectedProduct);
            order.Products.Add(product);
            _context.Update(order);
            _context.SaveChanges();
            return RedirectToAction("Edit", new { ID=model.Order.ID });
        }
    }
}
