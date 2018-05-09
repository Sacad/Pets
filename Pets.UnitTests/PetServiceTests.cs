using NUnit.Framework;
using Moq;
using Assert = NUnit.Framework.Assert;
using AGLTest.Services;
using AGLTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace AGLTest.UnitTests
{
    [TestFixture]
    public class PetServiceTests
    {
        private Mock<IWebClient> _webClientMock;
        
        [SetUp]
        public void Setup()
        {
            _webClientMock = new Mock<IWebClient>();
        }

        public PetService CreatePetService()
        {
            var petService = new PetService();

            return petService;
        }

        [TestCase]
        public void FilterCatsAndSelectCatNameAndOwnerGender_WhenPetsWithCatsPassed_ReturnsFilteredCats()
        {
            //arrange
            var petService = CreatePetService();

            List<Pet> listOfPetsIncludingCats = new List<Pet>()
            {
                new Pet
                {
                    Name = "Garfield",
                    Type = "Cat"
                },
                new Pet
                {
                    Name = "Misty",
                    Type = "Cat"
                },
                new Pet
                {
                    Name = "Bruce",
                    Type = "Dog"
                },
            };
            
            var unorderedListOfOwners = new List<Owner>
            {
                new Owner
                {
                    Name = "Bob",
                    Age = 23,
                    Gender = "Male",
                    Pets = listOfPetsIncludingCats
                }
            };

            var result = new List<Cat>
            {
                new Cat
                {
                    Name = "Garfield",
                    OwnerGender = "Male"
                },
                new Cat
                {
                    Name = "Misty",
                    OwnerGender = "Male"
                },
               
            }.OrderBy(s => s.Name).ToList();
            
            //act
            var actual = petService.FilterCatsAndSelectCatNameAndOwnerGender(unorderedListOfOwners);

            //assert
            Assert.AreEqual(actual, result);
        }

        [TestCase]
        public void FilterCatsAndSelectCatNameAndOwnerGender_WhenNullPetsAndCatsPassed_ReturnsFilteredCats()
        {
            //arrange
            var petService = CreatePetService();

            var listOfPetsIncludingACatAndNull = new List<Pet>
            {
                new Pet
                {
                    Name = "Garfield",
                    Type = "Cat"
                },
                new Pet
                {
                    
                },
            };

            var unorderedListOfOwners = new List<Owner>
            {
                new Owner
                {
                    Name = "Bob",
                    Age = 23,
                    Gender = "Male",
                    Pets = listOfPetsIncludingACatAndNull
                }
            };

            var actual = new List<Cat>
            {
                new Cat
                {
                    Name = "Garfield",
                    OwnerGender = "Male"
                },
                new Cat
                {
                    Name = "Misty",
                    OwnerGender = "Male"
                },
               
            }.OrderBy(s => s.Name).ToList().Take(1);

            //act
            var result = petService.FilterCatsAndSelectCatNameAndOwnerGender(unorderedListOfOwners);

            //assert
            Assert.AreEqual(result, actual);
        }

        [TestCase]
        public void filterCats_WhenOwnersWithPetsIsPassed_ReturnsFilteredCats()
        {
            //arrange
            var petService = CreatePetService();

            var listOfPetsIncludingCats = new List<Pet>
            {
                new Pet
                {
                    Name = "Garfield",
                    Type = "Cat"
                },
                new Pet
                {
                    Name = "Misty",
                    Type = "Cat"
                },
                new Pet
                {
                    Name = "Bruce",
                    Type = "Dog"
                },
            };

            var unorderedListOfOwners = new List<Owner>
            {
                new Owner
                {
                    Name = "Bob",
                    Age = 23,
                    Gender = "Male",
                    Pets = listOfPetsIncludingCats
                }
            };

            var actual = new List<Cat>
            {
                new Cat
                {
                    Name = "Garfield",
                    OwnerGender = "Male"
                },
                new Cat
                {
                    Name = "Misty",
                    OwnerGender = "Male"
                },

            }.OrderBy(s => s.Name).ToList();

            //act
            var response = petService.FilterCats(unorderedListOfOwners);

            //assert
            Assert.AreEqual(response, actual);
        }
    }
}
