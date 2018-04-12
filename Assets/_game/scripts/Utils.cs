using UnityEngine;
using System;

namespace Frzpop
{
	public static class Utils {

		[Serializable]
		public struct Range
		{
			public float min;
			public float max;

			public static Range range01
			{
				get
				{
					return new Range( 0f, 1f );
				}
			}

			public Range( float min, float max )
			{
				this.min = min;
				this.max = max;
			}

			public override string ToString()
			{
				return string.Format( "Min: {0}, Max: {1}", min, max );
			}
		}
	}
}


