using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Exceptions
{
	public class ReadException : Exception
	{
		private readonly string _message;

		public ReadException(string message)
		{
			_message = message;
		}

		public string GetMessage()
		{
			return _message;
		}
	}
}