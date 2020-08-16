
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Service.Interfaces;
    using DataLayer;
    using Microsoft.EntityFrameworkCore;


    using System.Linq;
    using Model.Entities;

    namespace Service.Repository
    {

        public class ProductTypeRepository : Repository<Producttype>, IProductTypeRepository
        {
            private Context _Context;
            public ProductTypeRepository(Context context) : base(context)
            {
                _Context = context;
            }

            public Producttype GetProductTypeWithID(int id)
            {
                return _Context.Producttypes.Where(m => m.Serial == id).FirstOrDefault();
            }



        }
    }

