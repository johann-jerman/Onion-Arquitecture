using Application.DTO;
using Application.IRepositorys;
using Configuration;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context) { this._context = context; }

        public User Create(UserDTO userDTO)
        {
            User newUser = new(){
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = userDTO.Password,
            };
            _context.Users.Add(newUser);
            //_context.SaveChanges();
            return newUser;
        }

        public void Delete(int id)
        {
            User user = _context.Users.SingleOrDefault(u => u.Id == id)
                ?? throw new KeyNotFoundException("No existe elemento con ese id");
            user.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email)
                ?? throw new KeyNotFoundException("No existe elemento con ese id");
        }

        public User Update(UserDTO userDTO ,int id)
        {
            User user = _context.Users.SingleOrDefault(u => u.Id == id) 
                ?? throw new KeyNotFoundException("No existe elemento con ese id");
            user.Username = userDTO.Username;
            user.Email = userDTO.Email;
            user.Password = userDTO.Password;
            _context.SaveChanges();
            return user;
        }
    }
}
