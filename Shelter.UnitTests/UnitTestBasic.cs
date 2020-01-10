using NUnit.Framework;
using Shelter.MVC.Controllers;
using Moq;
using Shelter.MVC;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Shelter.UnitTests
{
  public class Tests
  {
    private Mock<IShelterDataAccess> _mockedDataAccess;
    private Mock<ILogger<ShelterAPIController>> _mockedLogger;
    private ShelterAPIController _controller;

    [SetUp]
    public void Setup()
    {
      _mockedDataAccess = new Mock<IShelterDataAccess>(MockBehavior.Strict);
      _mockedLogger = new Mock<ILogger<ShelterAPIController>>(MockBehavior.Strict);
      _controller = new ShelterAPIController(_mockedLogger.Object, _mockedDataAccess.Object);
    }

    [TearDown]
    public void TearDown()
    {
      _mockedDataAccess.VerifyAll();
      _mockedLogger.VerifyAll();
    }

    // These tests can be run using dotnet test

    [Test]
    public void Test_GetAll()
    {
      var shelters = new List<Shelter.Shared.Shelter>();

      _mockedDataAccess.Setup(x => x.GetAllShelters()).Returns(shelters);
  
      var result = _controller.GetAllShelters();

      Assert.IsInstanceOf(typeof(OkObjectResult), result);
      Assert.AreEqual(((OkObjectResult)result).Value, shelters);
    }

    [Test]
    public void Test_GetOneHappyFlow()
    {
      var shelter = new Shelter.Shared.Shelter()
      {
        name = "abc"
      };
      _mockedDataAccess.Setup(x => x.GetShelterById(12)).Returns(shelter);

      var result = _controller.getThisShelterById(12);

      Assert.IsInstanceOf(typeof(OkObjectResult), result);
      Assert.AreEqual(((OkObjectResult)result).Value, shelter);
    }

    [Test]
    public void Test_GetOneNotFound()
    {
      _mockedDataAccess.Setup(x => x.GetShelterById(13)).Returns(default(Shelter.Shared.Shelter));

      var result = _controller.getThisShelterById(13);

      Assert.IsInstanceOf(typeof(NotFoundObjectResult), result);
    }
  }
} 