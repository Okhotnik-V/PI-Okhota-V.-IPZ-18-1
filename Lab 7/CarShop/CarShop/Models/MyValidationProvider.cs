using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Models
{
    public class MyValidationProvider : ModelValidatorProvider
    {
        public override IEnumerable<ModelValidator>
       GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            if (metadata.ContainerType == typeof(CarShop.Models.Car))
            {
                return new ModelValidator[] { new
                CarPropertyValidator(metadata, context) };
            }

            if (metadata.ModelType == typeof(CarShop.Models.Car))
            {
                return new ModelValidator[] { new CarValidator(metadata, context) };
            }
            return Enumerable.Empty<ModelValidator>();
        }
    }
}
