using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview.Objects
{
	public class Storable : IStoreable
	{
		public IComparable Id { get; set ; }
	}
}
