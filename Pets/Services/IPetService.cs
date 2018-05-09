using AGLTest.Models;
using System.Collections.Generic;

namespace AGLTest.Services
{
    public interface IPetService
    {
        IEnumerable<Cat> FilterCatsAndSelectCatNameAndOwnerGender(IEnumerable<Owner> owners);
        IEnumerable<Cat> FilterCats(IEnumerable<Owner> owners);
    }
}