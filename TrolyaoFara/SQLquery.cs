using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrolyaoFara
{
    class SQLquery
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();

        public int countRow(string sql)
        {
            databaseObject.OpenConnection();
            SQLiteCommand cmd = new SQLiteCommand(sql, databaseObject.myConnection);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count;
        }

        public void SQLforSettingsMenu(int breakfast, int lunch, int dinner, int mode, int level, int protein, int lipid, int carb, int p_breakfast, int p_lunch, int p_dinner, int mod)
        {
            if (lib.CheckExists("settings", "id", 1, ""))
            {
                string strUdpate = string.Format("UPDATE settings set breakfast='{0}', lunch='{1}', dinner='{2}', mode='{3}', level='{4}', protein='{5}', lipid='{6}', carb='{7}', p_breakfast='{8}', p_lunch='{9}', p_dinner='{10}', mod='{11}' where id=1", breakfast, lunch, dinner, mode, level, protein, lipid, carb, p_breakfast, p_lunch, p_dinner, mod);
                databaseObject.RunSQL(strUdpate);
            }
            else
            {
                string strInsert = string.Format("INSERT INTO settings(breakfast, lunch, dinner, mode, level, protein, lipid, carb, p_breakfast, p_lunch, p_dinner, mod) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')", breakfast, lunch, dinner, mode, level, protein, lipid, carb, p_breakfast, p_lunch, p_dinner, mod);
                databaseObject.RunSQL(strInsert);
            }
        }

        public void SQLforMemberFamily(string strId, string username, bool hide)
        {
            if (lib.CheckExists("family_member", "id_member", -1, strId))
            {
                string strUdpate = string.Format("UPDATE family_member set hide='{0}' where id_member='{1}'", hide, strId);
                databaseObject.RunSQL(strUdpate);
            }
            else
            {
                string strInsert = string.Format("INSERT INTO family_member(id_member, username, hide) VALUES('{0}','{1}','{2}')", strId, username, hide);
                databaseObject.RunSQL(strInsert);
            }
        }
      
        public void SQLforMenuTable(int numBreakfast, int numLunch, int numDinner, int calo, int protein, int lipid, int carb, int mod)
        {
            string today = DateTime.Today.ToString("dd/MM/yyyy");
            if (lib.CheckExists("menu", "date", -1, today))
            { 
                string strUdpate = string.Format("UPDATE menu set breakfast='{0}', lunch='{1}', dinner='{2}', calo='{3}', protein='{4}', lipid='{5}', carb='{6}', mod='{7}' where date='{8}'", numBreakfast, numLunch, numDinner, calo, protein, lipid, carb, mod, today); ;
                databaseObject.RunSQL(strUdpate);
            }
            else
            {
                string strInsert = string.Format("INSERT INTO menu(recommend, cal_menu, date, breakfast, lunch, dinner, calo, protein, lipid, carb, mod) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", "", "", today, numBreakfast, numLunch, numDinner, calo, protein, lipid, carb, mod);
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

        public void SQLforInfoTable(string lname, string fname, int gender, string birthday, string district, string city, string country, int height, int weight, int neck, int waist, int hip, int intensity, long iduser)
        {
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
            string sql = "CREATE TABLE IF NOT EXISTS menu([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, recommend STRING, cal_menu STRING, date STRING, breakfast INTEGER, lunch INTEGER, dinner INTEGER, calo INTEGER, protein INTEGER, lipid INTEGER, carb INTEGER, mod INTEGER)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS account ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, username varchar NULL UNIQUE, email varchar NULL UNIQUE, password varchar NOT NULL, iduser INTEGER, login bool)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS info ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, iduser INTEGER, lname varchar, fname varchar, gender INTEGER, birthday varchar, district varchar, city varchar, country varchar, height INTEGER, weight INTEGER, neck INTEGER, waist INTEGER, hip INTEGER, intensity INTEGER)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS allergic([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, composition_id INTEGER, name_composition varchar, stt bool)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS favorite([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, food_id INTEGER, name_food varchar, stt bool)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS ratings([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, food_id INTEGER, rate integer NOT NULL, stt bool)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS food_db([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, id_food INTEGER, id_purpose INTEGER, id_type INTEGER, id_method INTEGER, calo INTEGER, name varchar, timer INTEGER)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS calforfood([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, id_food INTEGER, id_composition INTEGER, amout FLOAT, unit INTEGER, main BOOL)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS family_member([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, id_member STRING, username STRING, hide BOOL)";
            databaseObject.RunSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS settings([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, breakfast INTEGER, lunch INTEGER, dinner INTEGER, mode INTEGER, level INTEGER, protein INTEGER, lipid INTEGER, carb INTEGER, p_breakfast INTEGER, p_lunch INTEGER, p_dinner INTEGER, mod INTEGER)";
            databaseObject.RunSQL(sql);
        }
    }
}
