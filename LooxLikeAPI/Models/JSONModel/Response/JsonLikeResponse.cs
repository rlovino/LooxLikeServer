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

		protected bool Equals(JsonLikeResponse other)
		{
			return likedPostId == other.likedPostId && string.Equals(username, other.username);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((JsonLikeResponse) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (likedPostId.GetHashCode()*397) ^ (username != null ? username.GetHashCode() : 0);
			}
		}
	}
}