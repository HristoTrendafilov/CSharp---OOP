using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] objProperties = obj.GetType().GetProperties();

            foreach (var propertyInfo in objProperties)
            {
                IEnumerable<MyValidationAtribute> propAttribute = propertyInfo
                    .GetCustomAttributes()
                    .Where(x=>x is MyValidationAtribute)
                    .Cast<MyValidationAtribute>();
                    
                foreach (var attribute in propAttribute)
                {
                    var result = attribute.IsValid(propertyInfo.GetValue(obj));

                    if (!result)
                    {
                        return false;
                    }
                }
                    
            }
            return true;
        }
    }
}
