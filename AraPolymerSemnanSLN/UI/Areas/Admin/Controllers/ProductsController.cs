using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.ViewModels;
using Model.Entities;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UI.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Products/{action}")]
    public class ProductsController : Controller
    {
        private UnitOfWork _unitOfWork;
        private Context _Context;


        public ProductsController()
        {
            _Context = new Context(Context.ops.dboptions);
            _unitOfWork = new UnitOfWork(_Context);
        }

        public IActionResult ChooseProductsType()
        {
           ProducttypesViewModel vmProductstype = new ProducttypesViewModel();
            vmProductstype.producttypeList = _unitOfWork.ProductType.GetAll();
            return View(vmProductstype);
        }

        public IActionResult Products(int SelectedProductType)
        {
            ProductsListViewModel vmProduct = new ProductsListViewModel();
     
            vmProduct.productsList = _unitOfWork.Products.GetProductsWithType(SelectedProductType);
            vmProduct.ProductType = SelectedProductType;

            return View(vmProduct);
        }

        [HttpGet]
        public IActionResult CreateProducts(int productType)
        {
            TempData["ProductType"] = productType;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProducts(Product product)
        {
            if ((_unitOfWork.Products.CountHotProduct().Equals(3)) & (product.hotproduct.Equals(true)))
            {
                ModelState.AddModelError("hotproduct", "فقط سه کالا را میشود به عنوان محصولات ویژه نمایش داد");

            }
            else
            {
                _unitOfWork.Products.Add(product);
                _unitOfWork.Complete();
            }


            return RedirectToAction("Products", new { SelectedProductType = product.ProductTypeID });
        }


        public ActionResult EditProducts(int id)
        {
            Product vmProducts = new Product();
            vmProducts = _unitOfWork.Products.GetProductWithID(id);

            return View(vmProducts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProducts(Product productEntity)
        {
            /*      if ((_unitOfWork.Products.CountHotProduct().Equals(3)) & (productEntity.hotproduct.Equals(true)))
                  {
                      ModelState.AddModelError("hotproduct", "فقط سه کالا را میشود به عنوان محصولات ویژه نمایش داد");
                      return;

                  }
                  else
                  {
                      _unitOfWork.Products.Edit(productEntity);
                      _unitOfWork.Complete();
                      return RedirectToAction("Products", new { SelectedProductType = productEntity.ProductTypeID });

                  }
                  */
            return RedirectToAction("Products", new { SelectedProductType = productEntity.ProductTypeID });

        }



        [HttpPost]
        public ActionResult DeleteProducts(int id)
        {
            Product _product = new Product();
            _product = _unitOfWork.Products.GetProductWithID(id);
            _unitOfWork.Products.Remove(_product);
            _unitOfWork.Complete();

            return RedirectToAction("Products", new { SelectedProductType = _product.ProductTypeID });
        }


        public ActionResult SpecialProducts(int SelectedProductType)
        {
            List<VMSpecialProducts> vmProduct = new List<VMSpecialProducts>();

            vmProduct = _unitOfWork.Products.GetSpecialProducts().ToList();
            ViewBag.ProductType = SelectedProductType;

            return View(vmProduct);
        }
    }
}