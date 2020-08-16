using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.ViewModels;
using Model.Entities;

namespace UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductsSettings/{action}")]

    public class ProductsSettingsController : Controller
    {
        private UnitOfWork _unitOfWork;
        private Context _Context;


        public ProductsSettingsController()
        {
            _Context = new Context(Context.ops.dboptions);
            _unitOfWork = new UnitOfWork(_Context);
        }


        public IActionResult ProductsType()
        {
            ProducttypesViewModel vmProductTypes = new ProducttypesViewModel();
            vmProductTypes.producttypeList = _unitOfWork.ProductType.GetAll();

            return View(vmProductTypes);
        }

        [HttpGet]
        public IActionResult CreateProductsType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProductsType(Producttype producttype)
        {
            _unitOfWork.ProductType.Add(producttype);
            _unitOfWork.Complete();
            return RedirectToAction("ProductsType");
        }


        public ActionResult EditProductsType(int id)
        {
            ProducttypesViewModel vmProductTypes = new ProducttypesViewModel();
            vmProductTypes.producttype = _unitOfWork.ProductType.GetProductTypeWithID(id);

            return View(vmProductTypes);
        }

        [HttpPost]
        public ActionResult EditProductsType(ProducttypesViewModel producttypeEntity)
        {
            _unitOfWork.ProductType.Edit(producttypeEntity.producttype);
            _unitOfWork.Complete();

            return RedirectToAction("ProductsType");
        }



        [HttpPost]
        public ActionResult DeleteProductsType(int id)
        {
            Producttype _producttype = new Producttype();
            _producttype = _unitOfWork.ProductType.GetProductTypeWithID(id);
            _unitOfWork.ProductType.Remove(_producttype);
            _unitOfWork.Complete();

            return RedirectToAction("ProductsType");
        }





    }
}