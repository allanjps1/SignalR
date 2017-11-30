using Application.Services.Interface;
using Dominio.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Service
{
    public class UserService : IUserService
    {
        public List<User> ConnectedUsers { get; private set; }

        public UserService()
        {
            this.ConnectedUsers = new List<User>();
        }

        public void AddConectedUser(User user)
        {
            ConnectedUsers.Add(user);
        }

        public void RemoveConectedUser(User user)
        {
            ConnectedUsers.Add(user);
        }

        public List<User> GetConnectedUsers()
        {
            return ConnectedUsers;
        }
    }
}
