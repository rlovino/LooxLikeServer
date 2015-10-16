using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Response
{
	public class PostResponse
	{
		public long IdPost { get; set; }
		public string Description { get; set; }
		public string PhotoUrl { get; set; }
		public DateTime CreationDateTime { get; set; }
		public string UserName { get; set; }
		public int LikeNumber { get; set; }
		public bool Liked { get; set; }
		public string ItemId { get; set; }
	}
}