using System;
using System.Collections.Generic;
using System.Text;
using Service.Interfaces;
using DataLayer;
using Service.Repository;
namespace Service
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly Context _context;
        public UnitOfWork(Context context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            PagesContent = new PagesContentRepository(_context);
            ProductType = new ProductTypeRepository(_context);

        }
        public IProductRepository Products { get;  set; }
        public IProductTypeRepository ProductType { get;  set; }
        public IPagesContentRepository PagesContent { get;  set; }
        public int Complete() 
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
             _context.Dispose();
        }
    }
}
