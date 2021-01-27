using System;
using System.Drawing;
using System.Threading.Tasks;
using Vigorski.Properties;

namespace Vigorski
{
    public partial class Form1
    {
        private bool flash;

        private void btn_stop_Click(object sender, EventArgs e)
        {
            StopHeartBeat();
        }

        private async void StopHeartBeat()
        {
            flash = false;

            if (picbx_heart_colour.Image != null)
            {
                picbx_heart_colour.Image.Dispose();
                picbx_heart_colour.Image = null;
                lbl_diastolic.BackColor = Color.White;
                lbl_systolic.BackColor = Color.White;
                await Task.Delay(1000);
            }
        }

        private async void btn_check_Click(object sender, EventArgs e)
        {

            if (picbx_heart_colour.Image != null)
            {
                flash = false;
                StopHeartBeat();
            }

            bloodpressure();
            pulserate();
        }


        private void bloodpressure()
        {
        /* Chart from www.bloodpressureuk.org
         
        S	190 _							
        Y	180 _	    R	    R	    R	    R	    R	    R	
        S	170 _	    R	    R	    R	    R	    R	    R	
        T	160 _	    R	    R	    R	    R	    R	    R	
        O	150 _	    R	    R	    R	    R	    R	    R	
        l	140 _	    R	    R	    R	    R	    R	    R	
        I	130 _	    Y	    Y	    Y	    Y	    Y	    R	
        C	120 _	    Y	    Y	    Y	    Y	    Y	    R	
            110 _	    G	    G	    G	    G	    Y	    R	
        T	100 _	    G	    G	    G	    G	    Y	    R	
        Y	90  _	    G	    G	    G	    G	    Y	    R	
        P	80  _	    P	    P	    G	    G	    Y	    R	
        #	70  _	    P	    P	    G	    G	    Y	    R	
                    40	    50	    60	    70	    80	    90	    100
                         Diastolic Bottom num	

         */
        if (picbx_heart_colour.Image != null)
            {
                StopHeartBeat(); //stop heart flashing 
                //await Task.Delay(800);
            }

            decimal systolic = numupdwn_systolic.Value;
            decimal diastolic = numupdwn_diastolic.Value;

            int result = 0;
            int result1 = 0;
            int result2 = 0;


            if (systolic < 90) { result1 = 1; lbl_systolic.BackColor = Color.Purple; }
            else if ((systolic >= 90) && (systolic <= 119)) { result1 = 2; lbl_systolic.BackColor = Color.Green; }
            else if ((systolic >= 120) && (systolic <= 139)) { result1 = 3; lbl_systolic.BackColor = Color.Yellow; }
            else if (systolic > 140) { result1 = 4; lbl_systolic.BackColor = Color.Red; }


            if (diastolic < 60) {result2 = 1; lbl_diastolic.BackColor = Color.Purple;}
            else if ((diastolic >= 60) && (diastolic <= 79)) {result2 = 2; lbl_diastolic.BackColor = Color.Green;}
            else if ((diastolic >= 80) && (diastolic <= 89)) {result2 = 3; lbl_diastolic.BackColor = Color.Yellow;}
            else if (diastolic > 90) { result2 = 4; lbl_diastolic.BackColor = Color.Red; }

            result = result1 - result2;
            if (result == 0) result = result1;
            else if (result < 0) result = result2;
            else if (result > 0) result = result1;

            BeatingHeart(result);
        }


        private async void BeatingHeart(int rate)
        {
            flash = false; //enable it to  flash when ready.
            await Task.Delay(1000);

            if (rate == 1)
            {
                flash = true; //enable it to  flash when ready.
                while (flash)
                {

                    picbx_heart_colour.Image = Resources.big_purple_heart;
                    await Task.Delay(800);
                    picbx_heart_colour.Image = Resources.small_purple_heart;
                    await Task.Delay(800);
                    GC.Collect();
                }
            }
            else if (rate == 2)
            {
                flash = true; //enable it to  flash when ready.
                while (flash)
                {
                    picbx_heart_colour.Image = Resources.big_green_heart;
                    await Task.Delay(600);
                    picbx_heart_colour.Image = Resources.small_green_heart;
                    await Task.Delay(600);
                    GC.Collect();
                }
            }
            else if (rate == 3)
            {
                flash = true; //enable it to  flash when ready.
                while (flash)
                {
                    picbx_heart_colour.Image = Resources.big_yellow_heart;
                    await Task.Delay(400);
                    picbx_heart_colour.Image = Resources.small_yellow_heart;
                    await Task.Delay(400);
                    GC.Collect();
                }
            }
            else if (rate == 4)
            {
                flash = true; //enable it to  flash when ready.
                while (flash)
                {
                    picbx_heart_colour.Image = Resources.big_red_heart;
                    await Task.Delay(200);
                    picbx_heart_colour.Image = Resources.small_red_heart;
                    await Task.Delay(200);
                    GC.Collect();
                }
            }

           
        }
    }
}
