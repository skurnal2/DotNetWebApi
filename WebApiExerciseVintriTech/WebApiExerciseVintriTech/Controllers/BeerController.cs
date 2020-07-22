using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExerciseVintriTech.Helpers;

namespace WebApiExerciseVintriTech.Controllers
{
    public class BeerController : ApiController
    {
        // POST api/beer/id
        public HttpResponseMessage Post(int id, [FromBody] BeerRating rating)
        {
            var message = Request.CreateResponse(HttpStatusCode.Created, "It Works! You sent id " + id);
            return message;
        }
    }
}
