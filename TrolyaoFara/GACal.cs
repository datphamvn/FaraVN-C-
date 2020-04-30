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
        SQLquery runSQL = new SQLquery();

        static string strmenu = "";
        static int GoalCalo = 0;
        static int breakfast = 0, lunch = 0, dinner = 0;
        static int lengthDNA = 0;
        int nInfo = 2;

        static int[] tile = {30, 40, 30};
        //static double hesochia = 10.0;

        //Variable Data
        static Random rd = new Random();

        //Setting Menu
        //static int day = 1;

        //GA Variable
        static double totalFitness = 0.0;
        static int hscanbang = 10;
        static int epsilon = 10;

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
            string today = DateTime.Today.ToString("dd/MM/yyyy");
            string sql = string.Format("SELECT * FROM menu WHERE date='{0}'", today);
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
            sql = string.Format("SELECT * FROM food_db");
            databaseObject.OpenConnection();
            command = new SQLiteCommand(sql, databaseObject.myConnection);
            rd = command.ExecuteReader();
            while (rd.Read())
            {
                getdata[0] = Convert.ToInt32(rd["id_food"]);
                getdata[1] = Convert.ToInt32(rd["calo"]);
                // getdata[1] = Convert.ToInt32(rd["protein"]);
                // getdata[1] = Convert.ToInt32(rd["lipid"]);
                // getdata[1] = Convert.ToInt32(rd["carb"]);
                Database.Add(new int[nInfo]);
                for (int lst = 0; lst < nInfo; lst++)
                    Database[Database.Count() - 1][lst] = getdata[lst];
            }
            command.Dispose();
            databaseObject.CloseConnection();
            alert.Show("Load Data Success !", alert.AlertType.success);

            int[] idmenu = strmenu.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            //int[] idmenu = { 5, 18, 20, 31, 29, 44, 45, 51, 55 };
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

            /*
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
            */
            //Output
            string recommend = "";
            foreach (double i in Generation[populationSize - 1])
            {
                recommend += String.Format("{0:0.0000}", i) + " ";
            }

            string strUdpate = string.Format("UPDATE menu set cal_menu='{0}' where date='{1}'", recommend, DateTime.Today.ToString("dd/MM/yyyy"));
            databaseObject.RunSQL(strUdpate);
        }

        static void CreateDNA(List<double[]> Generation)
        {
            for (int n = 0; n < populationSize; n++)
            {
                double[] DNA = new double[lengthDNA];
                for (int k = 0; k < lengthDNA; k++)
                {
                    DNA[k] = RandomHS();
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

        static int calConflict(double[] x, List<int[]> Database, int[] input, int goalCalo, int begin, int end) // goalProtein, goalLipid, goalCarb
        {
            double sumCalo = 0; // sumProtein, sumLipid, sumCarb;
            for (int i = begin; i < end; i++)
            {
                int idx = input[i];
                sumCalo += Database[idx][1] * x[i];
                // sumProtein += Database[idx][  ] * x[i];
                // sumLipid
                // sumCarb
            }
            if (Math.Abs(sumCalo - GoalCalo) <= epsilon)
                return 0;
            else
                return Convert.ToInt32(Math.Abs(sumCalo - GoalCalo));
        }

        //Hàm mục tiêu
        static double FitnessCal(double[] x, List<int[]> Database, int[] input)
        {
            int Value_conflict = 0;

            // Hệ số có tổng Calo phù hợp (Protein, Lipid, Carb)
            Value_conflict += calConflict(x,Database,input,GoalCalo, 0, lengthDNA);

            //He so can bang 3 bua
            //Buasang
            int PartCalo = GoalCalo * tile[0] / 100;
            Value_conflict += calConflict(x, Database, input, PartCalo, 0, breakfast);

            // Trưa
            PartCalo = GoalCalo * tile[1] / 100;
            Value_conflict += calConflict(x, Database, input, PartCalo, breakfast, breakfast + lunch);

            return (1.0 / (Value_conflict + 1));
        }

        static void CopyArray(double[] arrCopy, double[] arrPaste)
        {
            for (int i = 0; i < lengthDNA; i++)
                arrPaste[i] = arrCopy[i];
        }

        static void Crossover(double[] parent1, double[] parent2, double[] child1, double[] child2)
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

        static void Mutate(double[] DNA, int lengthDNA)
        {
            for (int pos = 0; pos < lengthDNA; pos++)
            {
                if (rd.NextDouble() < mutationRate)
                {
                    DNA[pos] = RandomHS();
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

        static int RouletteSelection(List<double> FitnessTable)
        {
            double randomFitness = rd.NextDouble() * totalFitness;
            int idx = -1;
            int mid;
            int first = 0;
            int last = populationSize - 1;
            mid = (last - first) / 2;

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
