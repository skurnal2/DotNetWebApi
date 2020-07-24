using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiExerciseVintriTech.Helpers
{
    /// <summary>
    /// Data class for retrieving the response
    /// </summary>
    public class BeerRatingResponse
    {        
        public String Username { get; set; }
        public double Rating { get; set; }
        public String Comments { get; set; }
    }
}