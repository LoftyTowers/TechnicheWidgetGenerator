using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsService.Models
{
	public class CircleWidget : WidgetBase
	{
		public override string ToResponseString()
		{
			return $"Circle ({XPosition},{YPosition}) size={Width}";
		}
	}
}
