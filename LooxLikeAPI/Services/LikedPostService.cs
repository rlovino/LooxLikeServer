using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LooxLikeAPI.Exceptions;
using LooxLikeAPI.Models.JSONModel.Response;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Repository;
using Simple.Data;

namespace LooxLikeAPI.Services
{
	public class LikedPostService : ILikedPostService
	{
		private readonly ILikeRepository _likeRepository;

		public LikedPostService(ILikeRepository likeRepository)
		{
			_likeRepository = likeRepository;
		}

		public LikedUserPost Save(LikedUserPost likedPost)
		{
			return _likeRepository.Read(_likeRepository.Save(likedPost));
		}
	}
}