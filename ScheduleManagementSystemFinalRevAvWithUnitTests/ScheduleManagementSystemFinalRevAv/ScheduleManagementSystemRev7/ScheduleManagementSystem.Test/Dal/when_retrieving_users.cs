using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScheduleManagementSystem.Test.Dal.Utility;
using ScheduleManagementSystem.Contract.Model;

namespace ScheduleManagementSystem.Test.Dal
{
    [TestClass]
    public class when_retrieving_users : DalTestContextSpecification
    {
        private int _userId1;
        private int _userId2;
        private int _userId3;

        public when_retrieving_users()
        {
            _userId1 = -1;
            _userId2 = -2;
            _userId3 = -3;
        }

        protected override void BecauseOf()
        {
            using (DMSTestDataContext testDataContext = new DMSTestDataContext())
            {
                List<UserDto> userDtos = new List<UserDto>();
                userDtos.Add(new UserDto
                                {
                                    Password = "Password",
                                    PasswordActiveDate = DateTime.Today,
                                    RequirePasswordReset = false,
                                    UserEmail = "test@test.com",
                                    UserFirstName = "FirstUserFN",
                                    UserId = _userId1,
                                    UserLastName = "FirstUserLN",
                                    UserName = "User1"
                                });
                userDtos.Add(new UserDto
                                {
                                    Password = "Password",
                                    PasswordActiveDate = DateTime.Today,
                                    RequirePasswordReset = false,
                                    UserEmail = "test@test.com",
                                    UserFirstName = "SecondUserFN",
                                    UserId = _userId2,
                                    UserLastName = "SecondUserLN",
                                    UserName = "User2"
                                });
                userDtos.Add(new UserDto
                                {
                                    Password = "Password",
                                    PasswordActiveDate = DateTime.Today,
                                    RequirePasswordReset = false,
                                    UserEmail = "test@test.com",
                                    UserFirstName = "ThirdUserFN",
                                    UserId = _userId3,
                                    UserLastName = "ThirdUserLN",
                                    UserName = "User3"
                                });

                testDataContext.UserDtos.InsertAllOnSubmit(userDtos);
                testDataContext.SubmitChanges();

                _userId1 = userDtos.ElementAt(0).UserId;
                _userId2 = userDtos.ElementAt(1).UserId;
                _userId3 = userDtos.ElementAt(2).UserId;

            }
        }

        protected override void Cleanup()
        {
            using (DMSTestDataContext testDataContext = new DMSTestDataContext())
            {
                testDataContext.UserDtos.DeleteAllOnSubmit(
                                                testDataContext.UserDtos.Where(c => c.UserId == _userId1
                                                                                || c.UserId == _userId2
                                                                                || c.UserId == _userId3));
                testDataContext.SubmitChanges();
            }
        }

        [TestMethod]
        public void should_return_all_users()
        {
            List<IUser> users = UserRetriever.GetAllUsers();

            Assert.AreEqual(3, users.Count);
            Assert.AreEqual("Password", users.ElementAt(0).Password);
            Assert.AreEqual(DateTime.Today, users.ElementAt(0).PasswordActivateDate);
            Assert.IsFalse(users.ElementAt(0).RequirePasswordReset);
            Assert.AreEqual("test@test.com", users.ElementAt(0).UserEmail);
            Assert.AreEqual("FirstUserFN", users.ElementAt(0).UserFirstName);
            Assert.AreEqual(_userId1, users.ElementAt(0).UserId);
            Assert.AreEqual("FirstUserLN", users.ElementAt(0).UserLastName);
            Assert.AreEqual("User1", users.ElementAt(0).UserName);


            Assert.AreEqual("Password", users.ElementAt(1).Password);
            Assert.AreEqual(DateTime.Today, users.ElementAt(1).PasswordActivateDate);
            Assert.IsFalse(users.ElementAt(1).RequirePasswordReset);
            Assert.AreEqual("test@test.com", users.ElementAt(1).UserEmail);
            Assert.AreEqual("SecondUserFN", users.ElementAt(1).UserFirstName);
            Assert.AreEqual(_userId2, users.ElementAt(1).UserId);
            Assert.AreEqual("SecondtUserLN", users.ElementAt(1).UserLastName);
            Assert.AreEqual("User2", users.ElementAt(1).UserName);


            Assert.AreEqual("Password", users.ElementAt(2).Password);
            Assert.AreEqual(DateTime.Today, users.ElementAt(2).PasswordActivateDate);
            Assert.IsFalse(users.ElementAt(2).RequirePasswordReset);
            Assert.AreEqual("test@test.com", users.ElementAt(2).UserEmail);
            Assert.AreEqual("ThirdUserFN", users.ElementAt(2).UserFirstName);
            Assert.AreEqual(_userId3, users.ElementAt(2).UserId);
            Assert.AreEqual("ThirdUserLN", users.ElementAt(2).UserLastName);
            Assert.AreEqual("User3", users.ElementAt(2).UserName);
        }
    }
}
