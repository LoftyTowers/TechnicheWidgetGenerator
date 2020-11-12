using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsService.Models
{
	public class TextboxWidget : WidgetBase
	{
		public override string ToResponseString()
		{
			return $"Textbox ({XPosition},{YPosition}) width={Width} height={Height} text=\"{Text}\"";
		}
	}
}
