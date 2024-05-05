using Application.DTO;
using Configuration;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context) { this._context = context; }

        public User Create(/*dto*/)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();

        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(/*dto*/ int id)
        {
            throw new NotImplementedException();
        }
    }
}
