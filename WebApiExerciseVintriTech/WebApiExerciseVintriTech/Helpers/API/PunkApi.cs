using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApiExerciseVintriTech.Helpers.API
{
    public class PunkApi
    {
        string root_url = "https://api.punkapi.com/v2/beers";

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
    }
}