using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Healthware.Core.DTO;
using Newtonsoft.Json;

namespace Healthware.Core.Web.Web.Common.SMS
{
    public interface ISMSService
    {
        string GetOTP();
        string SendSMSToCell(string cellNumber, string OTP);
    }
    public class SMSService : ISMSService
    {
        public string GetOTP()
        {
            var r = new Random();
            var OTP = r.Next(1000, 9999).ToString();
            return OTP;
        }

        public string SendSMSToCell(string cellNumber, string OTP)
        {

            var messages = new List<SMSMessage>
            {
                new SMSMessage()
                {
                    to = cellNumber,
                    source = Constants.Source,
                    body = string.Format(Constants.OtpMessage, OTP)
                }
            };

            var root = new SMSRoot
            {
                Messages = messages
            };
            var requestBody = JsonConvert.SerializeObject(root);


            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://rest.clicksend.com/v3/sms/send");
            httpWebRequest.ContentType = Constants.Application;
            httpWebRequest.Accept = Constants.Accept;
            httpWebRequest.Method = Constants.Post;
            httpWebRequest.Headers[Constants.Authorization] = Constants.Basic + Convert.ToBase64String(Encoding.Default.GetBytes(Constants.SmsKey));

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(requestBody);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string resp = string.Empty;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                resp = streamReader.ReadToEnd();
            }

            return resp;
        }
    }
}
