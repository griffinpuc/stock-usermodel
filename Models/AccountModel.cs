﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLoginForm.Models
{
    public class AccountModel
    {

        public int id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string accountCreation { get; set; }
        public string approvedAddress { get; set; }

    }
}
