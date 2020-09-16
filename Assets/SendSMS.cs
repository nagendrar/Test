using System;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using UnityEngine;
using System.Web;

public class SendSMS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //twilio
        //const string accountSid = "AC45b0774ee7ecc70596ae019f17134db4";
        //const string authToken = "97eca2785b5b76d23cba563eefd6d0e5";

        //TwilioClient.Init(accountSid, authToken);

        //var message = MessageResource.Create(
        //    body: "This is the ship that made the Kessel Run in fourteen parsecs?",
        //    from: new Twilio.Types.PhoneNumber("+918500010266"),
        //    to: new Twilio.Types.PhoneNumber("+918500010266")
        //);

        //Debug.Log(message.Sid);
    }

    //public string sendSMS()
    //{
        //String message = HttpUtility.UrlEncode("This is your message");
        //using (var wb = new WebClient())
        //{
        //    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
        //        {
        //        {"apikey" , "hPswuUGjrt4-sfsisjSySPKSJV09RQJBOFAnS1E6PN"},
        //        {"numbers" , "918123456789"},
        //        {"message" , message},
        //        {"sender" , "TXTLCL"}
        //        });
        //    string result = System.Text.Encoding.UTF8.GetString(response);
        //    return result;
        //}
    //}
}
