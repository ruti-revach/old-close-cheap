using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using System.Net;
using System.Xml;

namespace BLL
{
 public   class Alguritem
    {
        public static int DistanceInMinutes(string fNode, string sNode)
        {
            string uri = "https://maps.googleapis.com/maps/api/place/textsearch/json?key=AIzaSyDEPtSp3Za3ekttM_2ueZyiqoSCCO-9BUc="
                          + fNode + "&destinations=" + sNode + "&mode=driving&units=imperial&sensor=false&key=AIzaSyDEPtSp3Za3ekttM_2ueZyiqoSCCO-9BUc";
            WebClient wc = new WebClient();
            try
            {
                string geoCodeInfo = wc.DownloadString(uri);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(geoCodeInfo);
                //קבלת תשובה מהשרת
                string duration = (xmlDoc.DocumentElement as XmlNode).SelectSingleNode("//DistanceMatrixResponse/row/element/duration/value").InnerText;
                return Convert.ToInt32(duration) / 60;
            }
            catch (Exception)
            {
                Console.WriteLine(-1);
            }
            return TravelingTime;
        }

        static string BuildUrlForLocationId(string[] address)
        {
            string location = "";
            string[] locationAsArray;
            locationAsArray = address;

            for (int i = 0; i < locationAsArray.Length; i++)
            {
                if (i < locationAsArray.Length - 1)
                    location += locationAsArray[i] + "+";
                else
                    location += locationAsArray[i];
            }
            return "https://maps.googleapis.com/maps/api/place/textsearch/json?key=AIzaSyDEPtSp3Za3ekttM_2ueZyiqoSCCO-9BUc=" + location + "&mode=driving&units=imperial&sensor=true";
        }

        /// <summary>
        ///       הפונקציה בונה url ל-Api של GoogleMaps שמחזיר את המרחק בין כל הכתובת

        static string BuildUrlForDistance(string place1, string place2)
        {
            string url = "https://maps.googleapis.com/maps/api/distancematrix/json?key=<AIzaSyDLx4T9acALeR_MVxsAquIsm9bzLjjhZ7c>&units=imperial&origins=";
            return url + "place_id:" + place1 + "&destinations=place_id:" + place2;
        }

    }
}
