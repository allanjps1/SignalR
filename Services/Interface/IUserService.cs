using Dominio.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Interface
{
    public interface IUserService
    {
        void AddConectedUser(User user);
        void RemoveConectedUser(String connectionId);
        int GetUsersCount();
        int UserQueuePosition(User user);
        void AddUserToQueue(User user);

        List<User> GetConnectedUsers();
    }
}
