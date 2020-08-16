using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Service.ViewModels
{
    public class ProducttypesViewModel
    {
        public int ProductTypeDropdownSelected { get; set; }
        public IEnumerable<Producttype> producttypeList { get; set; }
        public Producttype producttype { get; set; }
    }
}
