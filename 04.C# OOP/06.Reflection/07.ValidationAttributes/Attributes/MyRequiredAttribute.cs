using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            string convertObj = (string)obj;

            return !string.IsNullOrWhiteSpace(convertObj);
        }
    }
}
