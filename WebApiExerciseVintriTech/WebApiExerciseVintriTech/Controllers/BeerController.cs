using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

            Dictionary<string, string[]> errorsDictionary = new Dictionary<string, string[]>();
            errorsDictionary.Add("errors", errors.ToArray());

            if (errors.Count > 0)
            {
                message = Request.CreateResponse(HttpStatusCode.BadRequest, errorsDictionary);
            }
            else
            {
                message = Request.CreateResponse(HttpStatusCode.OK , rating);
            }

            


            return message;
        }
    }
}
