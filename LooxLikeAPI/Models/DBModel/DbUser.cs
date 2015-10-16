using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework.Constraints;

namespace LooxLikeAPI.Models.DBModel
{
    public class DbUser
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string  Email { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PictureUrl { get; set; }

        protected bool Equals(DbUser other)
        {
            return Id == other.Id && string.Equals(UserName, other.UserName) && string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName) && string.Equals(Sex, other.Sex) && DateOfBirth.Equals(other.DateOfBirth);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DbUser) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode*397) ^ (UserName != null ? UserName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Sex != null ? Sex.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ DateOfBirth.GetHashCode();
                return hashCode;
            }
        }
    }
}