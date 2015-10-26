using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Models.DBModel
{
    public class DbPost
    {
        public long Id { get; set; }
        public string ItemId { get; set; }
        public string Text { get; set; }
        public long UserId { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime Timestamp { get; set; }

        protected bool Equals(DbPost other)
        {
            return Id == other.Id && string.Equals(ItemId, other.ItemId) && UserId == other.UserId && Timestamp.Equals(other.Timestamp);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DbPost) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ (ItemId != null ? ItemId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ UserId.GetHashCode();
                hashCode = (hashCode*397) ^ Timestamp.GetHashCode();
                return hashCode;
            }
        }
    }
}