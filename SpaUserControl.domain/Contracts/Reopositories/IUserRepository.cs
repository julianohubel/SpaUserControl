﻿using SpaUserControl.domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaUserControl.domain.Contracts.Reopositories
{
    public interface IUserRepository
    {
        User Get(string email);

        User Get(Guid id);

        void Create(User user);

        void Update(User user);

        void Delete(User user);

    }
}
