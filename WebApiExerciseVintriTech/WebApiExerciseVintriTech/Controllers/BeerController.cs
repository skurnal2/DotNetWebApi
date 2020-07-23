using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using WebApiExerciseVintriTech.Helpers;
using WebApiExerciseVintriTech.Helpers.API;

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
                //Appending JSON to file (database.json)  
                WriteToJsonFile(rating);

                Dictionary<string, string> messageDictionary = new Dictionary<string, string>();
                messageDictionary.Add("message", "Rating Successfully Added");
                message = Request.CreateResponse(HttpStatusCode.OK , rating);
            }

            return message;
        }

        public bool WriteToJsonFile(BeerRating rating)
        {
            //Rating to be added
            string newRating = new JavaScriptSerializer().Serialize(rating);

            //File Path
            var jsonFilePath = Path.Combine(Environment.CurrentDirectory, "database.json");

            //Reading the file
            var jsonData = File.ReadAllText(jsonFilePath);

            
            return false;
        }
    }
}
