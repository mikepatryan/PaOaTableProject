using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace PaOaTableProject.Models
{
    public class RolidexModel
    {
        public DataTable RolidexDataTable { get; set; }
        public List<RolidexCard> RolidexCardList { get; set; }

        public class RolidexCards
        {
            public List<RolidexCard> RolidexCardList { get; set; }
        }

        public class Address
        {
            public string street { get; set; }
            public string town { get; set; }
            public string postode { get; set; }
        }

        public class RolidexCard
        {
            public string _id { get; set; }
            public string name { get; set; }
            public string dob { get; set; }
            public Address address { get; set; }
            public string addressStreet { get; set; }
            public string addressPostcode { get; set; }
            public string addressTown { get; set; }
            public string telephone { get; set; }
            public List<string> pets { get; set; }
            public string petsAll { get; set; }
            public double score { get; set; }
            public string email { get; set; }
            public string url { get; set; }
            public string description { get; set; }
            public bool verified { get; set; }
            public int salary { get; set; }
        }
    }
}