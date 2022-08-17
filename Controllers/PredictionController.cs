using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalML.Data;
using Ccog3nt_product_Management_4._0.MLModels;
using Newtonsoft.Json;
using Ccog3nt_product_Management_4._0.Models;
using Ccog3nt_product_Management_4._0.Data;
//using System.Web.Script.Serialization;

namespace Ccog3nt_product_Management_4._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private readonly Cog3ntDbContext _context;

        public PredictionController(Cog3ntDbContext context)
        {

            _context = context;
        }
        [HttpGet]
        public List<CopurchasedScore> AcceptProduct(int product)
        {
            try
            {

                var copurchasedList = new List<CopurchasedScore>();
                using (_context)
                {

                    var productList = _context.Products.ToList();
                    var allproductIDs = _context.Products.Select(theId => new { id = theId.ID, name = theId.ProductName }).ToList();

                    foreach (var item in allproductIDs)
                    {
                        ModelInput theData = new();
                        var copurchased = new CopurchasedScore();


                        theData.ProdIDA = product;
                        theData.ProdIDB = (float)item.id;

                        var predictionResult = ConsumeModel.Predict(theData);
                        copurchased.ProductID = (int)item.id;

                        copurchased.Score = predictionResult.Score;
                        copurchased.ProductName = item.name;

                        if (copurchased.Score > 0.5 && copurchased.ProductID != product)
                        {

                            copurchasedList.Add(copurchased);

                        }

                    }
                    return copurchasedList.Distinct().OrderByDescending(x => x.Score).Take(5).ToList();


                }

            }
            catch (Exception ec)
            {
                string output = ec.Message + "Unable to Consume Model";
                return null;
                ;
            }
        }

    }
}
