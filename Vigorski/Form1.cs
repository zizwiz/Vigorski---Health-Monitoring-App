using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using help_about;
using Vigorski.Graphs;
using Vigorski.Properties;
using Vigorski.ShowData;
using convert;

namespace Vigorski
{
    public partial class Form1 : Form
    {
        private Settings settings = Settings.Default;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeControlValues();

            numupdwn_weight_age.Value = numupdwn_bloodpressure_age.Value;
            rdobtn_bloodpressure_female.Checked = rdobtn_weight_female.Checked;
            rdobtn_bloodpressure_male.Checked = rdobtn_weight_male.Checked;

            rdobtn_metre.Checked = true;
            txtbx_height_metre.Visible = true;
            txtbx_inches.Visible = txtbx_feet.Visible = false;

            rdo_weight_kg.Checked = true;
            txtbx_weight_kg.Visible = true;
            txtbx_weight_stone.Visible = txtbx_weight_lbs.Visible = false;

            numupdwn_o2_saturation.Value = 100;
            lbl_o2_saturation.Text = "O2 level is OK";
            lbl_o2_saturation.BackColor = Color.Green;
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            var f1 = new Help_Form();
            f1.ShowDialog();
        }

        private void numupdwn_o2_saturation_ValueChanged(object sender, EventArgs e)
        {
            if (numupdwn_o2_saturation.Value > 94)
            {
                lbl_o2_saturation.Text = "O2 level is OK";
                lbl_o2_saturation.BackColor = Color.Green;
            }
            else if (numupdwn_o2_saturation.Value < 93)
            {
                lbl_o2_saturation.Text = "O2 level CRITICAL you need to go to Hospital";
                lbl_o2_saturation.BackColor = Color.Red;
            }
            else
            {
                lbl_o2_saturation.Text = "O2 level Low you need to contact Doctor";
                lbl_o2_saturation.BackColor = Color.Yellow;
            }
        }

        private void btn_choose_file_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.InitialDirectory = "C:\\temp\\";      
            saveFileDialog1.Title = "Save text Files";
            //saveFileDialog1.CheckFileExists = true;
            //saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtbx_save_path.Text = saveFileDialog1.FileName;
                using (StreamWriter file = new StreamWriter(txtbx_save_path.Text, true))
                {
                    file.WriteLine("Date,Time,Systolic,Diastolic,Pulse,SPO2,Weight,Temperature");
                }
            }
        }

        private void btn_save_data_Click(object sender, EventArgs e)
        {
            if (txtbx_save_path.Text != "")
            {
                string fileName = txtbx_save_path.Text;


                if (!File.Exists(fileName))
                {
                    using (StreamWriter file = new StreamWriter(fileName, true))
                    {
                        file.WriteLine("Date,Time,Systolic,Diastolic,Pulse,SPO2,Weight,Temperature");
                    }
                }

                string weight = "";
                if (rdo_weight_kg.Checked)
                {
                    weight = txtbx_weight_kg.Text;
                }
                else
                {
                    weight = (convert.weight.StonesToKilogram(Convert.ToDouble(txtbx_weight_stone.Text)) + convert.weight.PoundsToKilogram(Convert.ToDouble(txtbx_weight_lbs.Text))).ToString();
                }


                DateTime dtDate = DateTime.Now;

                string data = dtDate.ToString("d", CultureInfo.CreateSpecificCulture("en-GB")) + "," +
                              dtDate.ToString("H:mm:ss") + "," +
                              numupdwn_systolic.Value + "," +
                              numupdwn_diastolic.Value + "," +
                              numupdwn_pulse.Value + "," +
                              numupdwn_o2_saturation.Value + ",\"" +
                              weight + "\",\"" + txtbx_temperature.Text + "\"\r";

                File.AppendAllText(fileName, data);
            }
            else
            {
                MessageBox.Show("You need to choose a file first");
            }
        }

        private void btn_Bloods_graph_Click(object sender, EventArgs e)
        {
            Bloods blGraph = new Bloods(dgv_data);
            blGraph.Show();
        }

        private void btn_tempture_graph_Click(object sender, EventArgs e)
        {
            Temperature tGraph = new Temperature(dgv_data);
            tGraph.Show();
        }

        private void btn_weight_graph_Click(object sender, EventArgs e)
        {
            Weight wGraph = new Weight(dgv_data);
            wGraph.Show();
        }
    }
}
