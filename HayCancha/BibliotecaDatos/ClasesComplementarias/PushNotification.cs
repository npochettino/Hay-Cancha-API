using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BibliotecaDatos.ClasesComplementarias
{
    public class PushNotification
    {
        public static bool Enviar(string pushMessage)
        {
            bool isPushMessageSend = false;

            string postString = "";
            string urlpath = "https://api.parse.com/1/push";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlpath);

            postString = "{ \"channels\": [ \"SempaIT\"  ], " +
                             "\"data\" : {\"alert\":\"" + pushMessage + "\"}" +
                             "}";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.ContentLength = postString.Length;
            httpWebRequest.Headers.Add("X-Parse-Application-Id", "meTN9fiV0dNY0AahE91RjNM2kfiTAkDsnU1KWgmC");
            httpWebRequest.Headers.Add("X-Parse-REST-API-KEY", "12WdR3OMwHCd8FVDefHAOVb3kTl4bEr7JUWc1ABf");
            httpWebRequest.Method = "POST";
            StreamWriter requestWriter = new StreamWriter(httpWebRequest.GetRequestStream());
            requestWriter.Write(postString);
            requestWriter.Close();
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                JObject jObjRes = JObject.Parse(responseText);
                if (Convert.ToString(jObjRes).IndexOf("true") != -1)
                {
                    isPushMessageSend = true;
                }
            }

            return isPushMessageSend;
            return true;
        }

        public static bool SendPersonalPush(string deepLink, string message, string deviceToken)
        {
            bool isPushMessageSend = false;

            string urlpath = "https://api.parse.com/1/push";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlpath);

            string postString = "{ \"where\": { \"deviceToken\": \""+ deviceToken +"\" }, \"data\": { \"deep_link\": \""+ deepLink +"\" , \"message\": \"" + message + "\" , \"title\": \"HayCancha!!\" } }";

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.ContentLength = postString.Length;
            httpWebRequest.Headers.Add("X-Parse-Application-Id", "2p3PaBJnkhIVS4j2elSz51g3lXvOk1sszrnveJwj");
            httpWebRequest.Headers.Add("X-Parse-REST-API-KEY", "7ZoaWHmfx7ylD3fC4bzI1sg5PnydldYM7RicqQqQ");
            httpWebRequest.Method = "POST";
            StreamWriter requestWriter = new StreamWriter(httpWebRequest.GetRequestStream());
            requestWriter.Write(postString);
            requestWriter.Close();
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
                JObject jObjRes = JObject.Parse(responseText);
                if (Convert.ToString(jObjRes).IndexOf("true") != -1)
                {
                    isPushMessageSend = true;
                }
            }

            return isPushMessageSend;

            return true;
        }

    }
}
