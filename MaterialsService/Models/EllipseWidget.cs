using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsService.Models
{
	public class EllipseWidget : WidgetBase
	{
		public override string ToResponseString()
		{
			return $"Ellipse ({XPosition},{YPosition}) diameterH = {Width} diameterV = {Height}";
		}
	}
}
