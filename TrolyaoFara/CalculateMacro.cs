using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrolyaoFara
{
    class CalculateMacro
    {
        public void macroCalo(double BMR, double TDEE, int mode, int level, ref int protein, ref int lipid, ref int carb, ref double calo)
        {
            int pProtein = protein, pLipid = lipid, pCarb = carb;
            calo = (BMR + TDEE) / 2;
            calo = caloForTarget(mode, level, calo);
            
            protein = Convert.ToInt32(calo * pProtein / 100 / 4);
            lipid = Convert.ToInt32(calo * pLipid / 100 / 9);
            carb = Convert.ToInt32((calo - (protein * 4 + lipid * 9)) / 4);
        }

        private double caloForTarget(int mode, int level, double calo)
        {
            if (mode == 0)
                return calo;
            else
            {
                double change;
                if (level == 0) //Thay đổi 0,25kg/tuần
                    change = calo * 89 / 100;
                else if (level == 1) //Thay đổi 0,5kg / tuần
                    change = calo * 78 / 100;
                else //Thay đổi 1kg / tuần
                    change = calo * 56 / 100;

                if (mode == 1) // Giảm
                    return calo - change;
                else // Tăng
                    return calo + change;
            }
        }

        public double TDEE(double BMR, int intensity)
        {
            if (intensity == 0) // Ít hoạt động
                return BMR * 1.2;
            else if (intensity == 1) // Hoạt động nhẹ
                return BMR * 1.375;
            else if (intensity == 2) // Hoạt động vừa phải
                return BMR * 1.55;
            else if (intensity == 3) // Hoạt động nhiều
                return BMR * 1.725;
            else // Hoạt động nặng
                return BMR * 1.9;
        }

        public double BodyFat(int height, int neck, int waist, int hip, int gender)
        {
            // Nam 1; Nữ 2
            if (gender == 1)
            {
                return 86.010 * Math.Log10(waist - neck) - 70.041 * Math.Log10(height) + 36.76;
            }
            else
            {
                return 163.205 * Math.Log10(hip + waist - neck) - 97.684 * Math.Log10(height) + 78.387;
            }
        }

        //BMR
        public double Katch_McArdle(int weight, double fat)
        {
            double LBM = weight - (weight * fat / 100);
            return 21.6 * LBM + 370;
        }

        public double Miffin_St_jeor(int weight, int height, int old, int gender)
        {
            // Nam 1; Nữ 2
            double formula = (10 * weight) + (6.25 * height) - (5 * old);
            if(gender == 1)
                return formula + 5;
            return formula - 161;
        }

        public double BMI(int weight, double height)
        {
            height /= 100.0;
            return weight/(height*height);
        }

        public void TypeOfBody(double BMI, ref string type, ref string warning)
        {
            if (BMI < 18.5)
            {
                type = "Gầy";
                warning = "Thấp";
            }
            else if (18.5 <= BMI && BMI < 25.0)
            {
                type = "Bình thường";
                warning = "Trung bình";
            }
            else if (25.0 <= BMI && BMI < 30.0)
            {
                type = "Hơi béo";
                warning = "Cao";
            }
            else if (30.0 <= BMI && BMI < 35.0)
            {
                type = "Béo phì cấp độ 3";
                warning = "Cao";
            }
            else if (35.0 <= BMI && BMI <= 39.9)
            {
                type = "Béo phì cấp độ 2";
                warning = "Rất cao";
            }
            else
            {
                type = "Béo phì cấp độ 3";
                warning = "Nguy hiểm";
            }
        }

        // Type of using Bodyfat
        public string TypeOfBody2(double BodyFat, int gender)
        {
            // Nam 1; Nữ 2
            if (gender == 1)
            {
                if (BodyFat < 2)
                    return "Quá ít. Cần bổ sung gấp";
                else if (2 <= BodyFat && BodyFat <= 4)
                    return "Quá ít. Cần bổ sung";
                else if (4 < BodyFat && BodyFat <= 13)
                    return "Ít";
                else if (13 < BodyFat && BodyFat <= 17)
                    return "Chuẩn";
                else if (17 < BodyFat && BodyFat <= 25)
                    return "Bình thường";
                else
                    return "Béo phì";
            }
            else
            {
                if (BodyFat < 10)
                    return "Quá ít. Cần bổ sung gấp";
                else if (10 <= BodyFat && BodyFat <= 12)
                    return "Quá ít. Cần bổ sung";
                else if (12 < BodyFat && BodyFat <= 20)
                    return "Ít";
                else if (20 < BodyFat && BodyFat <= 24)
                    return "Chuẩn";
                else if (24 < BodyFat && BodyFat <= 31)
                    return "Bình thường";
                else
                    return "Béo phì";
            }
        }
    }
}
