using Ccog3nt_product_Management_4._0.ViewModels;
using Ccog3nt_product_Management_4._0.Data;
using Ccog3nt_product_Management_4._0.Models;
using Ccog3nt_product_Management_4._0.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;



namespace Ccog3nt_product_Management_4._0.Controllers
{
    public class ProductController : Controller
    {
        private readonly Cog3ntDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment_;
        public ProductController(Cog3ntDbContext context, IHostingEnvironment hostEnv_)
        {
            _context = context;
            hostingEnvironment_ = hostEnv_;
        }
        public async Task<IActionResult> Index()//read method of the crud operations. it lists all data from the units table.
        {
         

            var prods = new List<Product>();
            Product prod = new Product();
            string folder = Path.Combine(hostingEnvironment_.WebRootPath, "managementUploads");
            DirectoryInfo direc = new DirectoryInfo(folder);
            string fileName = direc.GetFiles().Select(fi => fi.Name).First();
            string filePath = Path.Combine(folder, fileName);
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            using (stream)
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var pckg = new ExcelPackage(stream))
                {
                    ExcelWorksheet sheet = pckg.Workbook.Worksheets[0];

                    var rowcount = sheet.Dimension.Rows;
                    for (int row = 1; row < rowcount; row++)
                    {
                        if (row == 1)
                        {
                            continue;

                        }
                        prod = new Product
                        {
                            ID = Int32.Parse(sheet.Cells[row, 1].Value.ToString().Trim()),
                            ProductId = Int32.Parse(sheet.Cells[row, 7].Value.ToString().Trim()),
                            Sku = Convert.ToInt32(sheet.Cells[row, 8].Value.ToString().Trim()),
                            OrderProductId = Convert.ToInt32(sheet.Cells[row, 9].Value.ToString().Trim()),
                            ProductName = sheet.Cells[row, 10].Value.ToString().Trim(),
                            ModifiedDate = DateTime.Parse(sheet.Cells[row, 11].Value.ToString().Trim()),
                            ImportDate = DateTime.Parse(sheet.Cells[row, 12].Value.ToString().Trim()),
                            UnitsPerCase = Convert.ToInt32(sheet.Cells[row, 13].Value.ToString().Trim())
                        };
                        if (_context.Products.FirstOrDefault(x => x.ID == prod.ID) != null)
                        {
          
                        }
                        else
                        {
                            _context.Add(prod);

                        }
              

                    }

                }
            }
            _context.SaveChanges();
            return View(_context.Products);
        }

        //[Authorize(Roles = "Admin,User")]
        // GET: Products/Details/5
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

        //[Authorize(Roles = "Admin")]
        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductId,Sku,OrderProductId,ProductName,ModifiedDate,ImportDate,UnitsPerCase")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        //[Authorize]
        //[Authorize(Roles = "Admin")]
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        //[Authorize]
        //[Authorize(Roles = "Admin")]
        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ID,ProductId,Sku,OrderProductId,ProductName,ModifiedDate,ImportDate,UnitsPerCase")] Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    product.ModifiedDate = DateTime.Now;
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        //[Authorize]
        //[Authorize(Roles = "Admin")]
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
        //[Authorize]
        // POST: Products/Delete/5
        //[Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int? id)
        {
            return _context.Products.Any(e => e.ID == id);
        }


    }
}
