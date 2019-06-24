using Contracts;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Services
{
    public class NotificationService
    {
        ILoggerManager _logger;
        INotificationReposatory _notificationReposatory;
        public NotificationService(ILoggerManager logger,INotificationReposatory notificationReposatory)
        {
            _notificationReposatory = notificationReposatory;
            _logger = logger;
        }
        public void SendNotification(string[] Tokens,Data dataObject)
        {
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            //serverKey - Key from Firebase cloud messaging server  
            tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAwULsjXU:APA91bGA7GhTEeplUYgZ8PGXGFFgfcZc3fq2VnCa0vzeHi1J-LKjCuckO0BhtyQjn9y-PsDYKN6AMdymnbtYqM8Tk-JOB4BDjSCq1Cq_mUCEGIP059dPcpv5Mq_ydIN2fBRDTIzfa6p2"));
            //Sender Id - From firebase project setting  
            tRequest.Headers.Add(string.Format("Sender: id={0}", "830051487093"));
            tRequest.ContentType = "application/json";
            var payload = new
            {
                priority = "high",
                registration_ids=Tokens,
                data =dataObject
            };
            
            string postbody = JsonConvert.SerializeObject(payload).ToString();
            _logger.LogInfo(postbody);
            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                //result.Response = sResponseFromServer;
                            }
                    }
                }
            }
        }

        public void AddNotification(Notification notification)
        {
            _notificationReposatory.Add(notification);
        }
    }
}
