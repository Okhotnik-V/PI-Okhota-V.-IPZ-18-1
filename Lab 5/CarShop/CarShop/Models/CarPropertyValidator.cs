using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Models
{
    public class CarPropertyValidator : ModelValidator
    {
        public CarPropertyValidator(ModelMetadata metadata, ControllerContext context): base(metadata, context){ }
        public override IEnumerable<ModelValidationResult> Validate(object container)

        {
            CarShop.Models.Car b = container as CarShop.Models.Car;
            if (b != null)
            {

            }
                 return Enumerable.Empty<ModelValidationResult>();
        }

    }
}   