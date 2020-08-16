using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Validation
{
    public class HotProductValidation : ValidationAttribute
    {
        public string GetErrorMessage;
        
    }
}
