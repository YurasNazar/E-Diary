using BLL.Interfaces;
using DAL.Entities;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public IList<User> GetUsers()
        {
            return _userRepository.Table.ToList();
        }
    }
}
