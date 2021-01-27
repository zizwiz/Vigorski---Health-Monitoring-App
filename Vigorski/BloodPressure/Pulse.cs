namespace Vigorski
{
    public partial class Form1
    {


        private void pulserate()
        {

            /*
            			            18-25	26-35	36-45	46-55	51-56	65+
                Extreame Athlete	40-48	40-48	40-49	40-49	40-50	40-49
                Athlete			    49-55	49-54	50-56	50-57	51-56	50-55
                Excellent		    56-61	55-61	57-62	58-63	57-61	56-61
                Good 			    62-65	62-65	63-66	64-67	62-67	62-65
                Above Average		66-69	66-70	67-70	68-71	68-71	66-69
                Average			    70-73	71-74	71-75	72-76	72-75	70-73
                Below Average		74-81	75-81	76-82	77-83	76-81	74-79
                Poor			    >82	    >82	    >83	    >84	    >82	    >80
            */
            decimal maxPulseRate = 0;

            if (rdobtn_bloodpressure_male.Checked) maxPulseRate = 220 - numupdwn_bloodpressure_age.Value;
            if (rdobtn_bloodpressure_female.Checked) maxPulseRate = 226 - numupdwn_bloodpressure_age.Value;

            float Minrate = (float)maxPulseRate * (float)0.5;
            float Maxrate = (float)maxPulseRate * (float)0.7;

            lbl_max_pulse.Text = "Your maximum heart rate = " + maxPulseRate;
            lbl_activerange.Text = "Your target heart rate range is between\r" + Minrate.ToString() + " and " + Maxrate.ToString();
            lbl_yourpulse.Text = "\rAt rest your heart rate should be between\r60 and 100";

        }











    }
}
