using GIG.API.Test.Code.Challenge.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using TechTalk.SpecFlow;

namespace GIG.API.Test.Code.Challenge.Hooks
{
    [Binding]
    public class TestInitialize
    {
        private  Settings _settings;

        public TestInitialize(Settings settings)
        {
            _settings = settings;
        } 
       
        [BeforeScenario]
        public void TestSetup()
        {
            Console.WriteLine("before scenario call " + ConfigurationManager.AppSettings["baseUrl"]);
            _settings.BaseUrl = new Uri("https://reqres.in");//new Uri(ConfigurationManager.AppSettings["baseUrl"].ToString());
            _settings.client.BaseUrl = _settings.BaseUrl;
        }
    }
}
