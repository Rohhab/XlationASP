using System.ComponentModel.DataAnnotations;

namespace XlationASP.Models
{
    public class MembershipTypeCustomValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var xlator = (Xlator)validationContext.ObjectInstance;

            if (xlator.MembershipTypeId == MembershipType.Unknown || xlator.MembershipTypeId == 0)
                return new ValidationResult("Please select your membership type");

            return ValidationResult.Success;
        }
    }
}
