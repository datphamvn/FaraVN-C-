using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace TrolyaoFara
{
    public class GAVer2
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();

        //Variable Data
        static Random rd = new Random();
        static int nInfo = 4;
        static int nBreakfast = 10;//Update 10
        static int nOtherFood = 60;//Update 60

        //Setting Menu
        //static int day = 1; // Nhận từ cài đặt

        //GA Variable
        static double totalFitness = 0.0;

        static int populationSize = 80;
        static int generationSize = 200;
        static double mutationRate = 0.15;
        static double crossoverRate = 0.8;

        const int nArrMenu = 21;
        int breakfast = 0, lunch = 0, dinner = 0, lengthDNA = 0;

        public void GetDataFromSetting()
        {
            string sql = string.Format("SELECT * FROM settings WHERE id=1");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                breakfast = Convert.ToInt32(rd["breakfast"]);
                lunch = Convert.ToInt32(rd["lunch"]);
                dinner = Convert.ToInt32(rd["dinner"]);
            }
            command.Dispose();
            databaseObject.CloseConnection();

            lengthDNA = breakfast + lunch + dinner;
        }

        public void MainGA()
        {
            GetDataFromSetting();

            //Load Database
            List<int[]> Database = new List<int[]>();

            int[] getdata = new int[nInfo];
            string sql = string.Format("SELECT * FROM food_db");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                getdata[0] = Convert.ToInt32(rd["id_food"]);
                getdata[1] = Convert.ToInt32(rd["id_purpose"]);
                getdata[2] = Convert.ToInt32(rd["id_type"]);
                getdata[3] = Convert.ToInt32(rd["id_method"]);
                Database.Add(new int[nInfo]);
                for (int lst = 0; lst < nInfo; lst++)
                    Database[Database.Count() - 1][lst] = getdata[lst];
            }
            command.Dispose();
            databaseObject.CloseConnection();
            //alert.Show("Load Data Success !", alert.AlertType.success);

            List<int[]> Generation = new List<int[]>();
            List<int[]> Generation2 = new List<int[]>();
            List<double> FitnessTable = new List<double>();

            CreateDNA(Generation);
            RankPopulation(Generation, FitnessTable, Database);

            for (int i = 0; i < generationSize; i++)
            {
                if (FitnessTable[populationSize - 1] == 1)
                    break;
                CreateNextGeneration(Generation, Generation2, FitnessTable);
                RankPopulation(Generation, FitnessTable, Database);
            }

            Log(FitnessTable, Generation); // Dev mode
            //Save Recommend
            string recommend = "";
            foreach (int i in Generation[populationSize - 1])
            {
                recommend += i + " ";
            }
            string strUdpate = string.Format("UPDATE menu set recommend='{0}', date='{1}', breakfast='{2}', lunch='{3}', dinner='{4}'  where id=1", recommend, DateTime.Today.ToString("dd/MM/yyyy"), breakfast, lunch, dinner);
            databaseObject.RunSQL(strUdpate);
        }

        int[] temp_menu = new int[nArrMenu];
        public void GetTempMenu()
        {
            /*
            string sql = string.Format("SELECT * FROM menu WHERE id=1");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                temp_menu = rd["recommend"].ToString().Split(' ');
            }
            command.Dispose();
            databaseObject.CloseConnection();
            */
            for(int i=0; i<breakfast+lunch+dinner; i++)
            {
                temp_menu[i] = 0;
            }
        }

        public void CreateDNA(List<int[]> Generation)
        {
            /*
            try
            {
                GetTempMenu();
                //GetAntiComposition();
            }
            catch (Exception)
            {
                CreateTable();
                GetTempMenu();
            }
            */

            for (int n = 0; n < populationSize; n++)
            {
                int[] DNA = new int[lengthDNA];
                /*
                for (int i = 0; i < lengthDNA; i++)
                {
                        DNA[i] = temp_menu[i];
                }
                */

                for (int i = breakfast; i < lengthDNA; i++)
                {
                   // if(DNA[i] >= 0)
                        DNA[i] = rd.Next(nBreakfast, (nBreakfast + nOtherFood));
                }
                for (int i = 0; i < breakfast; i++)
                {
                   // if(DNA[i] >= 0)
                        DNA[i] = rd.Next(0, nBreakfast);
                }
                AddDNA(Generation, DNA);
            }
        }

        public void AddDNA(List<int[]> Generation, int[] DNA)
        {
            Generation.Add(new int[lengthDNA]);
            for (int lst = 0; lst < lengthDNA; lst++)
                Generation[Generation.Count() - 1][lst] = DNA[lst];
        }

        public void RankPopulation(List<int[]> Generation, List<double> FitnessTable, List<int[]> Database)
        {
            // Sắp xếp lại DNA theo thứ tự tăng dần của Fitness
            Generation.Sort(delegate (int[] x, int[] y)
            { return Comparer<double>.Default.Compare(FitnessCal(x, Database), FitnessCal(y, Database)); });

            FitnessTable.Clear();
            foreach (var t in Generation)
            {
                FitnessTable.Add(FitnessCal(t, Database));
            }

            foreach (var t in FitnessTable)
            {
                totalFitness += t;
            }
        }

        private int FinessTypeOfFood(List<int[]> Database, int[] x, int idxBegin, int idxEnd, int idType1, int idType2, int idxCheck)
        {
            int Idx0, Idx1, Idx2;
            Idx0 = Idx1 = Idx2 = 0;
            for (int i = idxBegin; i < idxEnd; i++)
            {
                int index = Math.Abs(x[i]);
                if (Database[index][2] == idType1)
                    Idx0++;
                else if (Database[index][2] == idType2)
                    Idx1++;
                else
                    Idx2++;
            }
            if(idxCheck == 1)
            {
                if ((Idx0 == 1 && breakfast <= 2) || (Idx0 == 1 && Idx1 == 1 && Idx2 == 1))
                    return 0;
            }
            else
            {
                if (Idx0 >= 1 && Idx1 >= 1 && Idx2 >= 1)
                    return 0;
            }
            return Idx0 * 1 + Idx1 * 2 + Idx2 * 3 + 1;
        }

        private int FinessMethodOfFood(List<int[]> Database, int[] x, int idxBegin, int idxEnd, int nFood)
        {
            int[] Method = new int[lengthDNA];
            Array.Clear(Method, 0, Method.Length);
            int k = 0;
            for (int i = idxBegin; i < idxEnd; i++)
            {
                int index = Math.Abs(x[i]);
                Method[k] = Database[index][3];
                k++;
            }
            
            Array.Sort(Method);

            int c_method = 1;
            for (int i = 0; i < k - 1; i++)
            {
                if (Method[i] != Method[i + 1])
                    c_method++;
            }
            if (c_method - 1 >= nFood / 2)
                return 0;
            return nFood / 2 - c_method + 1;
        }

        // cột 0 -> ID món ăn
        // cột 1 -> purpose (mục đích) sáng/trưa/tối
        // cột 2 -> Type (Phân loại món ăn)
        // cột 3 -> Phương pháp chế biến (method)

        //Hàm mục tiêu
        public double FitnessCal(int[] x, List<int[]> Database)
        {
            int Value_conflict = 0;
            int idxBegin, idxEnd;

            // Bữa sáng chuẩn
            idxBegin = 0;
            idxEnd = breakfast;
            Value_conflict += FinessTypeOfFood(Database, x, idxBegin, idxEnd, 10 ,12, 1); // idxCheck = 1 (Bữa sáng)

            // Bữa trưa có canh rau thịt
            idxBegin = breakfast;
            idxEnd = breakfast + lunch;
            Value_conflict += FinessTypeOfFood(Database, x, idxBegin, idxEnd, 1, 2, 2);

            // Bữa tối có canh rau thịt
            idxBegin = breakfast + lunch;
            idxEnd = lengthDNA;
            Value_conflict += FinessTypeOfFood(Database, x, idxBegin, idxEnd, 1, 2, 2);

            // Bữa trưa có cách chế biến phù hợp
            idxBegin = breakfast;
            idxEnd = breakfast + lunch;
            Value_conflict += FinessMethodOfFood(Database, x, idxBegin, idxEnd, lunch);

            // Bữa tối có cách chế biến phù hợp
            idxBegin = breakfast + lunch;
            idxEnd = lengthDNA;
            Value_conflict += FinessMethodOfFood(Database, x, idxBegin, idxEnd, dinner);

            return (1.0 / (Value_conflict + 1));
        }

        public void CopyArray(int[] arrCopy, int[] arrPaste)
        {
            for (int i = 0; i < lengthDNA; i++)
                arrPaste[i] = arrCopy[i];
        }

        public void Crossover(int[] parent1, int[] parent2, int[] child1, int[] child2)
        {
            int pos = rd.Next(0, lengthDNA);

            for (int i = 0; i < lengthDNA; i++)
            {
                if (i < pos)
                {
                    child1[i] = parent1[i];
                    child2[i] = parent2[i];
                }
                else
                {
                    child1[i] = parent2[i];
                    child2[i] = parent1[i];
                }
            }
        }

        public void Mutate(int[] DNA)
        {
            for (int pos = 0; pos < lengthDNA; pos++)
            {
                if (rd.NextDouble() < mutationRate && DNA[pos] >= 0)
                {
                    if (pos % lengthDNA < breakfast)
                    {
                        DNA[pos] = rd.Next(0, nBreakfast);
                    }
                    else
                    {
                        DNA[pos] = rd.Next(nBreakfast, (nBreakfast + nOtherFood));
                    }
                }
            }
        }

        public void CreateNextGeneration(List<int[]> Generation, List<int[]> Generation2, List<double> FitnessTable)
        {
            Generation2.Clear();

            int[] bestDNA = new int[lengthDNA];
            CopyArray(Generation[populationSize - 1], bestDNA);

            for (int i = 0; i < populationSize; i += 2)
            {
                int pidx1 = RouletteSelection(FitnessTable);
                int pidx2 = RouletteSelection(FitnessTable);

                int[] child1 = new int[lengthDNA];
                int[] child2 = new int[lengthDNA];
                int[] parent1 = new int[lengthDNA];
                int[] parent2 = new int[lengthDNA];

                parent1 = Generation[pidx1];
                parent2 = Generation[pidx2];

                if (rd.NextDouble() < crossoverRate)
                {
                    Crossover(parent1, parent2, child1, child2);
                }
                else
                {
                    CopyArray(parent1, child1);
                    CopyArray(parent2, child2);
                }
                Mutate(child1);
                Mutate(child2);

                AddDNA(Generation2, child1);
                AddDNA(Generation2, child2);
            }

            Generation2[0] = bestDNA;

            Generation.Clear();
            foreach (var dna in Generation2)
                AddDNA(Generation, dna);
        }

        static int RouletteSelection(List<double> FitnessTable)// chọn lọc sử dụng vòng quay bánh xe.
        {
            double randomFitness = rd.NextDouble() * totalFitness;
            //Console.WriteLine("Random: " + randomFitness);
            int idx = -1;
            int mid;
            int first = 0;
            int last = populationSize - 1;
            mid = (last - first) / 2;

            //Tìm kiếm nhị phân
            while (idx == -1 && first <= last)
            {
                if (randomFitness < FitnessTable[mid])
                {
                    last = mid;
                }
                else if (randomFitness > FitnessTable[mid])
                {
                    first = mid;
                }
                mid = (first + last) / 2;

                if ((last - first) == 1)
                    idx = last;
            }
            return idx;
        }

        private void Log(List<double> FitnessTable, List<int[]> Generation)
        {
            string path = Environment.CurrentDirectory + "/" + "log.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine();
                foreach (var k in FitnessTable)
                {
                    sw.WriteLine(k);
                }

                int a = RouletteSelection(FitnessTable);
                sw.WriteLine(a);
                foreach (int i in Generation[populationSize - 1])
                {
                    sw.Write(i + " ");
                }
                sw.WriteLine();
                foreach (int i in Generation[populationSize - 2])
                {
                    sw.Write(i + " ");
                }
                sw.WriteLine();
            }
        }
    }
}
