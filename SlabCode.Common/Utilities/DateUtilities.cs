using System;

namespace SlabCode.Common.Utilities
{
	public class DateUtilities
	{
		public static int DateCompare(DateTime dateInit, DateTime? dateEnd)
		{
			dateEnd ??= DateTime.Now.AddDays(1);
			return DateTime.Compare(dateInit, (DateTime) dateEnd);
		}
	}
}