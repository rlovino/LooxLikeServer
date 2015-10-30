using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Models.DBModel
{
    public class DbLike
    {
        public long PostId {get; set; }
        public long UserId { get; set; }
		public DateTime CreationTime { get; set; }

	    protected bool Equals(DbLike other)
	    {
		    return PostId == other.PostId && UserId == other.UserId && CreationTime.Equals(other.CreationTime);
	    }

	    public override bool Equals(object obj)
	    {
		    if (ReferenceEquals(null, obj)) return false;
		    if (ReferenceEquals(this, obj)) return true;
		    if (obj.GetType() != this.GetType()) return false;
		    return Equals((DbLike) obj);
	    }

	    public override int GetHashCode()
	    {
		    unchecked
		    {
			    var hashCode = PostId.GetHashCode();
			    hashCode = (hashCode*397) ^ UserId.GetHashCode();
			    hashCode = (hashCode*397) ^ CreationTime.GetHashCode();
			    return hashCode;
		    }
	    }
    }
}