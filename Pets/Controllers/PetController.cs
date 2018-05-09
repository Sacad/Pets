using System;
using AGLTest.Models;
using AGLTest.Services;
using AttributeRouting.Web.Mvc;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AGLTest.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        private readonly IWebClient _webClient;
        private readonly IOwnersSerialiser _ownersSerialiser;

        public PetController(IPetService petService, IWebClient webClient, IOwnersSerialiser ownersSerialiser)
        {
            _webClient = webClient;
            _ownersSerialiser = ownersSerialiser;
            _petService = petService;
        }

        [HttpGet]
        [Route("Cats")]
        public ActionResult Index()
        {
            try
            {
                var jsonResponse = _webClient.DownloadString();
                var serialiseResponse = _ownersSerialiser.SerialiseResponse(jsonResponse);
                var cats = _petService.FilterCatsAndSelectCatNameAndOwnerGender(serialiseResponse);
                return View(cats);
            }
            catch
            {
                return RedirectToAction("Error");
            } 
        }
        
        public ActionResult Error()
        {
            return View();
        }
        
    }
}
