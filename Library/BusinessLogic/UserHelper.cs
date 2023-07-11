using LibraryManagement.Interfaces;
using System.Collections.Generic;
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
            IUser user = this.users.FirstOrDefault(u => u.FullName.ToLower().Contains(fullName.ToLower()));

            return ReturnMessage(user);
        }

        public string GetUser(int Id)
        {
            IUser user = this.users.FirstOrDefault(u => u.Id == Id);

            return ReturnMessage(user);
        }

        public string AddUser(IUser user)
        {
            List<IUser> users = this.users.ToList();
            user.Id = this.users.Count() + 1;
            users.Add(user);

            this.users = users.ToArray();

            return "User created";
        }

        public string RemoveUser(int Id)
        {
            List<IUser> users = this.users.ToList();
            users.RemoveAll(x => x.Id == Id);

            this.users = users.ToArray();

            return "User removed";
        }

        private string ReturnMessage(IUser? user)
        {
            if (user == null)
                return "User doesn't exist";

            return $"User id: {user.Id}, full name: {user.FullName}";
        }
    }
}
