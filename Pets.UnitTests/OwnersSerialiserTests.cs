using System;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using AGLTest.Services;
using AGLTest.Models;
using System.Collections.Generic;

namespace AGLTest.UnitTests
{
    [TestFixture]
    public class OwnersSerialiserTests
    {
        public OwnersSerialiser CreateSerialiser()
        {
            var serialiser = new OwnersSerialiser();

            return serialiser;
        }

        [TestCase]
        public void SerialiseResponse_WhenCorrectJSonStringPassed_ReturnsSerialisedObject()
        {
            //arrange
            string JsonString = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Misty\",\"type\":\"Cat\"}]}]";

            var serialised = CreateSerialiser();

            //act

            var response =  serialised.SerialiseResponse(JsonString);

            //assert

            Assert.IsInstanceOf<IEnumerable<Owner>>(response);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentException))]
        public void SerialiseResponse_WhenIncorrectJSonStringPassed_ArgumentException()
        {
            //arrange
            string JsonString = "[{\"incorrect\":\"json\",\"format\":\"string\",}]";

            var serialised = CreateSerialiser();

            //act

            var response = serialised.SerialiseResponse(JsonString);

            //assert

            Assert.IsNull(response);
        }
    }
}
