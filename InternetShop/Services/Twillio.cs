using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace InternetShop.Services
{
    public class Twillio
    {        
        public static void SendSms(string phone, int code)
        {
            string accountSid = Environment.GetEnvironmentVariable("AC297c271ef56c987b77ec37e2d3da4206");
            string authToken = Environment.GetEnvironmentVariable("9ae12edd18e44255eacd5c46bd5d5bf1");

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: $"Ваш код - {code}",
                from: new Twilio.Types.PhoneNumber("+12059472980"),
                to: new Twilio.Types.PhoneNumber(phone)
            );

            Console.WriteLine(message.Sid);
        }
    }
}
