using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Text;

namespace MACACO.Clases
{
    public class MensajitosSMS
    {
        public void EnviarMensaje(string mensaje)
        {
            TwilioClient.Init(
                    username: ("ACab1f3d2e5f9afcf85b9aa6a4eeda8a01"),
                    password: ("4495c0056e63e0bbf1a8709dc77aa72b"));

            MessageResource.Create(
                     to: new PhoneNumber("+50373598472"),
                     from: new PhoneNumber("+12512414005"),
                     body: mensaje);
        }
    }
}