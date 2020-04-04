using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;


namespace DestCovery.Controllers
{
    public class MesageService
    {
        public string TextLocal(string ph, string msg)
        {
            string destinationaddr = "91" + ph;
            string message = msg;
            String result;
            //string apiKey = "VbH7+OLYKD8-7TnjGDListPZazTngiw9TFk84Ltbq2"; Shreedhar Sir
            string apiKey = "dfwAxr6NrDg-bdN7YQBGgLGefvzfJ0QAAqipyGRDTx";//Mine
            /*string apiKey = "dfwAxr6NrDg-MPvbKg1H4gNiqL5F1YHqFWS1r58jdv";
            string apiShreedhar Sir = "VbH7+OLYKD8-7TnjGDListPZazTngiw9TFk84Ltbq2";*/
            //string numbers = "917447553739"; // in a comma seperated list
            // string message = "This is your message";
            string sender = "SANSAH";

            String url = "https://api.textlocal.in/send/?apikey=" + apiKey + "&numbers=" + destinationaddr + "&message=" + message + "&sender=" + sender;
            //refer to parameters to complete correct url string

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

            objRequest.Method = "POST";
            objRequest.ContentLength = System.Text.Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
                //Session["otp"] = value;
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            var obj = JObject.Parse(result);
            //return (string)obj["status"];
            return result;
        }
    }
}