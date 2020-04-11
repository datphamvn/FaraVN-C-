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
        public string countryname = Environment.CurrentDirectory + "/" + "vn.json";
        public string keyGetLocation = "scbFnhg3VEhNerT0CMe6zZhx79PDqc0VMLFDNjW6gTgdGb0G";
        public string userGetLocation = "pvtd264";
    }

    public class SettingSever
    {
        public string linksever = "http://localhost:8000/";
        public string linkimg = "https://res.cloudinary.com/pvtd264/";
        //public string linksever = "https://faravn.herokuapp.com/";
    }

    public class DataConfig
    {
        public string email = "trolyfara@gmail.com";
        public string e_password = "@trolyFaraVN";
    }

    public class LoadUser
    {
        public long id { get; set; }
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
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
    }

    public class HealthIdx
    {
        public int height { get; set; }
        public int weight { get; set; }
        public int neck { get; set; }
        public int waist { get; set; }
        public int hip { get; set; }
        public int intensity { get; set; }
    }

    public class VietNam
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("districts")]
        public District[] Districts { get; set; }
    }

    public class District
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class FoodComposition
    {
        [JsonProperty("food_id")]
        public long id { get; set; }
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

        [JsonProperty("draft")]
        public bool Draft { get; set; }
    }

    public class CalFood
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("foodname")]
        public long id_Foodname { get; set; }

        [JsonProperty("composition")]
        public long id_Composition { get; set; }

        [JsonProperty("amout")]
        public double Amout { get; set; }

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

    public class Composition
    {
        [JsonProperty("food_id")]
        public long FoodId { get; set; }

        [JsonProperty("food_code")]
        public long FoodCode { get; set; }

        [JsonProperty("food_name")]
        public string FoodName { get; set; }
    }

    public class Unit
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string NameUnit { get; set; }
    }

    public partial class FoodRecommend
    {
        [JsonProperty("user")]
        public long User { get; set; }

        [JsonProperty("items")]
        public long[] Items { get; set; }
    }


}
