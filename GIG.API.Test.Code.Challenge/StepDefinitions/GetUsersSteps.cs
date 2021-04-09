using FluentAssertions;
using GIG.API.Test.Code.Challenge.Base;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace GIG.API.Test.Code.Challenge.StepDefinitions
{
    [Binding]
    public class GetUsersSteps

    {
        private readonly Settings _settings;


        public GetUsersSteps(Settings settings)
        {
            _settings = settings;
        }
        

        [Given(@"I perform GET operation for ""(.*)""")]
        public void GivenIPerformGETOperationFor(string endPoint)
        {
           _settings.request = new RestRequest(endPoint, Method.GET);
            Console.WriteLine("Request "+ _settings.request);
            _settings.response = _settings.client.Execute(_settings.request);
        }
        
        [Then(@"I should see response code of ""(.*)""")]
        public void ThenIShouldSeeResponseCodeOf(int statusCode)
        {
            Console.WriteLine("response status code: " + _settings.response.StatusCode);
            _settings.response.StatusCode.Should().Be(statusCode);
        }
    }
}
