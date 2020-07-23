using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExerciseVintriTech.Helpers;
using WebApiExerciseVintriTech.Helpers.API;
using WebApiExerciseVintriTech.Helpers.DTOs;
using WebApiExerciseVintriTech.Helpers.POCOs;

namespace WebApiExerciseVintriTech.Controllers
{
    public class BeerController : ApiController
    {
        // POST api/beer/id
        public HttpResponseMessage Post(int id, [FromBody] BeerRating rating)
        {
            HttpResponseMessage message = null;
            List<string> errors = new List<string>();

            PunkApi punkObj = new PunkApi();
            if (!punkObj.CheckIdExists(id))
            {
                errors.Add("ID does not exist");
            }

            if (rating.Rating < 1 || rating.Rating > 5)
            {
                errors.Add("Not a valid rating. Should be between 1 and 5");
            }

            if (errors.Count > 0)
            {
                Dictionary<string, string[]> messageDictionary = new Dictionary<string, string[]>();
                messageDictionary.Add("errors", errors.ToArray());
                message = Request.CreateResponse(HttpStatusCode.BadRequest, messageDictionary);
            }
            else
            {
                Dictionary<string, string> messageDictionary = new Dictionary<string, string>();

                //Appending JSON to file (database.json)  
                try
                {
                    rating.Id = id; //Attaching id to rating object
                    WriteToJsonFile(rating);

                    messageDictionary.Add("message", "Rating Successfully Added");
                    message = Request.CreateResponse(HttpStatusCode.OK, messageDictionary);
                }
                catch (IOException ex)
                {
                    messageDictionary.Add("error", "Could not write to JSON file. \n Error: " + ex.Message);
                    message = Request.CreateResponse(HttpStatusCode.InternalServerError, messageDictionary);
                }
            }

            return message;
        }

        public HttpResponseMessage Get(string name)
        {
            PunkApi punkObj = new PunkApi();
            HttpResponseMessage message;
            Dictionary<string, string> messageDictionary = new Dictionary<string, string>();

            try
            {
                //Getting Beer results by name
                List<BeerInfo> result = punkObj.GetBeersByName(name);

                //Loading database json file
                List<BeerRating> currentRatings = GetCurrentRatings();

                //Doing Linq to combine results to ratings and reviews
                var combinedResult = from x in result
                                     select new BeerDTO
                                     {
                                         Id = x.Id,
                                         Name = x.Name,
                                         Description = x.Description,
                                         UserRatings = (from y in currentRatings
                                                        where x.Id == y.Id
                                                        select y).ToArray()
                                     };

                message = Request.CreateResponse(HttpStatusCode.OK, combinedResult);
            }
            catch (Exception ex)
            {
                name = name == null ? "[null]" : name;
                messageDictionary.Add("error", "Could not process your request for name: " + name + " Error: " + ex.Message);
                message = Request.CreateResponse(HttpStatusCode.OK, messageDictionary);
            }

            return message;
        }

        //Helper Methods
        public bool WriteToJsonFile(BeerRating rating)
        {
            //File Path
            var jsonFilePath = System.Web.HttpContext.Current.Server.MapPath(@"~/database.json");

            //Reading the file
            var jsonData = File.ReadAllText(jsonFilePath);

            //List of Ratings to store current values or an empty list if none exists
            List<BeerRating> currentRatingsStored = new List<BeerRating>();
            currentRatingsStored = JsonConvert.DeserializeObject<List<BeerRating>>(jsonData) ?? new List<BeerRating>();

            //Adding newest Rating to the List
            currentRatingsStored.Add(rating);

            //Updating the file
            jsonData = JsonConvert.SerializeObject(currentRatingsStored);
            File.WriteAllText(jsonFilePath, jsonData);

            return false;
        }

        public List<BeerRating> GetCurrentRatings()
        {
            // File Path
            var jsonFilePath = System.Web.HttpContext.Current.Server.MapPath(@"~/database.json");

            //Reading the file
            var jsonData = File.ReadAllText(jsonFilePath);

            //List of Ratings to store current values or an empty list if none exists
            List<BeerRating> currentRatingsStored = new List<BeerRating>();
            currentRatingsStored = JsonConvert.DeserializeObject<List<BeerRating>>(jsonData) ?? new List<BeerRating>();

            return currentRatingsStored;
        }
    }
}
