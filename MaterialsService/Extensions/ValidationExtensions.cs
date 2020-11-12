using MaterialsService.Interfaces;
using MaterialsService.Validation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MaterialsService.Extensions
{
	public static class ValidatableExtensions
	{
		public static bool IsValid(this IValidatable input)
		{
			// Sometimes all you care about is a boolean
			return input.ValidationResult().Success;
		}

		public static string ValidationMessage(this IValidatable input)
		{
			// Other times you just want the message. This is much more rare.
			return input.ValidationResult().Message;
		}

		public static DomainResult ValidationResult(this IValidatable input)
		{
			// This avoids needing a null check in our code when we validate nullable objects
			return input == null ? new DomainResult(false, "Null input is invalid.") : input.Validate();
		}

		public static DomainResult ToValidationResult<T>(this IEnumerable<T> input)
		{
			// Centralizes boilerplate needed to convert the list of errors into a single string.
			if (input == null)
			{
				return new DomainResult(false, "Null input is invalid.");
			}

			// Enumerate the errors
			var errors = input.ToList();
			var success = !errors.Any();
			var message = success ? "Validation successful." : string.Join(" ", errors);

			return new DomainResult(success, message);
		}
	}
}
