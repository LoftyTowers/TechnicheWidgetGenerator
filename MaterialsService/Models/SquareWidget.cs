using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsService.Models
{
	public class SquareWidget : WidgetBase
	{
		public override string ToResponseString()
		{
			return $"Square ({XPosition},{YPosition}) size={Width}";
		}
	}
}
