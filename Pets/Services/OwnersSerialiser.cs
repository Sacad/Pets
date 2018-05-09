using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using AGLTest.Models;

namespace AGLTest.Services
{
    public class OwnersSerialiser : IOwnersSerialiser
    {
        public IEnumerable<Owner> SerialiseResponse(string response)
        {
            var serializer = new JavaScriptSerializer();

            try
            {
                return serializer.Deserialize<List<Owner>>(response);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not Deserialize json object " + ex.Message);
            }
        }
    }
}