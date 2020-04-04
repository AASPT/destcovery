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
        public void ContactUs()

        {
            HomeController controller = new HomeController();

            ViewResult result = controller.ContactUs() as ViewResult;

            Assert.IsNotNull(result);

        }
    }
}
