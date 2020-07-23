using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiExerciseVintriTech.Helpers
{
    public class BeerRating
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public double Rating { get; set; }
        public String Comments { get; set; }
    }
}