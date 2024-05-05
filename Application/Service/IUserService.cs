using Application.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IUserService
    {
        public User GetByEmail(string email);

        public User Create(UserDTO user);

        public User Update(UserDTO user, int id);

        public void Delete(int id);
    }
}
