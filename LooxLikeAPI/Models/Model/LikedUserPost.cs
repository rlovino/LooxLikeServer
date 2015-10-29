using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Models.Model
{
	public class LikedUserPost
	{
		public Post Post { get; set; }
		public User User { get; set; }

		protected bool Equals(LikedUserPost other)
		{
			return Equals(Post, other.Post) && Equals(User, other.User);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((LikedUserPost) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Post != null ? Post.GetHashCode() : 0)*397) ^ (User != null ? User.GetHashCode() : 0);
			}
		}
	}
}