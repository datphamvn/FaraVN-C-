using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace TrolyaoFara
{
    class GACal
    {
        Database databaseObject = new Database();
        LibFunction lib = new LibFunction();

        static string strmenu = "";
        static int GoalCalo = 0;
        static int breakfast = 0, lunch = 0, dinner = 0;
        static int lengthDNA = 0, nInfo = 2;

        //static int[] input = { 4, 46, 33, 17, 34, 25, 14, 16, 46 };
        static int[] tile = { 15, 45, 40 };
        //static double hesochia = 10.0;

        //Variable Data
        static Random rd = new Random();

        //Setting Menu
        //static int day = 1;

        //GA Variable
        static double totalFitness = 0.0;
        static int hscanbang = 10;

        static int populationSize = 50;
        static int generationSize = 200;
        static double mutationRate = 0.1;
        static double crossoverRate = 0.8;

        static double RandomHS()
        {
            double hs = 0;
            while (hs<=0 || hs>5)
            {
                hs = rd.Next(1, hscanbang + 1) * rd.NextDouble();
            }
            return hs;
        }

        public void RunGACal()
        {
            string sql = string.Format("SELECT * FROM menu WHERE id=1");
            databaseObject.OpenConnection();
            SQLiteCommand command = new SQLiteCommand(sql, databaseObject.myConnection);
            SQLiteDataReader rd = command.ExecuteReader();
            while (rd.Read())
            {
                strmenu = rd["recommend"].ToString();
                breakfast = Convert.ToInt32(rd["breakfast"]);
                lunch = Convert.ToInt32(rd["lunch"]);
                dinner = Convert.ToInt32(rd["dinner"]);
                GoalCalo = Convert.ToInt32(rd["calo"]);
            }
            command.Dispose();
            databaseObject.CloseConnection();
            lengthDNA = breakfast + lunch + dinner;

            //Load Database
            List<int[]> Database = new List<int[]>();

            int[] getdata = new int[nInfo];
            sql = string.Format("SELECT * FROM db_food");
            databaseObject.OpenConnection();
            command = new SQLiteCommand(sql, databaseObject.myConnection);
            rd = command.ExecuteReader();
            while (rd.Read())
            {
                getdata[0] = Convert.ToInt32(rd["id_food"]);
                getdata[1] = Convert.ToInt32(rd["calo"]);
                Database.Add(new int[nInfo]);
                for (int lst = 0; lst < nInfo; lst++)
                    Database[Database.Count() - 1][lst] = getdata[lst];
            }
            command.Dispose();
            databaseObject.CloseConnection();
            alert.Show("Load Data Success !", alert.AlertType.success);

            //int[] idmenu = strmenu.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] idmenu = { 5, 18, 20, 31, 29, 44, 45, 51, 55 };
            List<double[]> Generation = new List<double[]>();
            List<double[]> Generation2 = new List<double[]>();
            List<double> FitnessTable = new List<double>();

            CreateDNA(Generation);
            RankPopulation(Generation, FitnessTable, Database, idmenu);

            for (int i = 0; i < generationSize; i++)
            {
                if (FitnessTable[populationSize - 1] == 1)
                    break;
                CreateNextGeneration(Generation, Generation2, FitnessTable);
                RankPopulation(Generation, FitnessTable, Database, idmenu);
            }


            #region Log
            string path = Environment.CurrentDirectory + "/" + "log1.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine();
                foreach (var k in FitnessTable)
                {
                    sw.WriteLine(k);
                }

                int a = RouletteSelection(FitnessTable);
                sw.WriteLine(a);
                foreach (double i in Generation[populationSize - 1])
                {
                    sw.WriteLine(i);
                }
                sw.WriteLine();
            }
            #endregion

            //Output
            string recommend = "";
            foreach (int i in Generation[populationSize - 1])
            {
                recommend += i + " ";
            }

            if (!lib.CheckExists("menu", "id", 2, ""))
            {
                string strInsert = string.Format("INSERT INTO menu(recommend, date, breakfast, lunch, dinner, calo) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", "", DateTime.Today.ToString("dd/MM/yyyy"), 0, 0, 0, 0);
                databaseObject.RunSQL(strInsert);
            }
            else
            {
                string strUdpate = string.Format("UPDATE menu set recommend='{0}', date='{1}', breakfast='{2}', lunch='{3}', dinner='{4}'  where id=2", recommend, DateTime.Today.ToString("dd/MM/yyyy"), breakfast, lunch, dinner);
                databaseObject.RunSQL(strUdpate);
            }

        }

        static void CreateDNA(List<double[]> Generation)
        {
            for (int n = 0; n < populationSize; n++)
            {
                double[] DNA = new double[lengthDNA];
                for (int k = 0; k < lengthDNA; k++)
                {
                    DNA[k] = RandomHS();
                    //DNA[k] = rd.Next(1, hscanbang+1) * rd.NextDouble();
                }
                AddDNA(Generation, DNA);
            }
        }

        static void AddDNA(List<double[]> Generation, double[] DNA)
        {
            Generation.Add(new double[lengthDNA]);
            for (int lst = 0; lst < lengthDNA; lst++)
                Generation[Generation.Count() - 1][lst] = DNA[lst];
        }

        static void RankPopulation(List<double[]> Generation, List<double> FitnessTable, List<int[]> Database, int[] input)
        {
            // Sắp xếp lại DNA theo thứ tự tăng dần của Fitness
            Generation.Sort(delegate (double[] x, double[] y)
            { return Comparer<double>.Default.Compare(FitnessCal(x, Database, input), FitnessCal(y, Database, input)); });

            FitnessTable.Clear();
            foreach (var t in Generation)
            {
                FitnessTable.Add(FitnessCal(t, Database, input));
            }

            foreach (var t in FitnessTable)
            {
                totalFitness += t;
            }
        }

        //Hàm mục tiêu
        static double FitnessCal(double[] x, List<int[]> Database, int[] input)
        {
            int Value_conflict = 0;


            double sumCalo = 0;
            // Hệ số có tổng Calo phù hợp
            for (int i = 0; i < lengthDNA; i++)
            {
                int idx = input[i] - 1;
                sumCalo += Database[idx][1] * x[i];
            }
            if (Math.Abs(sumCalo - GoalCalo) <= 10)
                Value_conflict += 0;
            else
                Value_conflict += Convert.ToInt32(Math.Abs(sumCalo - GoalCalo));


            //He so can bang 3 bua
            int PartCalo = GoalCalo * tile[0] / 100;
            sumCalo = 0;
            for(int i=0; i<breakfast; i++)
            {
                int idx = input[i] - 1;
                sumCalo += Database[idx][1] * x[i];
            }
            if (Math.Abs(sumCalo-PartCalo) <= 10)
                Value_conflict += 0;
            else
                Value_conflict += Convert.ToInt32(Math.Abs(sumCalo - PartCalo));

            // Trưa
            PartCalo = GoalCalo * tile[1] / 100;
            sumCalo = 0;
            for (int i = breakfast; i < breakfast + lunch; i++)
            {
                int idx = input[i] - 1;
                sumCalo += Database[idx][1] * x[i];
            }
            if (Math.Abs(sumCalo-PartCalo) <= 10)
                Value_conflict += 0;
            else
                Value_conflict += Convert.ToInt32(Math.Abs(sumCalo - PartCalo));
            /*
            //Tối
            PartCalo = GoalCalo * tile[2] / 100;
            sumCalo = 0;
            for (int i = breakfast; i < breakfast + lunch; i++)
            {
                sumCalo += Database[input[i]][1] * x[i];
            }
            if (Math.Abs(sumCalo - PartCalo) <= 10)
                Value_conflict += 0;
            else
                Value_conflict += Convert.ToInt32(Math.Abs(sumCalo - PartCalo));
           */
            return (1.0 / (Value_conflict + 1));
        }

        static void CopyArray(double[] arrCopy, double[] arrPaste)
        {
            for (int i = 0; i < lengthDNA; i++)
                arrPaste[i] = arrCopy[i];
        }

        static void Crossover(double[] parent1, double[] parent2, double[] child1, double[] child2)
        {
            //Random rd = new Random();
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

        static void Mutate(double[] DNA, int lengthDNA)
        {
            //Random rd = new Random();
            for (int pos = 0; pos < lengthDNA; pos++)
            {
                if (rd.NextDouble() < mutationRate)
                {
                    DNA[pos] = RandomHS();
                    //DNA[pos] = rd.Next(1, hscanbang + 1) * rd.NextDouble();
                }
            }
        }

        static void CreateNextGeneration(List<double[]> Generation, List<double[]> Generation2, List<double> FitnessTable)
        {
            Generation2.Clear();

            double[] bestDNA = new double[lengthDNA];
            CopyArray(Generation[populationSize - 1], bestDNA);

            for (int i = 0; i < populationSize; i += 2)
            {
                int pidx1 = RouletteSelection(FitnessTable);
                int pidx2 = RouletteSelection(FitnessTable);

                double[] child1 = new double[lengthDNA];
                double[] child2 = new double[lengthDNA];
                double[] parent1 = new double[lengthDNA];
                double[] parent2 = new double[lengthDNA];

                parent1 = Generation[pidx1];
                parent2 = Generation[pidx2];

                //Random rd = new Random();
                if (rd.NextDouble() < crossoverRate)
                {
                    Crossover(parent1, parent2, child1, child2);
                }
                else
                {
                    CopyArray(parent1, child1);
                    CopyArray(parent2, child2);
                }
                Mutate(child1, lengthDNA);
                Mutate(child2, lengthDNA);

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
            //Random rd = new Random();
            double randomFitness = rd.NextDouble() * totalFitness; //m_random.NextDouble * m_totalFitness;
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
                //  lies between i and i+1
                if ((last - first) == 1)
                    idx = last;
            }
            return idx;
        }
    }
}
