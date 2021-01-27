using System;
using convert;

namespace Vigorski
{
    public partial class Form1
    {
        
        private void btn_calculate_weight_Click(object sender, EventArgs e)
        {
            double weight;

            double tallness;
            double xtraHeight = WorkoutXtraHeight();

            double Robinson = 52;
            double Miller = 56.2;
            double Devine = 50;
            double Hamwi = 48;
            string robinsonstate = "at";
            string millerstate = "at";
            string devinestate = "at";
            string hamwistate = "at";

            double boer = 0;
            double james = 0;
            double hume = 0;
            string boerstate = "Normal";
            string jamesstate = "Normal";
            string humestate = "Normal";

            //Tallness converted to Metre
            if (rdobtn_ft_in.Checked)
            {
                tallness = height.FeetToInches(Convert.ToDouble(txtbx_feet.Text), Convert.ToDouble(txtbx_inches.Text));
                tallness = height.InchesToMetre(tallness);
            }
            else
            {
                tallness = Convert.ToDouble(txtbx_height_metre.Text);
            }

            //Weight convert to kg

            if (rdobtn_stone_lbs.Checked)
            {
                weight = (Convert.ToDouble(txtbx_weight_stone.Text) * 14) + Convert.ToDouble(txtbx_weight_lbs.Text);
                weight = 0.45359237 * weight;
            }
            else
            {
                weight = Convert.ToDouble(txtbx_weight_kg.Text);
            }


            /////////////////////////////////////////////////////////////////////////////////
            /// Ideal Body Mass
            /// /////////////////////////////////////////////////////////////////////////////
            /* Formula to use
            
            G.J.Hamwi Formula(1964)
            Male: 48.0 kg + 2.7 kg per inch over 5 feet
            Female:	45.5 kg + 2.2 kg per inch over 5 feet
            Invented for medicinal dosage purposes.

            B.J.Devine Formula(1974)
            Male:	50.0 kg + 2.3 kg per inch over 5 feet
            Female:	45.5 kg + 2.3 kg per inch over 5 feet
            Similar to the Hamwi Formula, it was originally intended as a basis for medicinal dosages based on weight and height.Over time, the formula became a universal determinant of IBW.

            J.D.Robinson Formula(1983)
            Male:	52 kg + 1.9 kg per inch over 5 feet
            Female:	49 kg + 1.7 kg per inch over 5 feet
            Modification of the Devine Formula.

            D.R.Miller Formula(1983)
            Male:	56.2 kg + 1.41 kg per inch over 5 feet
            Female:	53.1 kg + 1.36 kg per inch over 5 feet
            Modification of the Devine Formula.
            */


            if (rdobtn_weight_male.Checked)
            {
                Robinson = Robinson + (xtraHeight * 1.9);
                Miller = Miller + (xtraHeight * 1.41);
                Devine = Devine + (xtraHeight * 2.3);
                Hamwi = Hamwi + (xtraHeight * 2.7);

            }
            else
            {
                Robinson = 49;
                Miller = 53.1;
                Devine = 45.5;
                Hamwi = 45.5;

                Robinson = Robinson + (xtraHeight * 1.7);
                Miller = Miller + (xtraHeight * 1.36);
                Devine = Devine + (xtraHeight * 2.3);
                Hamwi = Hamwi + (xtraHeight * 2.2);

            }

            if (Robinson < weight) robinsonstate = "over";
            if (Robinson > weight) robinsonstate = "under";

            if (Miller < weight) millerstate = "over";
            if (Miller > weight) millerstate = "under";

            if (Devine < weight) devinestate = "over";
            if (Devine > weight) devinestate = "under";

            if (Hamwi < weight) hamwistate = "over";
            if (Hamwi > weight) hamwistate = "under";


            lbl_Robinson.Text = "According to Robinson(1983) = " + Math.Round(Robinson, 1) + "kgs\ryou are " + robinsonstate + " ideal weight";
            lbl_Miller.Text =   "According to Miller(1983)   = " + Math.Round(Miller, 1) + "kgs\ryou are " + millerstate + " ideal weight";
            lbl_Devine.Text =   "According to Devine(1974)   = " + Math.Round(Devine, 1) + "kgs\ryou are " + devinestate + " ideal weight";
            lbl_Hamwi.Text =    "According to Hamwi(1964)    = " + Math.Round(Hamwi, 1) + "kgs\ryou are " + hamwistate + " ideal weight";





            /////////////////////////////////////////////////////////////////////////////////
            /// Body Mass Index
            /// /////////////////////////////////////////////////////////////////////////////

            //Healthy BMI Range
            /*
             * BMI = mass_kg / (height*height)_m
             *
             * Severe Thinness	< 16
               Moderate Thinness	16 - 17
               Mild Thinness	17 - 18.5
               Normal	18.5 - 25
               Overweight	25 - 30
               Obese Class I	30 - 35
               Obese Class II	35 - 40
               Obese Class III	> 40
             */

            double BMI = weight / (tallness * tallness);
            string BMI_state = "Normal";

            if (BMI < 16) BMI_state = "Severe Thinness";
            if ((BMI >= 16) && (BMI < 17)) BMI_state = "Moderate Thinness";
            if ((BMI >= 17) && (BMI < 18.5)) BMI_state = "Mild Thinness";
            if ((BMI >= 25) && (BMI < 30)) BMI_state = "Overweight";
            if ((BMI >= 30) && (BMI < 35)) BMI_state = "Obese Class I";
            if ((BMI >= 35) && (BMI < 40)) BMI_state = "Obese Class II";
            if (BMI >= 40) BMI_state = "Obese Class III";


            lbl_bmi_weight.Text = "BMI index = " + Math.Round(BMI, 1) + " kg per m²\rwhich means you are " + BMI_state;


            /////////////////////////////////////////////////////////////////////////////////
            /// Ponderal Index
            /// /////////////////////////////////////////////////////////////////////////////
            // 
            /*
             * PI = mass_kg / (height*height*height)_m
             */

            string PI_state = "Normal";
            double PI = weight / (tallness * tallness * tallness);
            if (PI < 11) PI_state = "Too Thin";
            if (PI > 14) PI_state = "Obese";

            lbl_ponderal_index.Text = "Ponderal Index = " + Math.Round(PI, 1) + "kg per m³\rwhich means you are " + PI_state;


            /////////////////////////////////////////////////////////////////////////////////
            /// Lean Body Mass. % Body Fat
            /// /////////////////////////////////////////////////////////////////////////////

            /*
             *Lean Body Mass
             * The Boer Formula:
               Male: eLBM = 0.407W + 0.267H - 19.2
               Females: eLBM = 0.252W + 0.473H - 48.3
               
               The James Formula:
               Males: eLBM = 1.1W - 128(W/H * W/H)
               Females: eLBM = 1.07W - 148(W/H * W/H)
               
               The Hume Formula:
               Males: eLBM = 0.32810W + 0.33929H - 29.5336
               Females: eLBM = 0.29569W + 0.41813H - 43.2933
             
                work out percentage LBM to weight then remainder in % is Fat.

                Body should be between 10% and 40% fat. 
             */

            if (rdobtn_weight_male.Checked)
            {
                boer = 100 - (((0.407 * weight) + (26.7 * tallness) - 19.2) / weight) * 100;
                james = 100 - (((1.1 * weight) - 128 * ((weight/(tallness*100))* (weight / (tallness * 100)))) / weight) * 100;
                hume = 100 - (((0.3281 * weight) + (33.929 * tallness) - 29.5336) / weight) * 100;
            }
            else
            {
                boer = 100 - (((0.252 * weight) + (47.3 * tallness) - 48.3)/weight)*100;
                james = 100 - (((1.07 * weight) - 148 * ((weight / (tallness * 100)) * (weight / (tallness * 100))))/ weight)*100;
                hume = 100 - (((0.29569 * weight) + (41.813 * tallness) - 43.2933)/ weight)*100;
            }

            if (boer < 10) boerstate = "emaciated";
            if (boer > 40) boerstate = "obese";

            if (james < 10) jamesstate = "emaciated";
            if (james > 40) jamesstate = "obese";

            if (hume < 10) humestate = "emaciated";
            if (hume > 40) humestate = "obese";


            lbl_boer.Text =  "According to Boer(1984)  = " + Math.Round(boer, 1) + "%\ryour body fat makes you " + boerstate;
            lbl_james.Text = "According to James(1976) = " + Math.Round(james, 1) + "%\ryour body fat makes you " + jamesstate;
            lbl_hume.Text = "According to Hume(1966)  = " + Math.Round(hume, 1) + "%\ryour body fat makes you " + humestate;

            WorkoutCalories(weight, tallness, boer, james, hume);
        }


        private double WorkoutXtraHeight()
        {
            double xtra = 0;

            //Convert all to metre.

            if (rdobtn_ft_in.Checked)
            {
                xtra = height.FeetToInches(Convert.ToDouble(txtbx_feet.Text), Convert.ToDouble(txtbx_inches.Text));
                xtra = height.InchesToMetre(xtra);
            }
            else
            {
                xtra = Convert.ToDouble(txtbx_height_metre.Text);
            }

            return ((xtra - 1.524) / 0.0254);

        }
    }
}
