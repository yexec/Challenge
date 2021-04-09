using FluentAssertions;
using GIG.API.Test.Code.Challenge.Base;
using GIG.API.Test.Code.Challenge.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GIG.API.Test.Code.Challenge.StepDefinitions
{
    [Binding]
    class CreateInvalidUser
    {
        private readonly Settings _settings;

        public CreateInvalidUser(Settings settings)
        {
            _settings = settings;
        }

        [When(@"I crwate user with the following detail")]
        public void WhenICrwateUserWithTheFollowingDetail(Table table)
        {

            var createUserRequests = table.CreateSet<CreateUser>();
            Console.WriteLine("created object is " + createUserRequests);

            _settings.request = new RestRequest("/api/register", Method.POST);
            _settings.request.RequestFormat = DataFormat.Json;
            //Sending Anonymous object data
            _settings.request.AddJsonBody(
                new
                {
                    email = "charles.morris@reqres.in"
                });
            _settings.response = _settings.client.Execute(_settings.request);
        }

        [Then(@"User is not created successfully")]
        public void ThenUserIsNotCreatedSuccessfully()
        {
            _settings.response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

    }
}
