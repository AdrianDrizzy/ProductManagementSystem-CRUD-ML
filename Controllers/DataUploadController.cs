using Ccog3nt_product_Management_4._0.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ccog3nt_product_Management_4._0.Controllers
{
    public class DataUploadController : Controller
    {

        //This controller sets out the method that will allow the user to upload an excel sheet for database population.


        #region instatiation and initialization of hosting envionment
        // creating an instance of the applications hosting environment and intitializing it via the controller

        private readonly IHostingEnvironment _hostingEnvironment;
        public DataUploadController(IHostingEnvironment hostEnv)
        {
            _hostingEnvironment = hostEnv;

        }

        #endregion

        // GET: ClusterView/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ManagementDocView managView)
        {

            //Ensures that there are no errors upon model binding/validation before executing anything
            if (ModelState.IsValid)
            {
                // string variable to hold the filename of the uploaded document
                string excelFileName = null;
                string[] validExtensions = { ".xlsx" };


                //Ensures that chosen document is not null
                if (managView.Document != null)
                {
                    //Specifies the folder that the document should be placed in within the hosting environment
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "managementUploads");
                    //appends a unique name to the filename of the chosen document
                    excelFileName = Guid.NewGuid().ToString() + managView.Document.FileName;
                    // specifies the new path of the document 
                    string filePath = Path.Combine(uploadsFolder, excelFileName);
                    //creates a copy of the document to the FileStream class so that there may be read/write priviledges.
                    managView.Document.CopyTo(new FileStream(filePath, FileMode.Create));
                    var fileExt = Path.GetExtension(excelFileName).ToLowerInvariant();

                    if (string.IsNullOrEmpty(fileExt) || !validExtensions.Contains(fileExt))
                    {
                        ModelState.AddModelError(string.Empty, "Please upload a valid .xlsx excel file");
                    }
                }
                //redirects the user if upload is successfull (validated via javascript in the razor page)
                return RedirectToAction("Index", "Product");

            }
            //returns the view for this upload page upon the call of this method and its controller.
            return View();
        }
    }
}
