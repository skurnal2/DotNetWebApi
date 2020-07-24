using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiExerciseVintriTech.Helpers.DTOs
{
    /// <summary>
    /// DTO class for combining using LINQ
    /// </summary>
    public class BeerDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public BeerRatingResponse[] UserRatings { get; set; }
    }
}