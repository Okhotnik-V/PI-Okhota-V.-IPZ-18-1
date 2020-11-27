using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarShop.Models
{
    public class CarValidator : ModelValidator
    {
        public CarValidator(ModelMetadata metadata, ControllerContext context) : base(metadata, context)
        { }
        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            CarShop.Models.Car b = (CarShop.Models.Car)Metadata.Model;
            List<ModelValidationResult> errors = new
            List<ModelValidationResult>();
            if (string.IsNullOrEmpty(b.Name))
            {
                errors.Add(new ModelValidationResult
                {
                    MemberName = "",
                    Message = "Неприпустима марка та модель"
                });
            }

            if (b.Age > 2020 || b.Age < 1950)
            {
                errors.Add(new ModelValidationResult
                {
                    MemberName = "",
                    Message = "Неприпустимий рік виробництва"
                });
            }

            if (string.IsNullOrEmpty(b.Prise))
            {
                errors.Add(new ModelValidationResult
                {
                    MemberName = "",
                    Message = "Неприпустима ціна"
                });
            }


            if (b.Name == "Kamaz")
            {
                errors.Add(new ModelValidationResult
                {
                    MemberName = "",
                    Message = "Неприпустима марка"
                });
            }
            return errors;
        }
    }
}