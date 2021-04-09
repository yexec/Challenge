using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GIG.API.Test.Code.Challenge.Base
{
   public class Settings
    {
        public Uri BaseUrl { get; set; }
        public RestClient client = new RestClient("https://reqres.in/");
        public RestRequest request = new RestRequest();
        public IRestResponse response = new RestResponse();
    }
}
