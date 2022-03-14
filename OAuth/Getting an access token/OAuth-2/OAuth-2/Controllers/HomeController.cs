﻿using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using OAuth_2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OAuth_2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly ITokenAcquisition tokenAcquisition;
        public HomeController(ILogger<HomeController> logger, ITokenAcquisition tokenAcquisition)
        {
            _logger = logger;
            this.tokenAcquisition = tokenAcquisition;
        }

        public async Task<IActionResult> Index()
        {

            //string[] scopes = new string[] { "https://storage.azure.com/user_impersonation" };
            //string accesstoken = await tokenAcquisition.GetAccessTokenForUserAsync(scopes);
            //ViewBag.accesstoken = accesstoken.ToString();
            //return View();


            Uri blobUri = new Uri("");

            TokenAcquisitionTokenCredential credential = new TokenAcquisitionTokenCredential(tokenAcquisition);
            BlobClient blobClient = new BlobClient(blobUri, credential);

            MemoryStream ms = new MemoryStream();
            blobClient.DownloadTo(ms);
            ms.Position = 0;
            StreamReader _reader = new StreamReader(ms);
            string str = _reader.ReadToEnd();
            ViewBag.content = str;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
