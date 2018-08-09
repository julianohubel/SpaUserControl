using SpaUserControlDataContex.domain.Contracts.Reopositories;
using SpaUserControlDataContex.domain.Model;
using SpaUserControlDataContex.Infrastructure.Data;
using System;
using System.Linq;

namespace SpaUserControlDataContex.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private  SpaUserControlDataContext context = new SpaUserControlDataContext();

        public User Get(string email)
        {
            return context.users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public User Get(Guid id)
        {
            return context.users.Where(x => x.Id == id).FirstOrDefault();
        }


        public void Create(User user)
        {
            context.users.Add(user);
            context.SaveChanges();
        }

        public void Update(User user)
        {
            context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(User user)
        {
            context.users.Remove(user);
            context.SaveChanges();
        }
     
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
