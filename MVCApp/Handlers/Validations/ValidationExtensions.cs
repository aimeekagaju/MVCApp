using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;

namespace MVCApp.Handlers.Validations
{
    public static class ValidationExtensions
    {
        public static ModelStateDictionary ValidateRequired(this ModelStateDictionary modelState, string formfield, string fieldname)
        {
            if (String.IsNullOrWhiteSpace(formfield))
            {
                modelState.AddModelError(fieldname, $"Le champs {fieldname} est obligatoire!");
            }
            return modelState;

        }

        public static ModelStateDictionary ValidateLength(this ModelStateDictionary modelState, string formfield, string fieldname, int mincharacters, int maxcharacters)
        {
            if(maxcharacters <  mincharacters)
            {
                throw new ArgumentException(nameof(maxcharacters));
            }
            
            if (formfield is not null && (formfield.Length < mincharacters || formfield.Length > maxcharacters))
            {
                modelState.AddModelError(fieldname, $"Les caractères du champs{fieldname} ne sont pas compris entre {mincharacters} et {maxcharacters}");
            }
            return modelState;
        }

        public static ModelStateDictionary ValidatePassword(this ModelStateDictionary modelState, string formPassword, string password, string pattern)
        {
            
            if (!Regex.IsMatch(password, pattern))
            {
                modelState.AddModelError(formPassword, "Le mot de passe doit contenir au moins : une lettre minuscule, une lettre majuscule, un chiffre, et un caractère spécial (&@#-+*!?%~/\\<>).");
            }

            return modelState;
        }
    }
}
