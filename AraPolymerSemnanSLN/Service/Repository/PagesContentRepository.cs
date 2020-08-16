using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using Service.Interfaces;
using Model.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Service.Repository
{
    public class PagesContentRepository : Repository<PagesContent>, IPagesContentRepository
    {
        private  Context _context;
        public PagesContentRepository(Context context) : base(context)
        {
            _context = context;
        }
        public PagesContent GetPagesContentWithName(string name)
        {
            return _context.Pagescontents.Where(x => x.PageName.Equals(name)).FirstOrDefault();     

        }



    }
}
