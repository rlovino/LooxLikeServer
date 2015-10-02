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
        private IUserRepository _userRepository;
        private IUserMapper _userMapper;

        public UserService(IUserRepository userRepository, IUserMapper userMapper)
        {
            _userRepository = userRepository;
            _userMapper = userMapper;
        }
        public User GetUser(long id)
        {
            return _userMapper.convert(_userRepository.read(id));
        }
    }
}