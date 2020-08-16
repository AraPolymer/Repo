using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Producttype
    {
        [Key]
       public int Serial { get; set; }
       public string Code { get; set; }
       public string Name { get; set; }

       public virtual List<Product> Products { get; set; }
    }
}
