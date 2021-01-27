

namespace Vigorski
{
    public partial class Form1
    {

        private void InitializeControlValues()
        {
            txtbx_save_path.Text = settings.txtbx_save_path;
            numupdwn_bloodpressure_age.Value = settings.numupdwn_bloodpressure_age;
            rdo_weight_kg.Checked = settings.rdo_weight_kg;
            rdobtn_ft_in.Checked = settings.rdobtn_ft_in;
            rdobtn_metre.Checked = settings.rdobtn_metre;
            rdobtn_stone_lbs.Checked = settings.rdobtn_stone_lbs;
            settings.rdobtn_weight_female = settings.rdobtn_weight_female;
            settings.rdobtn_weight_male = settings.rdobtn_weight_male;
        }

        private void SaveSettings()
        {
            settings.txtbx_save_path = txtbx_save_path.Text;
            settings.numupdwn_bloodpressure_age = numupdwn_bloodpressure_age.Value;
            settings.rdo_weight_kg = rdo_weight_kg.Checked;
            settings.rdobtn_ft_in = rdobtn_ft_in.Checked;
            settings.rdobtn_metre = rdobtn_metre.Checked;
            settings.rdobtn_stone_lbs = rdobtn_stone_lbs.Checked;
            settings.rdobtn_weight_female = settings.rdobtn_weight_female;
            settings.rdobtn_weight_male = settings.rdobtn_weight_male;
            settings.Save();
        }
    }
}
