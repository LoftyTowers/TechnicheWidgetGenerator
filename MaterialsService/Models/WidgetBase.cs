using MaterialsService.Extensions;
using MaterialsService.Interfaces;
using MaterialsService.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MaterialsService.Models
{
	public abstract class WidgetBase : IValidatable
	{
		public int XPosition { get; set; }
		public int YPosition { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public string Text { get; set; }

		public abstract string ToResponseString();

		public DomainResult Validate()
		{
			var errors = new List<string>();

			// IsInSymmetricRange is an extension method 
			if (!XPosition.IsInSymmetricRange(0, 999))
			{
				errors.Add("The X Position must be within the range of 0 - 999");
			}

			if (!YPosition.IsInSymmetricRange(0, 999))
			{
				errors.Add("The Y Position must be within the range of 0 - 999");
			}

			if (!Width.IsInSymmetricRange(1, 999))
			{
				errors.Add("The Width must be within the range of 1 - 999");
			}

			if (!Width.IsInCanvasBounds(XPosition, 1000))
			{
				errors.Add("The sum of the Width and X Position must not be greater than canvas size of 1000");
			}

			if (!Height.IsInSymmetricRange(0, 999))
			{
				errors.Add("The Height must be within the range of 1 - 999");
			}

			if (!Height.IsInCanvasBounds(YPosition, 1000))
			{
				errors.Add("The sum of the Height and X Position must not be greater than canvas size of 1000");
			}

			// ToValidationResult is an extension method
			var result = errors.ToValidationResult();
			return result;
		}
	}
}
