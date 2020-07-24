using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiExerciseVintriTech.Helpers.POCOs
{
    /// <summary>
    /// A data class for Beer Info
    /// </summary>
    public class BeerInfo
    {        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }        
    }
}