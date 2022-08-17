using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ccog3nt_product_Management_4._0.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Ccog3nt_product_Management_4._0.Controllers
{
    public class ClusterUploadController : Controller
    {
        //This controller sets out the method that will allow the user to upload a txt file for clustering of profucts

        #region instatiation and initialization of hosting envionment
        // creating an instance of the applications hosting environment and intitializing it via the controller
        private readonly IHostingEnvironment hostingEnvironment1;
        public ClusterUploadController(IHostingEnvironment hostingEnvironment)
        {
            //initializing the instance 
            hostingEnvironment1 = hostingEnvironment;

        }
        #endregion

        // GET: ClusterView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClusterView/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClusterDocView clusteredView)
        {
            //Ensures that there are no errors upon model binding/validation before executing anything
            if (ModelState.IsValid)
            {
                // string variable to hold the filename of the uploaded document
                string uniqueFileName = null;

                //Ensures that chosen document is not null
                if (clusteredView.Document != null)
                {
                    //Specifies the folder that the document should be placed in within the hosting environment
                    string uploadsFolder = Path.Combine(hostingEnvironment1.WebRootPath, "clusterUploads");
                    //appends a unique name to the filename of the chosen document
                    uniqueFileName = Guid.NewGuid().ToString() + clusteredView.Document.FileName;
                    // specifies the new path of the document 
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    //creates a copy of the document to the FileStream class so that there may be read/write priviledges.
                    clusteredView.Document.CopyTo(new FileStream(filePath, FileMode.Create));

                }
                //redirects the user if upload is successfull (validated via javascript in the razor page)
                return RedirectToAction("Index", "ClusterSearch");

            }
            //returns the view for this upload page upon the call of this method and its controller.
            return View();
        }
    }
}

