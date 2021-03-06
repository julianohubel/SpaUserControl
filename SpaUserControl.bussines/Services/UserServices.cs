﻿using SpanUserControl.common.Resources;
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

        public string ResetPassword(string Email)
        {
            var user = GetByEmail(Email);
            string password = user.ResetPassword();

            user.Validate();
            return password;

        }


        public User GetByEmail(string email)
        {
           var  user = _repository.Get(email);

            if (user == null)
                throw new Exception(Erros.UserNotFound);

            return user;
        }

        public void Register(string name, string email, string password, string confirmPassword)
        {
            var hasUser = _repository.Get(email);
            if (hasUser != null)
                throw new Exception(Erros.DuplicateEmail);

            var user = new User(name, email);
            user.SetPassWord(password, confirmPassword);
            user.Validate();

            _repository.Create(user);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
