using System;
using System.Windows.Forms;

namespace Vigorski
{
    public partial class Form1
    {

        /*
         *
         * Mifflin-St Jeor Equation:
           Male: BMR = 10W + 6.25H - 5A + 5
           Female: BMR = 10W + 6.25H - 5A - 161
           
           Revised Harris-Benedict Equation:
           Male: BMR = 13.397W + 4.799H - 5.677A + 88.362
           Female: BMR = 9.247W + 3.098H - 4.330A + 447.593
           
           Katch-McArdle Formula:
           BMR = 370 + 21.6(1 - F)W
           
           where:
           W is body weight in kg
           H is body height in cm
           A is age
           F is body fat in percentage
         *
         */

        private void WorkoutCalories(double weight, double tallness, double boer_fat, double james_fat, double hume_fat)
        {
            double MSJ;
            double KA;
            double HB;
            tallness = tallness * 100;
            double age = Convert.ToDouble(numupdwn_weight_age.Value);
            double fat = (boer_fat + james_fat + hume_fat) / 3;


            if (rdobtn_weight_male.Checked)
            {
                MSJ= 10 * weight + 6.25 * tallness - 5 * age + 5;
                HB = 13.397 * weight + 4.799 * tallness - 5.677 * age + 88.362;
                
            }
            else
            {
                MSJ = 10 * weight + 6.25 * tallness - 5 * age - 161;
                HB = 9.247 * weight + 3.098 * tallness - 4.330 * age + 447.593;

            }

            KA = 370 + ((21.6*(1 - (fat/100)))* weight);

            PopulateGrid(MSJ, HB, KA);
        }

