using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using Service.ViewModels;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UnitOfWork _unitOfWork;
        private Context _Context;
        private VMMainLayoutModel vmMainLayoutModel { get; set; }


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _Context = new Context(Context.ops.dboptions);
            _unitOfWork = new UnitOfWork(_Context);
            this.vmMainLayoutModel = new VMMainLayoutModel();
       
        }

        public IActionResult Index()
        {
            vmMainLayoutModel.producttype = _unitOfWork.ProductType.GetAll();
            return View(vmMainLayoutModel);
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

        public IActionResult PagesDetails(string PageName)
        {
            VMPagesContent vMPagesContent = new VMPagesContent();
            vMPagesContent.PagesContentvm = _unitOfWork.PagesContent.GetPagesContentWithName(PageName);
            return View(vMPagesContent);
        }
        public IActionResult ProductsListByType()
        {
            vmMainLayoutModel.producttype = _unitOfWork.ProductType.GetAll();
            return View(vmMainLayoutModel);
        }

   


    }
}
