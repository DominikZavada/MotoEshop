using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MotoEshop.Models.Validation
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false)]
    internal class UniqueCharactersAttribute : ValidationAttribute
    {
        private readonly int Characters;
        public UniqueCharactersAttribute(int characters)
        {
            this.Characters = characters;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("This field is empty!");
            }

            if (value is string password)
            {

                password = password.ToLower();
                password = String.Join("", password.Distinct());


                if (password.Length < Characters)
                {
                    return new ValidationResult("Not enough charactars!");
                }

                else
                {
                    return ValidationResult.Success;
                }

            }

            throw new NotImplementedException($"The attribute {nameof(UniqueCharactersAttribute)} is not implemented for object {value.GetType()}. {nameof(String)} only is implemented.");
        }
    }
}
