using ifound_api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ifound_unittests.UnitTests
{
    [TestClass]
    public class LostOrFoundControllerTests
    {
        [TestMethod]
        public void GetAllObjects()
        {
            //Arrange
            LostOrFoundController lostOrFoundController = new LostOrFoundController();

            ////Act
            ViewResult result = lostOrFoundController.GetAllObjects() as ViewResult;

            ////Assert
            Assert.IsNotNull(result);
        }
    }
}
