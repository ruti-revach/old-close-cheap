using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DAL;
//using GoogleMaps.LocationServices;
/*using Models;*/
using static System.Net.WebRequestMethods;
using System.Windows.Shapes;
using System.Net;
using System.Xml;
using System.Windows.Documents;
using System.Collections;
using GoogleMaps.LocationServices;

// "AIzaSyDEPtSp3Za3ekttM_2ueZyiqoSCCO-9BUc";
//המפתח של איי פי איי של גוגל מפס
//https://maps.googleapis.com/maps/api/place/textsearch/json?key=AIzaSyDEPtSp3Za3ekttM_2ueZyiqoSCCO-9BUc="
//KEY FOR API GOOGLE MAPS
namespace BLL
{

    public class Dijkstra
    {
        internal static string key = "AIzaSyDEPtSp3Za3ekttM_2ueZyiqoSCCO-9BUc";
        //CloseAndCheapEntities DB = new CloseAndCheapEntities();
        //מספור החנויות
        int numOfPlace;
        int numOfKilometer;//כמה קילומטרים
        int numOfShop;//מס חנויות
        int cityUser;//
                     //public List<node> newList = new List<node>();



        private int numOfKilometers;
        private static object idLocations;
        private int idLocation;

        List<string> storesCategories = new List<string>();
        List<string> store = new List<string>();
        //UserDAL U = new UserDAL();
        businessOwnerDAL S = new businessOwnerDAL();
        businessOwnerDAL adress;
        //List<businessOwner> path;
        //private static node node;
        Algoritem alg = new Algoritem();
         
       
            //פונקציה שמוצאת בעלי עסק קרובים למיקום המשתמש

            public static List<string> findBusinessOners(string location, string kategory)
        {
            //List<string> listToRet = new List<string>();
            //{המרת שם של עיר לקואורדינאטות
            var locationService = new GoogleLocationService("AIzaSyDEPtSp3Za3ekttM_2ueZyiqoSCCO-9BUc");// הכנסת המפתח לאיפיאי של גוגל מפס
            var point = locationService.GetLatLongFromAddress(location);
            var latitude = point.Latitude;//קו הרוחב
            var longitude = point.Longitude;//קו האורך
                                            //}המרת שם של עיר לקואורדינאטות


            string url = "https://maps.googleapis.com/maps/api/place/textsearch/xml?query=" + kategory + "&location=" + latitude + "," + longitude + "&radius=2000&region=il&key=AIzaSyDEPtSp3Za3ekttM_2ueZyiqoSCCO-9BUc";
            //הקישור לחיפוש בעלי העסקים, בתוספת שם עצם אותו אני מחפשת מיקום (קווי אורך ורוחב) ומפתח לאיפיאי
            List<string> allNames = new List<string>();
            WebClient wc = new WebClient();
            try
            {
                string geoCodeInfo = wc.DownloadString(url);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(geoCodeInfo);
                //XmlNodeList urlsNodes = xmlDoc.GetElementsByTagName("html_attribution");
                XmlNodeList namesNode = xmlDoc.GetElementsByTagName("name");
                // List<string> allUrls = new List<string>();
               
                foreach (XmlNode item in namesNode)
                {
                    string myName = item.InnerText;
                    allNames.Add(myName);
                }

                return allNames;
            }
            catch (Exception)
            {
                return allNames;
            }
        }

        //יצירת מסלול
        public List<string> GetMaslul(string location, List<string> storesCategories)
        {
            List<string> maslulToReturn = new List<string>();
            maslulToReturn.Add(location);

            foreach (var storeCategory in storesCategories)
            {
                List<string> storePointersList = findBusinessOners(location, storeCategory);
                string locationNearestStore = GetNearestStore(location, storePointersList);
                maslulToReturn.Add(locationNearestStore);
                location = locationNearestStore;
            }

            return maslulToReturn;
        }

        //יצירת מסלול
        //הכנסת האיבר הראשון
        public string GetNearestStore(string startingPoint, List<string> storesPointers)
        {
            try
            {
                double minDistance = 0;
                string pointerOfNearestStore = null;

                foreach (var storesPointer in storesPointers)
                {
                    double internalDistance = alg.DistanceInMinutes(startingPoint, storesPointer);
                    if (minDistance == 0 || internalDistance < minDistance)
                    {
                        minDistance = internalDistance;
                        pointerOfNearestStore = storesPointer;
                    }

                }

                return pointerOfNearestStore;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //    //הנקודה הבאה
        //    //public (businessOwner, int) NextDestination(int userId, List<businessOwner> stores)
        //    //{

        //    //    user user = U.GetUserById(userId);
        //    //    SortedList<string, businessOwner> dic = new SortedList<string, businessOwner>();
        //    //    string FullAdressOrigin = (string)user.adressUser;
        //    //    foreach (var S in stores)
        //    //    {
        //    //        var shope = U.GetUserById(S.shop_id);
        //    //        string FullAdressProduct = (string)U.adressUser;
        //    //        //  bu[alg.DistanceInMinutes(FullAdressOrigin, FullAdressProduct).Result] = DAL.convertDAL.TripConvert.ConvertTripToEF(S);
        //    //    }
        //    //    return (bu.First().Value, int.Parse(dic.First().Key.Split(' ', '.')[0]));
        //    //}

        //    // נקודה אחרונה
        //   /* public int GetLastNode(int userId, int shop_id)
        //    {
        //        try
        //        {
        //            user user = U.GetUserById(userId);
        //            string FullAdressUser = user.adressUser;
        //            var shope = U.GetUserById(int.Parse(S.getNameShopById(shop_id).ToString()));//////
        //            string FullAdressTrip = shope.adressUser;

        //            return int.Parse(alg.DistanceInMinutes(FullAdressUser, FullAdressTrip));
        //        }
        //        catch (Exception)
        //        {
        //            return -1;
        //        }

        //    }*/

        //    //הכנסת הצומת שנסרקה לרשימה  
        //    //public List<node> InsertNode(List<node> citiesList, bool setNode)
        //    //{
        //    //    List<node> numList = new List<node>();
        //    //    List<node> destination = node.GetFirstNode();
        //    //    if (setNode == true)
        //    //        citiesList.Add(new node());
        //    //    citiesList.Add((node)node.getNode);
        //    //    return citiesList;
        //    //}

    }
}


































