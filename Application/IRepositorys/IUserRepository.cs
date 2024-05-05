using Application.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositorys
{
    public interface IUserRepository
    {
        public User GetByEmail(string email);
        public User Create(UserDTO userDTO);

        public User Update(UserDTO userDTO, int id);
        public void Delete(int id);
    }
}
