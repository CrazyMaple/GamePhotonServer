﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePhotonServer.Model
{
    public class User
    {
        public User()
        {
            Username = "";
            Password = "";
        }
        public User(string strUsername, string strPassword)
        {
            Username = strUsername;
            Password = strPassword;
        }

        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime Registerdate { get; set; }
    }
}
