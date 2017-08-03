using RestSharp;
using RestSharp.Authenticators;
using SimpleClassroom.Domain.Contracts.Services.Helpers;
using SimpleClassroom.Domain.Utils;
using System;
using System.Threading.Tasks;

namespace SimpleClassroom.Application.Helpers
{
    public class EmailHelper : IEmailHelper
    {
        private const string API_KEY = "key-91a3c5bbf2d28bf6e752aaecbd644e69"; //alterar
        private const string API_URL = "https://api.mailgun.net/v3";
        private const string DOMAIN = "sandbox3d2ea53d7b5d49bdad47e77a77b26139.mailgun.org"; //alterar
        private const string EMAIL_SENDER = "Simple manager <postmaster@sandbox3d2ea53d7b5d49bdad47e77a77b26139.mailgun.org>"; //alterar

        public void Send(Email email)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(API_URL);
            client.Authenticator = new HttpBasicAuthenticator("api", API_KEY);

            var request = new RestRequest();
            request.AddParameter("domain", DOMAIN, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", EMAIL_SENDER);
            request.AddParameter("subject", email.Subject);
            request.AddParameter("text", email.Message);
            request.Method = Method.POST;

            email.To.ForEach(to =>
            {
                request.AddParameter("to", to);
            });

            client.Execute(request);
        }

        public Task SendAsync(Email email)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(API_URL);
            client.Authenticator = new HttpBasicAuthenticator("api", API_KEY);

            var request = new RestRequest();
            request.AddParameter("domain", DOMAIN, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", EMAIL_SENDER);
            request.AddParameter("subject", email.Subject);
            request.AddParameter("text", email.Message);
            request.Method = Method.POST;

            email.To.ForEach(to =>
            {
                request.AddParameter("to", to);
            });

            return client.ExecuteTaskAsync(request);
        }
    }
}
