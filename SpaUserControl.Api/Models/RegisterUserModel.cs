﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaUserControl.Api.Models
{
    public class RegisterUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}