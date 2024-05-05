using Application.DTO;
using Application.IRepositorys;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public User Create(UserDTO user)
        {
            return _userRepository.Create(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
            return;
        }

        public User GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        public User Update(UserDTO user, int id)
        {
            return _userRepository.Update(user, id);
        }
    }
}
