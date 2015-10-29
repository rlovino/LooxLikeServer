using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Amazon.S3.Util;

namespace LooxLikeAPI.Exceptions
{
	public class SaveException : Exception
	{
		private readonly string _message;

		public SaveException()
		{
			
		}

		public SaveException(string message)
		{
			_message = message;
		}

		public string GetMessage()
		{
			return _message;
		}

		
		
	}
}