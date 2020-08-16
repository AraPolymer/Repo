using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IProductTypeRepository ProductType { get; }
        IPagesContentRepository PagesContent { get; }
        int Complete();
    }
}
