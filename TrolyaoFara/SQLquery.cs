using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrolyaoFara
{
    class SQLquery
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();

        public void SQLforMenuTable(int numBreakfast, int numLunch, int numDinner)
        {
            if (lib.CheckExists("menu", "id", 1, ""))
            {
                /*
                string strUdpate = string.Format("UPDATE menu set recommend='{0}', date='{1}', breakfast='{2}', lunch='{3}', dinner='{4}', calo='{5}', protein='{6}', lipid='{7}', carb='{8}', main='{9}' where id='{10}'", "", "", 0, 0, 0, 0, 0, 0, 0, 0, true); ;
                databaseObject.RunSQL(strUdpate);
                */
            }
            else
            {
                string strInsert = string.Format("INSERT INTO menu(recommend, date, breakfast, lunch, dinner, calo, protein, lipid, carb, main) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", "", "", numBreakfast, numLunch, numDinner, 0, 0, 0, 0, true);
                databaseObject.RunSQL(strInsert);
            }
        }

        #region frmUpdateInfo
        public void SQLforFavoriteTable(string itemFood, string nameFood)
        {
            if (lib.CheckExists("favorite", "food_id", Convert.ToInt32(itemFood), ""))
            {
                string strUdpate = string.Format("UPDATE favorite set stt='{0}' where food_id='{1}'", true, itemFood);
                databaseObject.RunSQL(strUdpate);
            }
            else
            {
                string strInsert = string.Format("INSERT INTO favorite(food_id, name_food, stt) VALUES('{0}', '{1}', '{2}')", itemFood, nameFood, true);
                databaseObject.RunSQL(strInsert);
            }
        }

        public void SQLforRatingsTable(string itemFoodName, int maxRatings)
        {
            if (lib.CheckExists("ratings", "food_id", Convert.ToInt32(itemFoodName), ""))
            {
                string strUdpate = string.Format("UPDATE ratings set rate='{0}', stt='{1}' where food_id='{2}'", maxRatings, true, itemFoodName);
                databaseObject.RunSQL(strUdpate);
            }
            else
            {
                string strInsert = string.Format("INSERT INTO ratings(food_id, rate, stt) VALUES('{0}', '{1}', '{2}')", itemFoodName, maxRatings, true);
                databaseObject.RunSQL(strInsert);
            }
        }

        public void SQLforAllergicTable(string itemAllergic, string nameAllergic)
        {
            if (lib.CheckExists("allergic", " composition_id", Convert.ToInt32(itemAllergic), ""))
            {
                string strUdpate = string.Format("UPDATE allergic set stt='{0}' where composition_id='{1}'", true, itemAllergic);
                databaseObject.RunSQL(strUdpate);
            }
            else
            {
                string strInsert = string.Format("INSERT INTO allergic(composition_id, name_composition, stt) VALUES('{0}', '{1}', '{2}')", itemAllergic, nameAllergic, true);
                databaseObject.RunSQL(strInsert);
            }
        }

        public void SQLforInfoTable(string lname, string fname, int gender, string birthday, string district, string city, string country, int height, int weight, int neck, int waist, int hip, int intensity)
        {
            int iduser = lib.GetID();
            if (lib.CheckExists("info", "iduser", iduser, ""))
            {
                string strUdpate = string.Format("UPDATE info set lname='{0}', fname='{1}', gender='{2}', birthday='{3}', district='{4}', city='{5}', country='{6}', height='{7}', weight='{8}', neck='{9}', waist='{10}', hip='{11}' where iduser='{12}'", lname, fname, gender, birthday, district, city, country, height, weight, neck, waist, hip, iduser);
                databaseObject.RunSQL(strUdpate);
            }
            else
            {
                string strInsert = string.Format("INSERT INTO info(iduser, lname, fname, gender, birthday, district, city, country, height, weight, neck, waist, hip, intensity) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')", iduser, lname, fname, gender, birthday, district, city, country, height, weight, neck, waist, hip, intensity, iduser);
                databaseObject.RunSQL(strInsert);
            }
        }
        #endregion

        public void createTableForDatabase()
        {
            //Table Menu
            string sql = "CREATE TABLE IF NOT EXISTS menu([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, recommend STRING, date STRING, breakfast INTEGER, lunch INTEGER, dinner INTEGER, calo INTEGER, protein INTEGER, lipid INTEGER, carb INTEGER, main BOOL)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS account ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, username varchar NULL UNIQUE, email varchar NULL UNIQUE, password varchar NOT NULL, iduser integer, login bool NOT NULL)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS info ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, iduser INTEGER, lname varchar, fname varchar, gender INTEGER, birthday varchar, district varchar, city varchar, country varchar, height INTEGER, weight INTEGER, neck INTEGER, waist INTEGER, hip INTEGER, intensity INTEGER)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS allergic([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, composition_id integer NOT NULL UNIQUE, name_composition varchar, stt bool)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS favorite([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, food_id integer NOT NULL UNIQUE, name_food varchar, stt bool)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS ratings([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, food_id integer NOT NULL UNIQUE, rate integer NOT NULL, stt bool)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS food_db([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, id_food INTEGER NOT NULL, id_purpose INTEGER NOT NULL, id_type INTEGER NOT NULL, id_method INTEGER NOT NULL, calo INTEGER NOT NULL, name varchar NOT NULL, timer INTEGER NOT NULL)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS calforfood([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, id_food INTEGER NOT NULL, id_composition INTEGER NOT NULL, amout FLOAT NOT NULL, unit INTEGER NOT NULL, main BOOL NOT NULL)";
            databaseObject.RunSQL(sql);
        }
    }
}
