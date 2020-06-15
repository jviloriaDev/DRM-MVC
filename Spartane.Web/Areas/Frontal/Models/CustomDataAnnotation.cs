using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Spartane.Web.Areas.Frontal.Models
{
    public sealed class IsDateAfterAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string testedPropertyName;
        private readonly bool allowEqualDates;

        public IsDateAfterAttribute(string testedPropertyName, bool allowEqualDates = false)
        {
            this.testedPropertyName = testedPropertyName;
            this.allowEqualDates = allowEqualDates;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyTestedInfo = validationContext.ObjectType.GetProperty(this.testedPropertyName);
            if (propertyTestedInfo == null)
            {
                return new ValidationResult(string.Format("unknown property {0}", this.testedPropertyName));
            }

            var propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);

            if (value == null || !(value is DateTime))
            {
                return ValidationResult.Success;
            }

            if (propertyTestedValue == null || !(propertyTestedValue is DateTime))
            {
                return ValidationResult.Success;
            }

            // Compare values
            if ((DateTime)value >= (DateTime)propertyTestedValue)
            {
                if (this.allowEqualDates && value == propertyTestedValue)
                {
                    return ValidationResult.Success;
                }
                else if ((DateTime)value > (DateTime)propertyTestedValue)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
            ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = this.ErrorMessageString,
                ValidationType = "isdateafter"
            };
            rule.ValidationParameters.Add("propertyname", testedPropertyName);
            yield return rule;
        }
    }

    public sealed class IsNumberAfterAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string testedPropertyName;
        private readonly bool allowEqualNumbers;

        public IsNumberAfterAttribute(string testedPropertyName, bool allowEqualNumbers = false)
        {
            this.testedPropertyName = testedPropertyName;
            this.allowEqualNumbers = allowEqualNumbers;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyTestedInfo = validationContext.ObjectType.GetProperty(this.testedPropertyName);
            if (propertyTestedInfo == null)
            {
                return new ValidationResult(string.Format("unknown property {0}", this.testedPropertyName));
            }

            var propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);

            if (value == null || !(value is string) || string.IsNullOrWhiteSpace(value.ToString().Trim()))
            {
                return ValidationResult.Success;
            }

            if (propertyTestedValue == null || !(propertyTestedValue is string))
            {
                return ValidationResult.Success;
            }

            // Compare values
            if (Convert.ToInt32(value) >= Convert.ToInt32(propertyTestedValue))
            {
                if (this.allowEqualNumbers && value == propertyTestedValue)
                {
                    return ValidationResult.Success;
                }
                else if (Convert.ToInt32(value) > Convert.ToInt32(propertyTestedValue))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
            ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = this.ErrorMessageString,
                ValidationType = "isnumberafter"
            };
          
            rule.ValidationParameters.Add("propertyname", testedPropertyName);
            yield return rule;
        }
       
    }
}
