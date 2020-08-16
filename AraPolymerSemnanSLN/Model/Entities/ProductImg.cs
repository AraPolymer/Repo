using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Entities
{
    public class ProductImg
    {

        [Key]
        public int ID { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public int ProductRef { get; set; }
    }
}
