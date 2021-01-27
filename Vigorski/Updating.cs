using System;

namespace Vigorski
{
    public partial class Form1
    {
        private void numupdwn_weight_age_ValueChanged(object sender, EventArgs e)
        {
            numupdwn_bloodpressure_age.Value = numupdwn_weight_age.Value;
        }

        private void numupdwn_bloodpressure_age_ValueChanged(object sender, EventArgs e)
        {
            numupdwn_weight_age.Value = numupdwn_bloodpressure_age.Value;
        }


        private void rdobtn_bloodpressure_male_CheckedChanged(object sender, EventArgs e)
        {
            if (rdobtn_bloodpressure_male.Checked)
            {
                rdobtn_weight_male.Checked = true;
                rdobtn_weight_female.Checked = false;
                rdobtn_bloodpressure_female.Checked = false;
            }
            else
            {
                rdobtn_weight_male.Checked = false;
                rdobtn_weight_female.Checked = true;
                rdobtn_bloodpressure_female.Checked = true;
            }


        }


        private void rdobtn_weight_male_CheckedChanged(object sender, EventArgs e)
        {
            if (rdobtn_weight_male.Checked)
            {
                rdobtn_bloodpressure_male.Checked = true;
                rdobtn_bloodpressure_female.Checked = false;
                rdobtn_weight_female.Checked = false;
            }
            else
            {
                rdobtn_bloodpressure_male.Checked = false;
                rdobtn_bloodpressure_female.Checked = true;
                rdobtn_weight_female.Checked = true;
            }
        }


        private void rdobtn_metre_CheckedChanged(object sender, EventArgs e)
        {
            if (rdobtn_metre.Checked)
            {
                txtbx_height_metre.Visible = true;
                txtbx_inches.Visible = txtbx_feet.Visible = false;
            }
            else
            {
                txtbx_height_metre.Visible = false;
                txtbx_inches.Visible = txtbx_feet.Visible = true;
            }

        }

        private void rdo_weight_kg_CheckedChanged(object sender, EventArgs e)
        {

            if (rdo_weight_kg.Checked)
            {
                txtbx_weight_kg.Visible = true;
                txtbx_weight_stone.Visible = txtbx_weight_lbs.Visible = false;
            }
            else
            {
                txtbx_weight_kg.Visible = false;
                txtbx_weight_stone.Visible = txtbx_weight_lbs.Visible = true;
            }

        }


    }
}
