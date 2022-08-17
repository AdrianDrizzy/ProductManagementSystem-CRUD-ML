using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ccog3nt_product_Management_4._0.Data;
using Ccog3nt_product_Management_4._0.Models;

namespace Ccog3nt_product_Management_4._0.Controllers
{
    public class ClusterSearchController : Controller
    {
        //This controller presents an indexed list of products existing on the database so the user can select a product to view recommendations.


        #region instantiating and initialization the DB context
        //Creating an instance of the DB Context and initializing its value via the controller
        private readonly Cog3ntDbContext _context;
        public ClusterSearchController(Cog3ntDbContext context)
        {

            _context = context;
        }
        #endregion


        //The following  method returns an indexed list of products based on the user's search of a product name
        // GET: ClusterSearch

        public async Task<IActionResult> Index(string searchProduct)
        {
            //selecting products from the db context and assigning it to the products variable
            var products = from p in _context.Products
                           select p;
            //Ensuring that the user enters some form of input into the search bar
            if (!String.IsNullOrEmpty(searchProduct))
            {
                //searches through the products in the context based on the user input and assigning these to the products variable
                products = products.Where(s => s.ProductName.Contains(searchProduct));
            }
            //returning a list of products relevant to the user's search input
            return View(await products.ToListAsync());
        }

        // GET: ClusterSearch/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ClusterSearch/Create
        public IActionResult Create()
        {
            return View();
        }

    }
}
