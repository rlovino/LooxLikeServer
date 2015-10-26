using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Models.JSONModel.Response
{
	public class JsonPostResponse
	{
		public long PostId { get; set; }
		public string Description { get; set; }
		public string PhotoUrl { get; set; }
		public string C10 { get; set; }
		public DateTime CreationTime { get; set; }
		public string UserName { get; set; }
		public int NumLikes { get; set; }
		public bool Liked { get; set; }

		protected bool Equals(JsonPostResponse other)
		{
			return 
				PostId == other.PostId 
				&& string.Equals(Description, other.Description) 
				&& string.Equals(PhotoUrl, other.PhotoUrl) 
				&& string.Equals(C10, other.C10) 
				&& CreationTime.Equals(other.CreationTime) 
				&& string.Equals(UserName, other.UserName) 
				&& NumLikes == other.NumLikes 
				&& Liked == other.Liked;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((JsonPostResponse) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = PostId.GetHashCode();
				hashCode = (hashCode*397) ^ (Description != null ? Description.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ (PhotoUrl != null ? PhotoUrl.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ (C10 != null ? C10.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ CreationTime.GetHashCode();
				hashCode = (hashCode*397) ^ (UserName != null ? UserName.GetHashCode() : 0);
				hashCode = (hashCode*397) ^ NumLikes;
				hashCode = (hashCode*397) ^ Liked.GetHashCode();
				return hashCode;
			}
		}
	}
}