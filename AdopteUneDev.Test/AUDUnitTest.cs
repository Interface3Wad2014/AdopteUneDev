using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdopteUneDev.Controllers;

namespace AdopteUneDev.Test
{
    [TestClass]
    public class AUDUnitTest
    {
        [TestMethod]
        public void HomeControllerTest()
        {
            HomeController controller = new HomeController();
            var result = controller.Index();
        }
    }
}
