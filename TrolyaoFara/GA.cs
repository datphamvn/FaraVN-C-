using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrolyaoFara
{
    public class GA
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();

        //Variable Data
        static Random rd = new Random();
        static int nInfo = 6;
        static int nBreakfast = 10;//Update
        static int nOtherFood = 60;//Update

        //Setting Menu
        //static int day = 1; // Nhận từ cài đặt

        //GA Variable
        static double totalFitness = 0.0;

        static int populationSize = 20;
        static int generationSize = 100;
        static double mutationRate = 0.05;
        static double crossoverRate = 0.8;

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

        private void createTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS menu([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, recommend string, date string, breakfast INTEGER NOT NULL, lunch INTEGER NOT NULL, dinner INTEGER NOT NULL)";
            databaseObject.RunSQL(sql);

            if (!lib.CheckExists("menu", "id", 1, ""))
            {
                string strInsert = string.Format("INSERT INTO menu(recommend, date, breakfast, lunch, dinner) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", "", DateTime.Today.ToString("dd/MM/yyyy"), 0, 0, 0);
                databaseObject.RunSQL(strInsert);
            }
        }

        public void GA1Day()
        {
            GetDataFromSetting();

            //Load Database
            List<int[]> Database = new List<int[]>();

            string path = Environment.CurrentDirectory + "/" + "dulieu.dat";
            int[] getdata = new int[nInfo];
            if (System.IO.File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string[] words = sr.ReadToEnd().Split('\n');
                    foreach (string i in words)
                    {
                        if (i == "")
                            break;
                        string[] getline = i.Split(' ');
                        int k = 0;
                        foreach (string d in getline)
                        {
                            int data;
                            if (Int32.TryParse(d, out data))
                            {
                                getdata[k] = data;
                                k++;
                            }
                            else
                                break;
                        }
                        Database.Add(new int[nInfo]);
                        for (int lst = 0; lst < nInfo; lst++)
                            Database[Database.Count() - 1][lst] = getdata[lst];
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }

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

            //Log
            path = Environment.CurrentDirectory + "/" + "log.txt";
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

            //Output

            //Load Database
            List<string> ListFood = new List<string>();

            path = Environment.CurrentDirectory + "/" + "namefood.dat";
            if (System.IO.File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string[] data = sr.ReadToEnd().Split('\n');
                    foreach (string i in data)
                    {
                        ListFood.Add(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }

            DateTime today = DateTime.Today;
            path = Environment.CurrentDirectory + "/" + "menu.dat";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(today.ToString("dd/MM/yyyy") + ";" + Math.Max(lunch, dinner) + ";" + breakfast);
                int k = 0;
                foreach (int i in Generation[populationSize - 1])
                {
                    sw.Write(ListFood[i].Trim() + "|");
                    k++;
                    if (k == breakfast || k == (breakfast + lunch))
                        sw.WriteLine();
                }
                //sw.WriteLine();
            }

            //Save Recommend
            string recommend = "";
            foreach (int i in Generation[populationSize - 1])
            {
                recommend += i + " ";
            }
            createTable();
            string strUdpate = string.Format("UPDATE menu set recommend='{0}', date='{1}', breakfast='{2}', lunch='{3}', dinner='{4}'  where id=1", recommend, DateTime.Today.ToString("dd/MM/yyyy"), breakfast, lunch, dinner);
            databaseObject.RunSQL(strUdpate);
        }

        public void CreateDNA(List<int[]> Generation)
        {
            for (int n = 0; n < populationSize; n++)
            {
                int[] DNA = new int[lengthDNA];
                for (int i = breakfast; i < lengthDNA; i++)
                {
                    DNA[i] = rd.Next(nBreakfast, (nBreakfast + nOtherFood));
                }
                for (int i = 0; i < breakfast; i++)
                {
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

            foreach(var t in FitnessTable)
            {
                totalFitness += t;
            }
        }

        //Hàm mục tiêu
        public double FitnessCal(int[] x, List<int[]> Database)
        {
            // Bữa sáng chuẩn
            int Value_conflict = 0;
            int Idx0, Idx1, Idx2;
            Idx0 = Idx1 = Idx2 = 0;
            for (int i = 0; i < lengthDNA; i++)
            {
                if (i % lengthDNA < breakfast)
                {
                    if (Database[x[i]][4] == 0)
                        Idx0++;
                    else if (Database[x[i]][4] == 1)
                        Idx1++;
                    else
                        Idx2++;
                }
            }
            
            //Console.WriteLine("GT: " + BreakfastId0.ToString() + BreakfastId1.ToString() + BreakfastId2.ToString());
            if (Idx0 == 1 && breakfast <= 2)
                Value_conflict += 0;
            else if (Idx0 == 1 && Idx1 == 1 && Idx2 == 1)
                Value_conflict += 0;
            else
                Value_conflict = Value_conflict + (Idx0 * 1 + Idx1 * 2 + Idx2 * 3 + 1);


            // Bữa trưa có canh rau thịt
            Idx0 = Idx1 = Idx2 = 0;
            for (int i = 0; i < lengthDNA; i++)
            {
                if (i % lengthDNA >= breakfast && i % lengthDNA < (breakfast + lunch))
                {
                    if (Database[x[i]][4] == 0)
                        Idx0++;
                    else if (Database[x[i]][4] == 1)
                        Idx1++;
                    else
                        Idx2++;
                }
            }
            if (Idx0 >= 1 && Idx1 >= 1 && Idx2 >= 1)
                Value_conflict += 0;
            else
                Value_conflict = Value_conflict + (Idx0 * 1 + Idx1 * 2 + Idx2 * 3 + 1);

            // Bữa tối có canh rau thịt
            Idx0 = Idx1 = Idx2 = 0;
            for (int i = 0; i < lengthDNA; i++)
            {
                if (i % lengthDNA >= (breakfast + lunch) && i % lengthDNA < lengthDNA)
                {
                    if (Database[x[i]][4] == 0)
                        Idx0++;
                    else if (Database[x[i]][4] == 1)
                        Idx1++;
                    else
                        Idx2++;
                }
            }
            if (Idx0 >= 1 && Idx1 >= 1 && Idx2 >= 1)
                Value_conflict += 0;
            else
                Value_conflict = Value_conflict + (Idx0 * 1 + Idx1 * 2 + Idx2 * 3 + 1);

            // SelectionSort(x, 0, breakfast - 1, Database);
            // SelectionSort(x, breakfast, lengthDNA - 1, Database);


            // Bữa trưa có cách chế biến phù hợp
            int[] Method = new int[lengthDNA];
            int k = 0;
            for (int i = 0; i < lengthDNA; i++)
            {
                if ((i % lengthDNA >= breakfast) && (i % lengthDNA < (breakfast + lunch)))
                {
                    Method[k] = Database[x[i]][5];
                    k++;
                }
            }

            // Sắp xếp
            for (int i = 0; i < lengthDNA - 1; i++)
            {
                for (int j = i + 1; j < lengthDNA; j++)
                {
                    if (Method[i] < Method[j])
                    {
                        int temp = Method[i];
                        Method[i] = Method[j];
                        Method[j] = temp;
                    }
                }
            }

            int c_method = 1;
            for (int i = 0; i < k - 1; i++)
            {
                if (Method[i] != Method[i + 1])
                    c_method++;
            }
            if (c_method >= lunch / 2)
                Value_conflict += 0;
            else
                Value_conflict += 1;


            // Bữa tối có cách chế biến phù hợp
            Array.Clear(Method, 0, Method.Length);
            k = 0;
            for (int i = 0; i < lengthDNA; i++)
            {
                if (i % lengthDNA >= (breakfast + lunch) && i % lengthDNA < lengthDNA)
                {
                    Method[k++] = Database[x[i]][5];
                }
            }

            for (int i = 0; i < lengthDNA - 1; i++)
            {
                for (int j = i + 1; j < lengthDNA; j++)
                {
                    if (Method[i] < Method[j])
                    {
                        int temp = Method[i];
                        Method[i] = Method[j];
                        Method[j] = temp;
                    }
                }
            }

            c_method = 1;
            for (int i = 0; i < k - 1; i++)
            {
                if (Method[i] != Method[i + 1])
                    c_method++;
            }
            if (c_method >= lunch / 2)
                Value_conflict += 0;
            else
                Value_conflict += 1;



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
                if (rd.NextDouble() < mutationRate)
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
    }
}
