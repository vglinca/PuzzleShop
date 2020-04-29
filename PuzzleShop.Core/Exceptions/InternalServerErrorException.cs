using System;
using System.Collections.Generic;
using System.Text;

namespace PuzzleShop.Core.Exceptions
{
	public class InternalServerErrorException: Exception
	{
		public InternalServerErrorException()
		{
		}

		public InternalServerErrorException(string msg): base(msg)
		{
		}
	}
}
