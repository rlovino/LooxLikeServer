using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Models.JSONModel.Request
{
	public class LikedPostRequest
	{
		public long PostId { get; set; }

		public LikedPostRequest()
		{
			PostId = -1;
		}
	}
}