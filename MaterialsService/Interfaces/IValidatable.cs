using MaterialsService.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsService.Interfaces
{
	public interface IValidatable
	{
		DomainResult Validate();
	}
}
