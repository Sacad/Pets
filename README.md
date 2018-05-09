README:
The Pets Solution displays lists of Cats (Pets) and orders them by the gender of their owners.

The solutions is build using Visual Studio 2017 and Uses MVC 4.0 and .NetFramework 4.5.2

Pets project calls a json service that returns a lists of pets, then deseralises them using JavaScriptSerializer,
the filters the deseralised results by only returning list of cats before finallying displaying the results. 

There are 8 units in the Pets.Units project which test the PetController, PetService anf finally OwnersSerialiser.
The tests use NUnit 2.6.4 and Moq 4.7.8.

TODO: 
Logging using Log4Net

CONTACT:
Sa'ad Shukri 
Sacadmagan@gmail.com
https://www.linkedin.com/in/sa-ad-shukri-14312639/