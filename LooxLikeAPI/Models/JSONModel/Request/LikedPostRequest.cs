using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Models.JSONModel.Request
{
	public class LikedPostRequest
	{
		public string Username { get; set; }
		public long PostId { get; set; }
	}
}