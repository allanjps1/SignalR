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
        public List<User> QueueUsers { get; private set; }

        public UserService()
        {
            ConnectedUsers = new List<User>();
            QueueUsers = new List<User>();
        }

        public void AddConectedUser(User user)
        {
            ConnectedUsers.Add(user);
        }

        public void RemoveConectedUser(string connectionId)
        {
            var usertoremove = ConnectedUsers.Find(x => x.ConnectionID == connectionId);

            ConnectedUsers.Remove(usertoremove);
        }

        public List<User> GetConnectedUsers()
        {
            return ConnectedUsers;
        }

        public int GetUsersCount()
        {
            return ConnectedUsers.Count;
        }

        public void AddUserToQueue(User user)
        {
            QueueUsers.Add(user);
        }

        public int UserQueuePosition(User user)
        {
            return QueueUsers.FindIndex(x => x.Nick == user.Nick);
        }
    }
}
