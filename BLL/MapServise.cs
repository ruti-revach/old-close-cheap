using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    //מציאת מרחק בין 2 נקודות
    class MapServise
    {
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

        /*static string BuildUrlForDistance(string place1, string place2)
        {
            string url = "https://maps.googleapis.com/maps/api/distancematrix/json?key=<AIzaSyDLx4T9acALeR_MVxsAquIsm9bzLjjhZ7c>&units=imperial&origins=";
            return url + "place_id:" + place1 + "&destinations=place_id:" + place2;
        }
*/
    }
}
