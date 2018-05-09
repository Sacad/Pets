using NUnit.Framework;
using Moq;
using Assert = NUnit.Framework.Assert;
using AGLTest.Services;
using AGLTest.Controllers;
using AGLTest.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AGLTest.UnitTests
{
    [TestFixture]
    public class PetControllerTests
    {
        private Mock<IPetService> _petService;
        private Mock<IWebClient> _webClient;
        private Mock<IOwnersSerialiser> _serialise;

        [SetUp]
        public void Setup()
        {
            _petService = new Mock<IPetService>();
            _webClient = new Mock<IWebClient>();
            _serialise = new Mock<IOwnersSerialiser>();
        }

        public PetController CreatePetController()
        {
            var petController = new PetController(_petService.Object, _webClient.Object, _serialise.Object);

            return petController;
        }
        [TestCase]
        public void Index_CorrectViewReturned()
        {
            //Arrange

            var petsController = CreatePetController();

            //act
            var result = petsController.Index();

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }

        [TestCase]
        public void Index_PetServiceThrowsException_RedirectToErrorAction()
        {
            //arrange

            var petsController = CreatePetController();
            _webClient.Setup(o => o.DownloadString()).Returns("fake string");
            _petService.Setup(o => o.FilterCatsAndSelectCatNameAndOwnerGender(It.IsAny<IEnumerable<Owner>>())).Throws(new System.Exception("404"));

            //act
            var result = petsController.Index() as RedirectToRouteResult;

            //assert
            Assert.IsNotNull(result);        
            Assert.AreEqual("Error", result.RouteValues["action"]);
        }
        
        [TestCase]
        public void Index_CatsByOwnderGenderListReturned()
        {
            //arrange
            
            var cat = new List<Cat>
            {
                new Cat
                {
                    Name = "Bob",
                    OwnerGender = "Male"
                },
                new Cat
                {
                    Name = "smith",
                    OwnerGender = "Male"
                },

            };

            _petService.Setup(o => o.FilterCatsAndSelectCatNameAndOwnerGender(It.IsAny<IEnumerable<Owner>>())).Returns(cat);

            var compareLogic = CompareLogicCreator.Create();

            var petsController = CreatePetController();

            //act
            var allCats = (ViewResult)petsController.Index();

            var compareResults = compareLogic.Compare(cat,allCats.Model);

            //assert
            Assert.IsTrue(compareResults.AreEqual, compareResults.DifferencesString);

        }
        
    }
}
