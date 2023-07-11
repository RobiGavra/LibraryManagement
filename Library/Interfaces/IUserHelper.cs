using LibraryManagement.Interfaces;

namespace Library.Interfaces
{
    public interface IUserHelper
    {
        public string GetUser(string fullName);

        public string GetUser(int Id);

        public string AddUser(IUser user);

        public string RemoveUser(int Id);
    }
}
