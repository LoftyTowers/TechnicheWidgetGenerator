using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MaterialsService.Models
{
	public class RectangleWidget : WidgetBase
	{
		public override string ToResponseString()
		{
			return $"Rectangle ({XPosition},{YPosition}) width={Width} height={Height}";
		}
	}
}
