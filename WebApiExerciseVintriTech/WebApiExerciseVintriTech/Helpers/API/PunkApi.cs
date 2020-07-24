using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using WebApiExerciseVintriTech.Helpers.POCOs;

namespace WebApiExerciseVintriTech.Helpers.API
{
    /// <summary>
    /// Class for retrieving info from Punk API
    /// </summary>
    public class PunkApi
    {
        string root_url = "https://api.punkapi.com/v2/beers";

        /// <summary>
        /// Checks the identifier exists using Punk API.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Boolean whether or not it exists.</returns>
        public bool CheckIdExists(int id) {

            //Concatenating id sent in method with the API url
            string customUrl = root_url + "/" + id;
            WebRequest requestObjGet = WebRequest.Create(customUrl);
            requestObjGet.Method = "GET";
            HttpWebResponse responseObjGet = null;

            try
            {
                //Getting the response code
                responseObjGet = requestObjGet.GetResponse() as HttpWebResponse;

                //If Code returned is 200 OK, then return true, otherwise return false
                if (responseObjGet.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (WebException ex)
            {
                //If in some case, error occurs, or 404 returned - return false
                responseObjGet = ex.Response as HttpWebResponse;
                return false;
            }

           
        }

        /// <summary>
        /// Gets the beers using name from Punk API.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>List of Beers (using BeerInfo data class)</returns>
        public List<BeerInfo> GetBeersByName(string name) {
            string customUrl = root_url + "?beer_name=" + name;
            WebRequest requestObjGet = WebRequest.Create(customUrl);
            requestObjGet.Method = "GET";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();

            string api_result = null;
            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                api_result = reader.ReadToEnd();
                reader.Close();
            }

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<BeerInfo> objectList = (List<BeerInfo>) serializer.Deserialize(api_result, typeof(List<BeerInfo>));

            return objectList;
        }
    }
}