using System.ComponentModel.DataAnnotations;

namespace XlationASP.Models
{
    public class BirthdateCustomValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
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
    }
}
