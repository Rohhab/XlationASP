using System.ComponentModel.DataAnnotations;
using XlationASP.Dtos;

namespace XlationASP.Models
{
    public class BirthdateCustomValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var objectType = validationContext.ObjectInstance.GetType();

            if (objectType == typeof(Xlator))
            {
                var xlator = (Xlator)validationContext.ObjectInstance;

                if (xlator.MembershipTypeId == MembershipType.Unknown ||
                    xlator.MembershipTypeId == MembershipType.PayAsYouGo)
                    return ValidationResult.Success;

                if (xlator.Birthdate == null)
                    return new ValidationResult("Please make sure to enter your birthdate");

                var age = DateTime.Today.Year - xlator.Birthdate.Value.Year;

                return age >= 18
                    ? ValidationResult.Success
                    : new ValidationResult("You have to be over 18 to become a member");
            }
            else if (objectType == typeof(XlatorDto))
            {
                var xlatorDto = (XlatorDto)validationContext.ObjectInstance;

                if (xlatorDto.MembershipTypeId == MembershipType.Unknown ||
                    xlatorDto.MembershipTypeId == MembershipType.PayAsYouGo)
                    return ValidationResult.Success;

                if (xlatorDto.Birthdate == null)
                    return new ValidationResult("Please make sure to enter your birthdate");

                var age = DateTime.Today.Year - xlatorDto.Birthdate.Value.Year;

                return age >= 18
                    ? ValidationResult.Success
                    : new ValidationResult("You have to be over 18 to become a member");
            }
            else
            {
                return new ValidationResult("Unknown object type");
            }
        }
    }
}
