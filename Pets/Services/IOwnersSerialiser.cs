using System.Collections.Generic;
using AGLTest.Models;

namespace AGLTest.Services
{
    public interface IOwnersSerialiser
    {
        IEnumerable<Owner> SerialiseResponse(string response);
    }
}