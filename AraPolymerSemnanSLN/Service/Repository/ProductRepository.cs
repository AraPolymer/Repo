using System;
using System.Collections.Generic;
using System.Text;
using Service.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;



using System.Linq;
using Model.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Specialized;
using Service.ViewModels;
namespace Service.Repository
{

    public class ProductRepository : Repository<Product>, IProductRepository
    {
       private  Context _Context;
        public ProductRepository(Context context) : base(context)
        {
            _Context = context;
        }

        public Product GetProductWithID(int id)
        {
            return _Context.Products.Find(id);
        }

        public IEnumerable<Product> GetProductsWithType(int id)
        {
            return _Context.Products.Where(x => x.ProductTypeID.Equals(id));
        }

        public int CountHotProduct()
        {
            return _Context.Products.Where(x => x.hotproduct.Equals(true)).Count();
        }

        public IEnumerable<VMSpecialProducts> GetSpecialProducts()
        {
            var query = from vm in 
                         (from p in _Context.Products
                         join pt in _Context.Producttypes on p.ProductTypeID equals pt.Serial
                         where (p.hotproduct == true)
                         select new
                         {
                             p.Serial,
                             p.Code,
                             p.Name,
                             p.hotproduct,
                             p.Length,
                             p.ProductTypeID,
                             p.Size,
                             p.StandardCode,
                             p.Thickness,
                             p.weight,
                             ProductTypeName = pt.Name,
                             p.Diameter
                         }).ToList()
                         select new VMSpecialProducts
                         {
                           Serial = vm.Serial,
                           Code = vm.Code,
                           Name = vm.Name,
                           hotproduct = vm.hotproduct,
                           Length = vm.Length,
                           ProductTypeID = vm.ProductTypeID,
                           Size = vm.Size,
                           StandardCode = vm.StandardCode,
                           Thickness = vm.Thickness,
                           weight = vm.weight,
                           ProductTypeName = vm.ProductTypeName,
                           Diameter = vm.Diameter
                         };

            return query.ToList();
        }
    }
}
