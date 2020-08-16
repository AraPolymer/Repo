using Microsoft.EntityFrameworkCore.Query.Internal;
using Model.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.ViewModels;

namespace Service.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductWithID(int id);
        IEnumerable<Product> GetProductsWithType(int id);

        int CountHotProduct();
        IEnumerable<VMSpecialProducts> GetSpecialProducts();
    }
}
