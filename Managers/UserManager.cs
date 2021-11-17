using System.Collections.Generic;
using BFYOC.Function.Data;
using BFYOC.Function.Providers;

namespace BFYOC.Function.Managers
{
    public sealed class UserManager {
        private static UserRestProvider userProvider = new UserRestProvider();

        public List<User> GetUsers()
        {
            return userProvider.GetUsers();
        }

        public User GetUser(string UserId)
        {
            return userProvider.GetUser(UserId);
        }
    }
}