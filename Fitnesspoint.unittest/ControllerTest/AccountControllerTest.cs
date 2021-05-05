using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitnesspoint.Controllers;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Fitnesspoint.unittest.ControllerTest
{
    [TestClass]
  public  class AccountControllerTest
    {
       
            [TestMethod]
            public void Login_Test()
            {
                //Arrange
                AccountController ac = new AccountController();

                //Act
                ViewResult result = ac.Login() as ViewResult;

                //Assert
                Assert.IsNotNull(result);
            }

            [TestMethod]
            public void Register_Test()
            {
                // Arrange
                AccountController ac1 = new AccountController();

                // Act
                ViewResult result = ac1.Register() as ViewResult;

                // Assert
                Assert.IsNotNull(result);
            }

        }

    }


