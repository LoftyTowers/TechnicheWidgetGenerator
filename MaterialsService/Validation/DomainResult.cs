using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsService.Validation
{
	public class DomainResult
	{
		public DomainResult(bool success, string message)
		{
			Success = success;
			Message = message;
		}

		public bool Success { get; }

		public string Message { get; }
	}
}
