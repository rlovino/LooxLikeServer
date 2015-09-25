using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace LooxLikeAPI.Models.Model
{
    public class Post
    {
        public long Id { get; set; }
        public User User { get; set; }
        public String Text { get; set; }
        public String ItemId { get; set; }
        public DateTime TimeStamp { get; set; }
        public String PhotoUrl { get; set; }


        protected bool Equals(Post other)
        {
            return Id == other.Id && string.Equals(Text, other.Text) && string.Equals(ItemId, other.ItemId) && TimeStamp.Equals(other.TimeStamp) && string.Equals(PhotoUrl, other.PhotoUrl);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Post) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ (Text != null ? Text.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ItemId != null ? ItemId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ TimeStamp.GetHashCode();
                hashCode = (hashCode*397) ^ (PhotoUrl != null ? PhotoUrl.GetHashCode() : 0);
                return hashCode;
            }
        }
    }

}