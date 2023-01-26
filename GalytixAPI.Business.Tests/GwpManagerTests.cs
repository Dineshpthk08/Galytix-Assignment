using GalytixAPI.Business.Implementation;
using GalytixAPI.Business.Interfaces;
using GalytixAPI.Entities;
using GalytixAPI.Repository.Interface;
using Moq;

namespace GalytixAPI.Business.Tests
{
    public class GwpManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetGwpAvg_WithValidInput_ReturnsExpectedResult()
        {
            //Arrange
            List<GwpResponse> expectedResult = new List<GwpResponse>() {
                new GwpResponse{ LineOfBusiness = "t_s", Avg = 100},
                new GwpResponse{ LineOfBusiness = "transport", Avg = 1000},
            };

            List<Gwp> gwps = new List<Gwp>() {
                new Gwp{ Country = "ae", LineOfBusiness = "t_s", AvgGwp = 100},
                new Gwp{ Country = "ae", LineOfBusiness = "transport", AvgGwp = 1000},
            };

            GwpRequest request = new GwpRequest
            {
                CountryCode = "ae",
                lineOfBusiness = new List<string>
                {
                    "t_s",
                    "transport",
                }
            };

            var gwpRepo = new Mock<IGwpRepository>(MockBehavior.Strict);
            gwpRepo.Setup(p => p.GetGwp()).Returns(gwps);
            var gwpManager = new GwpManager(gwpRepo.Object);

            //Act
            var result = gwpManager.GetGwpAvg(request);

            //Assert
            Assert.That(expectedResult.Count, Is.EqualTo(result.Count));
            Assert.That(result[0].LineOfBusiness, Is.EqualTo(expectedResult[0].LineOfBusiness));
            gwpRepo.VerifyAll();
        }

        [Test]
        public void GetGwpAvg_WithInValidInput_ReturnsEmptyResult()
        {
            //Arrange
            List<Gwp> gwps = new List<Gwp>() {
                new Gwp{ Country = "as", LineOfBusiness = "t_s", AvgGwp = 100},
                new Gwp{ Country = "as", LineOfBusiness = "transport", AvgGwp = 1000},
            };

            GwpRequest request = new GwpRequest
            {
                CountryCode = "ae",
                lineOfBusiness = new List<string>
                {
                    "t_s",
                    "transport",
                }
            };

            var gwpRepo = new Mock<IGwpRepository>(MockBehavior.Strict);
            gwpRepo.Setup(p => p.GetGwp()).Returns(gwps);
            var gwpManager = new GwpManager(gwpRepo.Object);

            //Act
            var result = gwpManager.GetGwpAvg(request);

            //Assert
            Assert.That(result.Count, Is.EqualTo(0));
            gwpRepo.VerifyAll();
        }
    }
}