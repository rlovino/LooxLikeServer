using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models.DBModel;
using LooxLikeAPI.Models.Model;
using LooxLikeAPI.Repository;

namespace LooxLikeAPI.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetUser(long id)
        {
            return _userRepository.Read(id);
        }

	    public User GetUser(string username)
	    {
			return _userRepository.Read(username);
		}
    }
}