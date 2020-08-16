using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Model.Entities;

namespace Service.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> productsList { get; set; }
        public Product product { get; set; }
        public int ProductType { get; set; }

        public IEnumerable<AnonymousObject> specialproductsList { get; set; }
    }
}
