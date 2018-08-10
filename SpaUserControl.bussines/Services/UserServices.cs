using SpanUserControl.common.Resources;
using SpanUserControl.common.Validation;
using SpaUserControl.domain.Contracts.Services;
using SpaUserControlDataContex.domain.Contracts.Reopositories;
using SpaUserControlDataContex.domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaUserControl.bussines.Services
{
    public class UserServices : IUserService
    {
        private IUserRepository _repository;

        public UserServices(IUserRepository repository)
        {
            this._repository = repository;
        }

        public User Authenticate(string email, string password)
        {
            var user = GetByEmail(email);

            if (user.Password != PasswordAssertionConcern.Encrypt(password))
                throw new Exception(Erros.InvalidPassword);

            return user;
        }

        public void ChangeInformation(string email, string name)
        {
            var user = GetByEmail(email);

            user.ChangeName(name);
            user.Validate();

            _repository.Update(user);

        }

        public void ChangePassword(string email, string password, string newPassword, string confirmPassword)
        {
            var user = Authenticate(email, password);
            user.SetPassWord(newPassword, confirmPassword);

            user.Validate();

            _repository.Update(user);
        }


        public User GetByEmail(string email)
        {
            return _repository.Get(email);
        }

        public void Register(string name, string email, string password, string confirmPassword)
        {
            var hasUser = GetByEmail(email);
            if (hasUser != null)
                throw new Exception(Erros.DuplicateEmail);

            var user = new User(name, email);
            user.SetPassWord(password, confirmPassword);
            user.Validate();

            _repository.Create(user);
        }

        public string resetPassword(string email)
        {
            var user = GetByEmail(email);

            string password = user.ResetPassword();

            user.Validate();

            _repository.Update(user);
            return password;
        }
        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
