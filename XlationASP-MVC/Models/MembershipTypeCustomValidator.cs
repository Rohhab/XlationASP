using System.ComponentModel.DataAnnotations;
using XlationASP.Dtos;

namespace XlationASP.Models
{
    public class MembershipTypeCustomValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var objectType = validationContext.ObjectInstance.GetType();

            if (objectType == typeof(Xlator))
            {
                var xlator = (Xlator)validationContext.ObjectInstance;
                if (xlator.MembershipTypeId == MembershipType.Unknown)
                    return new ValidationResult("Please select your membership type");
            }
            else if (objectType == typeof(XlatorDto))
            {
                var xlatorDto = (XlatorDto)validationContext.ObjectInstance;
                if (xlatorDto.MembershipTypeId == MembershipType.Unknown)
                    return new ValidationResult("Please select your membership type");
            }
            else
            {
                return new ValidationResult("Unknown object type");
            }

            return ValidationResult.Success;
        }
    }
}
