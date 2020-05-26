using System;
using WebShop.Logic;
using Xunit;

namespace WebShop.Tests
{
    public class UserTest
    {
        [Fact]
        public void TestCreateUser()
        {
            string mail = GetRandomText();
            UserManager.
            Create(mail, "testname", "testpass");

            var user = UserManager.GetByEmail(mail);

            //ja asertacija ir pareiza => tests veiksmigs
            Assert.NotNull(user);

            Assert.Equal(user.Email, mail);
        }

        [Fact]
        public void TestGetUser()   
        {
            string mail = GetRandomText();
            string password = "testpass";
            UserManager.
            Create(mail, "testname", password);

            var user = UserManager.GetByEmail(mail);
            Assert.NotNull(user);
            Assert.Equal(user.Email, mail);
            Assert.Equal(user.Password, password);
        }

       public static string GetRandomText()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8);
        }
    }
}
