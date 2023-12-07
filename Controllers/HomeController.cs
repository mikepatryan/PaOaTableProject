using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using PaOaTableProject;
using PaOaTableProject.Models;
using System.Data;
using static PaOaTableProject.Models.RolidexModel;
using Newtonsoft.Json.Linq;



namespace PaOaTableProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string jsonStringInput)
        {
            string stringInput;
            List<RolidexModel> items = new List<RolidexModel>();
            Newtonsoft.Json.Linq.JObject jsonInput;
            var rolidexDisplay = new RolidexModel();
            var rolidexCards = new RolidexModel.RolidexCards();

            if (String.IsNullOrWhiteSpace(jsonStringInput))
            {
                using (StreamReader sr = new StreamReader("C:\\Code\\DataDir\\employee_data.json"))
                {
                    string json = sr.ReadToEnd();
                    stringInput = json;
                    var jsonPull = JsonConvert.DeserializeObject(json);
                    jsonInput = (Newtonsoft.Json.Linq.JObject)jsonPull;
                    if (jsonPull != null)
                    {
                        System.Diagnostics.Debug.WriteLine("not null");
                    }
                }
            }
            else
            {
                jsonInput= JObject.Parse(jsonStringInput);
            }


            var val1 = jsonInput.Children();
            var val2 = val1.Children();
            var val3 = val2.Children();
            rolidexDisplay.RolidexCardList = new List<RolidexCard>();

            foreach (var x in val3)
            {
                RolidexCard rc = new RolidexCard();
                //id
                rc._id = x.First.ToString();
                rc._id = x.SelectToken("_id").ToString();
                //name
                rc.name = x.SelectToken("name").ToString();
                //email address
                rc.email = x.SelectToken("email").ToString();
                //street address
                rc.addressStreet = x.SelectToken("address.street").ToString();
                rc.addressTown = x.SelectToken("address.town").ToString();
                rc.addressPostcode = x.SelectToken("address.postode").ToString();

                //pets
                var pets = x.SelectToken("pets").Children();
                foreach (var y in pets)
                {
                    rc.petsAll += y.ToString();
                    rc.petsAll += ", ";
                }
                rc.petsAll = rc.petsAll.Substring(0, rc.petsAll.Length - 2);

                rolidexDisplay.RolidexCardList.Add(rc);

            }
            ViewBag.Message = "Your application description page.";
            rolidexCards.RolidexCardList = rolidexDisplay.RolidexCardList;
            return View(rolidexCards);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}