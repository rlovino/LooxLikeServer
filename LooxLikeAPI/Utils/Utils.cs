using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;

namespace LooxLikeAPI
{
	public class Utils
	{
		public static User.Sex Sex(string sex)
		{
			User.Sex sexUser = User.Sex.Male;

			if (sex.Equals("f"))
				sexUser = User.Sex.Female;
			else if (sex.Equals("n"))
				sexUser = User.Sex.NoGender;
			return sexUser;
		}

		public static string Sex(User.Sex sexEnum)
		{
			var sex = "m";
			if (User.Sex.Female == sexEnum)
				sex = "f";
			else if (User.Sex.NoGender == sexEnum)
				sex = "n";
			return sex;
		}
	}
}