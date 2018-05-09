using AGLTest.Models;
using AGLTest.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using Pet = AGLTest.Models.Pet;

namespace AGLTest.Services
{
    public class PetService : IPetService
    {
        
        public IEnumerable<Cat> FilterCatsAndSelectCatNameAndOwnerGender(IEnumerable<Owner> owners)
        {
            var catsByOwnerGender = FilterCats(owners);

            return catsByOwnerGender;
        }

        public IEnumerable<Cat> FilterCats(IEnumerable<Owner> owners)
        {
            var cats = from owner in owners
                from pet in owner.Pets ?? new List<Pet>()
                where pet.Type == Models.Enums.Pet.Cat.ToString()
                orderby pet.Name
                select new Cat
                {
                    Name = pet.Name,
                    OwnerGender = owner.Gender
                };

            return cats;
        }

    }
}