using Dominio.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Interface
{
    public interface IUserService
    {
        void AddConectedUser(User user);
        void RemoveConectedUser(User user);

        List<User> GetConnectedUsers();
    }
}