        private void PopulateGrid(double MSJ, double HB, double KA)
        {
            // 1.5 is the exercise factor.
            double ExtreameLossMSJ = Math.Round(MSJ*0.58*1.5,0);
            double WeightLossMSJ = Math.Round(MSJ*0.79 * 1.5, 0);
            double MildLossMSJ = Math.Round(MSJ*0.90 * 1.5, 0);
            double MaintainMSJ = Math.Round(MSJ * 1.5, 0);
            double MildGainMSJ = Math.Round(MSJ*1.1 * 1.5, 0);
            double WeightGainMSJ = Math.Round(MSJ*1.21 * 1.5, 0);
            double FastGainMSJ = Math.Round(MSJ*1.42 * 1.5, 0);

            double ExtreameLossHB = Math.Round(HB * 0.58 * 1.5, 0);
            double WeightLossHB = Math.Round(HB * 0.79 * 1.5, 0);
            double MildLossHB = Math.Round(HB * 0.90 * 1.5, 0);
            double MaintainHB = Math.Round(HB * 1.5, 0);
            double MildGainHB = Math.Round(HB * 1.1 * 1.5, 0);
            double WeightGainHB = Math.Round(HB * 1.21 * 1.5, 0);
            double FastGainHB = Math.Round(HB * 1.42 * 1.5, 0);

            double ExtreameLossKA = Math.Round(KA * 0.58 * 1.5, 0);
            double WeightLossKA = Math.Round(KA * 0.79 * 1.5, 0);
            double MildLossKA = Math.Round(KA * 0.90 * 1.5, 0);
            double MaintainKA = Math.Round(KA * 1.5, 0);
            double MildGainKA = Math.Round(KA * 1.1 * 1.5, 0);
            double WeightGainKA = Math.Round(KA * 1.21 * 1.5, 0);
            double FastGainKA = Math.Round(KA * 1.42 * 1.5, 0);



            dg_calories.Rows.Add();
            dg_calories.Rows[0].Cells[0].Value = "Mifflin-St Jeor";
            dg_calories.Rows[0].Cells[1].Value = ExtreameLossMSJ.ToString();
            dg_calories.Rows[0].Cells[2].Value = WeightLossMSJ.ToString();
            dg_calories.Rows[0].Cells[3].Value = MildLossMSJ.ToString();
            dg_calories.Rows[0].Cells[4].Value = MaintainMSJ.ToString();
            dg_calories.Rows[0].Cells[5].Value = MildGainMSJ.ToString();
            dg_calories.Rows[0].Cells[6].Value = WeightGainMSJ.ToString();
            dg_calories.Rows[0].Cells[7].Value = FastGainMSJ.ToString();

            dg_calories.Rows.Add();
            dg_calories.Rows[1].Cells[0].Value = "Harris-Benedict";
            dg_calories.Rows[1].Cells[1].Value = ExtreameLossHB.ToString();
            dg_calories.Rows[1].Cells[2].Value = WeightLossHB.ToString();
            dg_calories.Rows[1].Cells[3].Value = MildLossHB.ToString();
            dg_calories.Rows[1].Cells[4].Value = MaintainHB.ToString();
            dg_calories.Rows[1].Cells[5].Value = MildGainHB.ToString();
            dg_calories.Rows[1].Cells[6].Value = WeightGainHB.ToString();
            dg_calories.Rows[1].Cells[7].Value = FastGainHB.ToString();

            dg_calories.Rows.Add();
            dg_calories.Rows[2].Cells[0].Value = "Katch-McArdle";
            dg_calories.Rows[2].Cells[1].Value = ExtreameLossKA.ToString();
            dg_calories.Rows[2].Cells[2].Value = WeightLossKA.ToString();
            dg_calories.Rows[2].Cells[3].Value = MildLossKA.ToString();
            dg_calories.Rows[2].Cells[4].Value = MaintainKA.ToString();
            dg_calories.Rows[2].Cells[5].Value = MildGainKA.ToString();
            dg_calories.Rows[2].Cells[6].Value = WeightGainKA.ToString();
            dg_calories.Rows[2].Cells[7].Value = FastGainKA.ToString();


            // 1 calorie = 4.1868 kJ

            dg_kilojoule.Rows.Add();
            dg_kilojoule.Rows[0].Cells[0].Value = "Mifflin-St Jeor";
            dg_kilojoule.Rows[0].Cells[1].Value = Math.Round((4.1868 * ExtreameLossMSJ),0).ToString();
            dg_kilojoule.Rows[0].Cells[2].Value = Math.Round((4.1868 * WeightLossMSJ), 0).ToString();
            dg_kilojoule.Rows[0].Cells[3].Value = Math.Round((4.1868 * MildLossMSJ), 0).ToString();
            dg_kilojoule.Rows[0].Cells[4].Value = Math.Round((4.1868 * MaintainMSJ), 0).ToString();
            dg_kilojoule.Rows[0].Cells[5].Value = Math.Round((4.1868 * MildGainMSJ), 0).ToString();
            dg_kilojoule.Rows[0].Cells[6].Value = Math.Round((4.1868 * WeightGainMSJ), 0).ToString();
            dg_kilojoule.Rows[0].Cells[7].Value = Math.Round((4.1868 * FastGainMSJ), 0).ToString();

            dg_kilojoule.Rows.Add();
            dg_kilojoule.Rows[1].Cells[0].Value = "Harris-Benedict";
            dg_kilojoule.Rows[1].Cells[1].Value = Math.Round((4.1868 * ExtreameLossHB), 0).ToString();
            dg_kilojoule.Rows[1].Cells[2].Value = Math.Round((4.1868 * WeightLossHB), 0).ToString();
            dg_kilojoule.Rows[1].Cells[3].Value = Math.Round((4.1868 * MildLossHB), 0).ToString();
            dg_kilojoule.Rows[1].Cells[4].Value = Math.Round((4.1868 * MaintainHB), 0).ToString();
            dg_kilojoule.Rows[1].Cells[5].Value = Math.Round((4.1868 * MildGainHB), 0).ToString();
            dg_kilojoule.Rows[1].Cells[6].Value = Math.Round((4.1868 * WeightGainHB), 0).ToString();
            dg_kilojoule.Rows[1].Cells[7].Value = Math.Round((4.1868 * FastGainHB), 0).ToString();

            dg_kilojoule.Rows.Add();
            dg_kilojoule.Rows[2].Cells[0].Value = "Katch-McArdle";
            dg_kilojoule.Rows[2].Cells[1].Value = Math.Round((4.1868 * ExtreameLossKA), 0).ToString();
            dg_kilojoule.Rows[2].Cells[2].Value = Math.Round((4.1868 * WeightLossKA), 0).ToString();
            dg_kilojoule.Rows[2].Cells[3].Value = Math.Round((4.1868 * MildLossKA), 0).ToString();
            dg_kilojoule.Rows[2].Cells[4].Value = Math.Round((4.1868 * MaintainKA), 0).ToString();
            dg_kilojoule.Rows[2].Cells[5].Value = Math.Round((4.1868 * MildGainKA), 0).ToString();
            dg_kilojoule.Rows[2].Cells[6].Value = Math.Round((4.1868 * WeightGainKA), 0).ToString();
            dg_kilojoule.Rows[2].Cells[7].Value = Math.Round((4.1868 * FastGainKA), 0).ToString();
        }
    }
}
