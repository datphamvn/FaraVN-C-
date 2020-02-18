using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrolyaoFara
{
    public class LoadData
    {
        public string loginimg = Environment.CurrentDirectory + "/" + "logouser.png";
        public string countryname = Environment.CurrentDirectory + "/" + "world.json";
        public string keyGetLocation = "scbFnhg3VEhNerT0CMe6zZhx79PDqc0VMLFDNjW6gTgdGb0G";
        public string userGetLocation = "pvtd264";
    }

    public class SettingSever
    {
        public string linksever = "https://faravn.herokuapp.com/";
    }

    public class DataConfig
    {
        public string email = "trolyfara@gmail.com";
        public string e_password = "@trolyFaraVN";
    }

    public class LoadUser
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string token { get; set; }
    }

    public class LoadInfo
    {
        public int user { get; set; }
        public string birthday { get; set; }
        public int gender { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string image { get; set; }
    }

    public class DetailUser
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
    }

    public class HealthIdx
    {
        public int height { get; set; }
        public int weight { get; set; }
    }

    public class WorldName
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("iso3")]
        public string Iso3 { get; set; }

        [JsonProperty("iso2")]
        public string Iso2 { get; set; }

        [JsonProperty("phone_code")]
        public string PhoneCode { get; set; }

        [JsonProperty("capital")]
        public string Capital { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("states", NullValueHandling = NullValueHandling.Ignore)]
        public Hashtable States { get; set; }  
    }

    public class GetLocation
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country-code")]
        public string CountryCode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("currency-code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country-code3")]
        public string CountryCode3 { get; set; }
    }

    public class GetIP
    {
        [JsonProperty("ip")]
        public string Ip { get; set; }
    }

    public class FoodComposition
    {
        [JsonProperty("food_id")]
        public int id { get; set; }
        [JsonProperty("food_name")]
        public string food_name { get; set; }
    }

    public class Food
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("Level")]
        public int Level { get; set; }

        [JsonProperty("purpose")]
        public List<int> Purpose { get; set; }

        [JsonProperty("Type")]
        public List<int> Type { get; set; }

        [JsonProperty("Method")]
        public List<int> Method { get; set; }

        [JsonProperty("Calo")]
        public double Calo { get; set; }

        [JsonProperty("image")]
        public string URLimg { get; set; }

        [JsonProperty("timer")]
        public int Timer { get; set; }
    }

    public class CalFood
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("foodname")]
        public long Foodname { get; set; }

        [JsonProperty("composition")]
        public long Composition { get; set; }

        [JsonProperty("amout")]
        public long Amout { get; set; }

        [JsonProperty("unit")]
        public long Unit { get; set; }

        [JsonProperty("main")]
        public bool Main { get; set; }
    }

    public class ContentFood
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

}
