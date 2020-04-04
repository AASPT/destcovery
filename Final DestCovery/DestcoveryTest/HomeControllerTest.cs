using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DestCovery;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Text;
using DestCovery.Controllers;

namespace DestcoveryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SampleTest()
        {
            Assert.AreEqual("HomeController","HomeController");
        }

        [TestMethod]
        public void User_Registration_Form()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.User_Registraion_Form() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UserLogin()
        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.login() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ContactUs()

        {
            //Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.ContactUs() as ViewResult;

            //Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void AdminLogin()
        {
            //Arrange
            AdminController controller = new AdminController();

            //Act
            ViewResult result = controller.login() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
