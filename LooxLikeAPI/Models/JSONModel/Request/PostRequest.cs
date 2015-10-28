using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Models.JSONModel.Request
{
	public class PostRequest
	{
		public string Description { get; set; }
		public string C10 { get; set; }
		public byte[] Image { get; set; }
	}
}