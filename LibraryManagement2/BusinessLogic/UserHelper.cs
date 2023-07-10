using LibraryManagement.Interfaces;
using System.Linq;

namespace LibraryManagement.BusinessLogic
{
    public class UserHelper
    {
        private IUser[] users;

        public UserHelper(IUser[] users)
        {
            this.users = users;
        }

        public string GetUser(string fullName)
        {
            IUser user = this.users.ToList().Find(u => u.FullName.ToLower().Contains(fullName.ToLower()));

            if (user == null)
                return "User doesn't exist";

            return $"User id: {user.Id}, full name: {user.FullName}";
        }

        public string GetUser(int Id)
        {
            IUser user = this.users.ToList().Find(u => u.Id == Id);

            if (user == null)
                return "User doesn't exist";

            return $"User id: {user.Id}, full name: {user.FullName}";
        }

        public string AddUser(IUser user, string fullName)
        {
            user.Id = this.users.Count() + 1;
            user.FullName = fullName;
            this.users.ToList().Add(user);

            return "User created";
        }

        public string RemoveUser(int Id)
        {
            this.users.ToList().RemoveAll(x => x.Id == Id);

            return "User removed";
        }
    }
}
