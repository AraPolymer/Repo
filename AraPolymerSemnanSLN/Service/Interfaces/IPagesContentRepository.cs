using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IPagesContentRepository: IRepository<PagesContent>
    {
        PagesContent GetPagesContentWithName(string name);
    }
}
