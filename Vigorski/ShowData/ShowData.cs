using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vigorski
{
    public partial class Form1
    {
        private void btn_show_data_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtbx_save_path.Text))
            {
                tabControl1.SelectedTab = tab_Graphs;
                string tempture = "";
                string wght = "";

                // Get the data.
                string[,] values = Load_vac_Csv(txtbx_save_path.Text);

                int num_rows = values.GetUpperBound(0) + 1;

                dgv_data.Columns.Clear();

                dgv_data.Columns.Add("Date", "Date");
                dgv_data.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv_data.Columns["Date"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

                dgv_data.Columns.Add("Time", "Time");
                dgv_data.Columns["Time"].DefaultCellStyle.Format = "H:mm:ss";
                dgv_data.Columns["Time"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

                dgv_data.Columns.Add("Systolic", "Systolic");
                dgv_data.Columns["Systolic"].DefaultCellStyle.Format = "### ##0";
                dgv_data.Columns["Systolic"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;


                dgv_data.Columns.Add("Diastolic", "Diastolic");
                dgv_data.Columns["Diastolic"].DefaultCellStyle.Format = "### ##0";
                dgv_data.Columns["Diastolic"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

                dgv_data.Columns.Add("Pulse", "Pulse");
                dgv_data.Columns["Pulse"].DefaultCellStyle.Format = "### ##0";
                dgv_data.Columns["Pulse"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

                dgv_data.Columns.Add("SPO2", "SPO2");
                dgv_data.Columns["SPO2"].DefaultCellStyle.Format = "### ##0";
                dgv_data.Columns["SPO2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

                dgv_data.Columns.Add("Weight", "Weight");
                dgv_data.Columns["Weight"].DefaultCellStyle.Format = "##0.00";
                dgv_data.Columns["Weight"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

                dgv_data.Columns.Add("Temperature", "Temperature");
                dgv_data.Columns["Temperature"].DefaultCellStyle.Format = "#0.00";
                dgv_data.Columns["Temperature"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;



                string[] data = File.ReadAllLines(txtbx_save_path.Text);
                string[] headings = Regex.Split(data[0], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                //  Date,Time,Systolic,Diastolic,Pulse,SPO2,Weight,Temperature
                int dat = Array.IndexOf(headings, "Date");
                int tim = Array.IndexOf(headings, "Time");
                int sys = Array.IndexOf(headings, "Systolic");
                int dia = Array.IndexOf(headings, "Diastolic");
                int pul = Array.IndexOf(headings, "Pulse");
                int spo = Array.IndexOf(headings, "SPO2");
                int wei = Array.IndexOf(headings, "Weight");
                int tem = Array.IndexOf(headings, "Temperature");

                // Add the data.
                for (int r = 1; r < num_rows; r++)
                {
                    tempture = values[r, tem]; //remove quotes
                    tempture = tempture.Substring(1, tempture.Length-2);

                    wght = values[r, wei];
                    wght = wght.Substring(1, wght.Length - 2);

                    dgv_data.Rows.Add();
                    dgv_data.Rows[r - 1].Cells[0].Value = Convert.ToDateTime(values[r, dat]); //Date
                    dgv_data.Rows[r - 1].Cells[1].Value = Convert.ToDateTime(values[r, tim]); //Time
                    dgv_data.Rows[r - 1].Cells[2].Value = Convert.ToInt32(values[r, sys]); //Systolic
                    dgv_data.Rows[r - 1].Cells[3].Value = Convert.ToInt32(values[r, dia]); //Diastolic
                    dgv_data.Rows[r - 1].Cells[4].Value = Convert.ToInt32(values[r, pul]); //Pulse
                    dgv_data.Rows[r - 1].Cells[5].Value = Convert.ToInt32(values[r, spo]); //SPO2
                    dgv_data.Rows[r - 1].Cells[6].Value = Convert.ToDecimal(wght); //Weight
                    dgv_data.Rows[r - 1].Cells[7].Value = Convert.ToDecimal(tempture); //Temperature

                }

                dgv_data.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv_data.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv_data.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv_data.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv_data.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv_data.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv_data.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv_data.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgv_data.FirstDisplayedScrollingRowIndex = dgv_data.RowCount - 1;
                dgv_data.RowHeadersVisible = false;
                dgv_data.AllowUserToAddRows = false;

            }
            else
            {
                MessageBox.Show("The file does not exist or is empty");
            }



        }

        // Load a CSV file into an array of rows and columns.
        // Assume there may be blank lines but every line has
        // the same number of fields.
        private string[,] Load_vac_Csv(string filename)
        {
            // Get the file's text.
            string whole_file = File.ReadAllText(filename);

            // Split into lines.
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // See how many rows and columns there are.
            int num_rows = lines.Length;
            int num_cols = (lines[0].Split(',').Length);

            // Allocate the data array.
            string[,] values = new string[num_rows, num_cols];

            // Load the array.
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = Regex.Split(lines[r], ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                                                          

                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];

                }
            }

            // Return the values.
            return values;
        }
    }
}
