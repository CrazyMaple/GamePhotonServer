﻿using System.Collections.Generic;
using GamePhotonServer.Model;

namespace GamePhotonServer.Manager
{
    interface IUserManager
    {
        void Add(User user);
        void Update(User user);
        void Remove(User user);
        User GetById(int id);
        User GetByUsername(string username);
        ICollection<User> GetAllUsers();
        bool VerifyUser(string username, string password);
    }
}
