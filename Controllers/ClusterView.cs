using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Ccog3nt_product_Management_4._0.Models;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Text;
using Ccog3nt_product_Management_4._0.Controllers;
using Ccog3nt_product_Management_4._0.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace Ccog3nt_product_Management_4._0.Controllers
{
    public class ClusterView : Controller
    {
        private readonly Cog3ntDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment_;
        public ClusterView(Cog3ntDbContext context, IHostingEnvironment hostEnv_)
        {
            _context = context;
            hostingEnvironment_ = hostEnv_;
        }

        public ActionResult Index(int id)
        {
            IEnumerable<ClusteredProducts> reccs = null;


            using (var hcli = new HttpClient())
            {
                hcli.BaseAddress = new Uri("https://localhost:5001/api/");
                var resp = hcli.GetAsync("Prediction?product=" + id.ToString());
                resp.Wait();

                var res = resp.Result;
                if (res.IsSuccessStatusCode)
                {
                    var readRes = res.Content.ReadAsAsync<IList<ClusteredProducts>>();
                    readRes.Wait();

                    reccs = readRes.Result;

                    _context.ClusteredProducts.RemoveRange(_context.ClusteredProducts);

                    _context.ClusteredProducts.AddRange(reccs.Distinct());
                    _context.SaveChanges();

                    if (reccs == null)
                    {
                        reccs = Enumerable.Empty<ClusteredProducts>();
                        ModelState.AddModelError(string.Empty, "Sorry! We couldn't provide any recommendations.");


                    }



                }
            }
            return View(reccs);
        }
    }
}
