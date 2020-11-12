using MaterialsService.Interfaces;
using MaterialsService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsService.Services
{
	public class MaterialsGeneratorService : IMaterialsGeneratorService
	{
		private const string ErrorMessage = "+++++Abort+++++";

		public MaterialsGeneratorService(ILogger<MaterialsGeneratorService> log)
		{
			Log = log;
		}

		public string CreateWidget<T>(T widget) where T : WidgetBase
		{
			try
			{
				//TODO add logging

				var returnMessage = string.Empty;
				var widgetValidation = widget.Validate();

				if (!widgetValidation.Success)
				{
					Log.LogWarning(widgetValidation.Message);
					returnMessage = ErrorMessage;
				}
				else
				{
					returnMessage = widget.ToResponseString();
				}

				return returnMessage;
			}
			catch (Exception ex)
			{
				Log.LogError(ex, "Failed to create widget material");
				return ErrorMessage;
			}
		}

		#region Properties

		private ILogger<MaterialsGeneratorService> Log { get; }

		#endregion
	}
}
