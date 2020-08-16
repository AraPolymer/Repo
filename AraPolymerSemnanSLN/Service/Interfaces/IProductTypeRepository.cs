using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IProductTypeRepository : IRepository<Producttype>
    {
        Producttype GetProductTypeWithID(int id);
    }
}
