using SpaUserControlDataContex.domain.Contracts.Reopositories;
using SpaUserControlDataContex.domain.Model;
using SpaUserControlDataContex.Infrastructure.Data;
using System;
using System.Linq;

namespace SpaUserControlDataContex.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private SpaUserControlDataContext _context;

        public UserRepository(SpaUserControlDataContext context)
        {
            this._context = context;

        }

        public User Get(string email)
        {
            return _context.users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public User Get(Guid id)
        {
            return _context.users.Where(x => x.Id == id).FirstOrDefault();
        }


        public void Create(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(User user)
        {
            _context.users.Remove(user);
            _context.SaveChanges();
        }
     
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
