using System;
using System.Collections.Generic;
using System.Linq;
using static AnimalPark.Utils.Validators.ValidationService.ValidationType;

namespace AnimalPark.Utils.Validators
{
    public class ValidationService
    {
        public enum ValidationType
        {
            StringValidation,  
            NumberValidation  
        }

        /// <summary>
        /// Used to verify whether any errors where registered after view model validation
        /// </summary>
        /// <param name="validationType"> validation strategy specific for a property </param>
        /// <param name="property"> name of the property being validated </param>
        /// <param name="value"> validated property's value</param>
        /// <param name="errors"> collection from INotifyErrorChanged interface, to register possible errors for a given property </param>
        /// <returns> validation result for a given view model </returns>
        public static bool IsValid(ValidationType validationType, string property, object value, out ICollection<string> errors)
        {
            errors = new List<string>();

            Action<string, object, ICollection<string>> validationAction = null;

            switch (validationType)
            {
                case StringValidation:
                    validationAction = ValidateString;
                    break;

                case NumberValidation:
                    validationAction = ValidatePositiveNumeric;
                    break;
            }

            validationAction?.Invoke(property, value, errors);
            return !errors.Any();
        }

        private static void ValidatePositiveNumeric(string property, object value, ICollection<string> errors)
        {

            if ((string)value == null || !int.TryParse((string)value, out int parsed))
            {
                errors.Add($"Couldn't parse {value} to int");
            }
            else if (parsed <= 0)
            {
                errors.Add($"{property} must be a positive number");
            }
        } 

        private static void ValidateString(string property, object value, ICollection<string> errors)
        {
            if (string.IsNullOrWhiteSpace((string) value))
            {
                errors.Add($"{property} cannot be blank!");
            }

            else if (!ContainsCharsOnly((string) value))
            {
                errors.Add($"{property} can only contain chars!");
            }
        }

        private static bool ContainsCharsOnly(string sequence)
        {
            return GetChars(sequence).All(char.IsLetter);
        }

        private static char[] GetChars(string sequence)
        {
            return sequence.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray();
        }
    }
}
