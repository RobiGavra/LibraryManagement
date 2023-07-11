using LibraryManagement.BusinessLogic;
using LibraryManagement.Interfaces;
using LibraryManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTest
{
    [TestClass]
    public class UserHelperTests
    {
        [TestMethod]
        public void GetUser()
        {
            UserHelper userHelper = new UserHelper(DataMock.MockUsers());

            string userByName = userHelper.GetUser("Victor");

            Assert.AreEqual(userByName, "User doesn't exist");

            userByName = userHelper.GetUser("Andrei");

            Assert.AreEqual(userByName, "User id: 1, full name: Andrei Teodorescu");

            string userById = userHelper.GetUser(12);

            Assert.AreEqual(userById, "User doesn't exist");

            userById = userHelper.GetUser(1);

            Assert.AreEqual(userById, "User id: 1, full name: Andrei Teodorescu");
        }

        [TestMethod]
        public void AddUser()
        {
            UserHelper userHelper = new UserHelper(DataMock.MockUsers());

            IUser newUser = new User() { FullName = "Marian Petrescu" };

            string addMessage = userHelper.AddUser(newUser);

            Assert.AreEqual(addMessage, "User created");

            string userByName = userHelper.GetUser("Marian Petrescu");

            Assert.AreEqual(userByName, "User id: 4, full name: Marian Petrescu");
        }

        [TestMethod]
        public void RemoveUser()
        {
            UserHelper userHelper = new UserHelper(DataMock.MockUsers());

            string removeMessage = userHelper.RemoveUser(1);

            Assert.AreEqual(removeMessage, "User removed");

            string userById = userHelper.GetUser(1);

            Assert.AreEqual(userById, "User doesn't exist");
        }
    }
}
