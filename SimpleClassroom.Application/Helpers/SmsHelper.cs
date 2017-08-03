using SimpleClassroom.Domain.Contracts.Services.Helpers;
using SimpleClassroom.Domain.Utils;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SimpleClassroom.Application.Helpers
{
    public class SmsHelper : ISmsHelper
    {
        private const string ACCOUNT_ID = "AC4a8e982cbc7f36deeefc6693cc0cdcba"; //alterar
        private const string AUTH_TOKEN = "ba8171a97c94fd2f179cae6365829f93"; //alterar
        private const string NUMBER_FROM = "+556140425125"; //alterar

        public void Send(Sms sms)
        {
            TwilioClient.Init(ACCOUNT_ID, AUTH_TOKEN);

            MessageResource.Create(
                to: new PhoneNumber(sms.NumberTo),
                from: new PhoneNumber(NUMBER_FROM),
                body: sms.Message);
        }

        public Task SendAsync(Sms sms)
        {
            TwilioClient.Init(ACCOUNT_ID, AUTH_TOKEN);

            return MessageResource.CreateAsync(
                to: new PhoneNumber(sms.NumberTo),
                from: new PhoneNumber(NUMBER_FROM),
                body: sms.Message);
        }
    }
}
