using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Models.JSONModel.Response
{
	public class JsonLikeResponse
	{
		public long likedPostId { get; set; }
		public string username { get; set; }
		public DateTime likedDateTime { get; set; }
	}
}