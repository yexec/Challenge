using FluentAssertions;
using GIG.API.Test.Code.Challenge.Base;
using GIG.API.Test.Code.Challenge.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GIG.API.Test.Code.Challenge.StepDefinitions
{
    [Binding]
    public class CreateUserSteps
    {
        private readonly Settings _settings;

        public CreateUserSteps(Settings settings)
        {
            _settings = settings;
        }
        [When(@"I create user with the following details")]
        public void WhenICreateUserWithTheFollowingDetails(Table table)
        {
            var createUserRequests = table.CreateSet<CreateUser>();
            Console.WriteLine("created object is "+ createUserRequests);
            
            _settings.request = new RestRequest("/api/register", Method.POST);
            _settings.request.RequestFormat = DataFormat.Json;
            _settings.request.AddJsonBody(
                new {
                    email = "charles.morris@reqres.in",
                    password = "pi12345" });
            _settings.response = _settings.client.Execute(_settings.request);
            
        }

        [Then(@"User is created successfully")]
        public void ThenUserIsCreatedSuccessfully()
        {
            //Work on Response for assertion

           // dynamic jsonResponse = JsonConvert.DeserializeObject(_settings.response.Content);
            _settings.response.StatusCode.Should().Be(HttpStatusCode.OK);

        }


    }
}
