using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using WebApiExerciseVintriTech.Controllers;
using WebApiExerciseVintriTech.Helpers.API;
using WebApiExerciseVintriTech.Helpers.DTOs;

namespace WebApiTest
{
    [TestClass]
    public class WebApiTest
    {
        [TestMethod]
        public void TestGetBeersByName_ShouldReturnMultipleBeers()
        {
            string testName = "sco";

            //Getting beers for test Name
            PunkApi api = new PunkApi();
            var apiBeers = api.GetBeersByName(testName);

            //Getting beers using Controller
            BeerController controller = new BeerController();
            var controllerResult = controller.Get(testName);

            ////Deserializing
            //var controllerBeers = JsonConvert.DeserializeObject<List<BeerDTO>>(controllerResult.ToString());

            //Assert.AreEqual(apiBeers.Count, controllerBeers.Count);
            
        }
    }
}
