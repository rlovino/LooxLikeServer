using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LooxLikeAPI.Models.Model
{
    public class User
    {
        public enum Sex
        {
            Male,
            Female,
            NoGender
        };

        public long Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Sex Gender{ get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PictureUrl { get; set; }

        protected bool Equals(User other)
        {
	        return Id == other.Id && string.Equals(UserName, other.UserName) && string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName) && Gender == other.Gender && string.Equals(Email, other.Email) && string.Equals(City, other.City) && DateOfBirth.Equals(other.DateOfBirth) && string.Equals(PictureUrl, other.PictureUrl);
        }

        public override bool Equals(object obj)
        {
	        if (ReferenceEquals(null, obj)) return false;
	        if (ReferenceEquals(this, obj)) return true;
	        if (obj.GetType() != this.GetType()) return false;
	        return Equals((User) obj);
        }

        public override int GetHashCode()
        {
	        unchecked
	        {
		        var hashCode = Id.GetHashCode();
		        hashCode = (hashCode*397) ^ (UserName != null ? UserName.GetHashCode() : 0);
		        hashCode = (hashCode*397) ^ (FirstName != null ? FirstName.GetHashCode() : 0);
		        hashCode = (hashCode*397) ^ (LastName != null ? LastName.GetHashCode() : 0);
		        hashCode = (hashCode*397) ^ (int) Gender;
		        hashCode = (hashCode*397) ^ (Email != null ? Email.GetHashCode() : 0);
		        hashCode = (hashCode*397) ^ (City != null ? City.GetHashCode() : 0);
		        hashCode = (hashCode*397) ^ DateOfBirth.GetHashCode();
		        hashCode = (hashCode*397) ^ (PictureUrl != null ? PictureUrl.GetHashCode() : 0);
		        return hashCode;
	        }
        }
    }
}