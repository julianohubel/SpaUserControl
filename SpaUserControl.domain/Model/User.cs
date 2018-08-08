using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpanUserControl.common.Resources;
using SpanUserControl.common.Validation;
using SpaUserControl.Common.Validation;

namespace SpaUserControl.domain.Model
{
    public class User
    {

        protected User()
        {


        }
        public User(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;            
        }

        

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email {get; private set; }
        public string  Password { get; private set; }

        public void SetPassWord(string password, string confirmPassword)
        {
            AssertionConcern.AssertArgumentNotNull(password,Erros.InvalidPassword);
            AssertionConcern.AssertArgumentNotNull(confirmPassword, Erros.InvalidPasswordConfirmation);
            AssertionConcern.AssertArgumentEquals(password, confirmPassword, Erros.PasswordsDoNowMatch);
            AssertionConcern.AssertArgumentLength(password, 6, 20, Erros.InvalidPassword);

            this.Password = PasswordAssertionConcern.Encrypt(password);
        }

        public string ResetPassword()
        {
            string password = Guid.NewGuid().ToString().Substring(0, 8);
            this.Password = PasswordAssertionConcern.Encrypt(password);

            return password;
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentLength(this.Name, 3, 250, Erros.InvalidName);
            EmailAssertionConcern.AssertIsValid(this.Email);
            PasswordAssertionConcern.AsserIsValid(this.Password);
        }

    }
}
