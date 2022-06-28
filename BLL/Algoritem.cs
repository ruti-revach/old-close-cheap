using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DAL;
 

namespace BLL
{
    public class Algoritem
    {
        //static string BuildUrlForLocationId(string address)
        //{
        //    string location = "";
        //    string[] locationAsArray;
        //    locationAsArray = address.Split(' ');

        //    for (int i = 0; i < locationAsArray.Length; i++)
        //    {
        //        if (i < locationAsArray.Length - 1)
        //            location += locationAsArray[i] + "+";
        //        else
        //            location += locationAsArray[i];
        //    }
        //    return "https://maps.googleapis.com/maps/api/place/textsearch/json?key=AIzaSyDLx4T9acALeR_MVxsAquIsm9bzLjjhZ7c&query="
        //     + location;
        //}
        //static string BuildUrlForDistance(string place1, string place2)
        //{
        //    string url = "https://maps.googleapis.com/maps/api/distancematrix/json?key=<AIzaSyDLx4T9acALeR_MVxsAquIsm9bzLjjhZ7c>&units=imperial&origins=";
        //    return url + "place_id:" + place1 + "&destinations=place_id:" + place2;
        //}

        // בנסיעה מרחק בדקות 
        public double DistanceInMinutes(string fPoint, string sPoint)
        {
            string uri = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins="
                          + fPoint + " &destinations=" + sPoint + " &mode=driving&units=imperial&sensor=false&key=" + Dijkstra.key + "AIzaSyDEPtSp3Za3ekttM_2ueZyiqoSCCO-9BUc";
            WebClient wc = new WebClient();
            try
            {
                string geoCodeInfo = wc.DownloadString(uri);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(geoCodeInfo);

                string duration = xmlDoc.DocumentElement.SelectSingleNode("//DistanceMatrixResponse/row/element/duration/value").InnerText;
                return (Convert.ToDouble(duration) / 60);//.ToString();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("error on DistanceInMinutes:" + ex.Message);
            }
            //return TravelingTime
             
        }
    }
}