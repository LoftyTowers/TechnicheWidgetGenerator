using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialsService.Extensions
{
	public static class IntegerExtensions
	{
		public static bool IsInSymmetricRange(this int value, int lowerbound, int upperBound)
		{
			return (value >= lowerbound && value <= upperBound);
		}
		public static bool IsInCanvasBounds(this int value, int position, int upperBound)
		{
			return ((value + position) <= upperBound);
		}
	}
}
