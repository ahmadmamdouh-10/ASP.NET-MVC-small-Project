using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.Validators
{
    public class ITIEmail
        : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value.ToString()
                .Contains("@iti.gov.eg");
        }
    }
}