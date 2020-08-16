using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entities
{
    public class Product
    {
        [Key]
        public int Serial { get; set; }
        public string Code { get; set; }
        public virtual Producttype Producttype { get; set; }
        public int ProductTypeID { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Diameter { get; set; }

        public string weight { get; set; }
        public string Length { get; set; }
        public string Thickness { get; set; }
        public string StandardCode { get; set; }

        public Boolean hotproduct { get; set; }

    }
}
