using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Vigorski.Graphs
{
    public partial class Bloods : Form
    {
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        private DataGridView dgv_data;

        public Bloods(DataGridView dgv)
        {
            InitializeComponent();
            dgv_data = dgv;
        }

        private void btn_close_bloods_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Bloods_Load(object sender, EventArgs e)
        {
            chrt_bloods.ChartAreas[0].AxisX.IsMarginVisible = false;
            chrt_bloods.Legends.Clear(); // We do not need a legend

            int counter = 0;
            foreach (DataGridViewRow row in dgv_data.Rows)
            {
                chrt_bloods.Series["Systolic"].Points.Add(Convert.ToDouble(dgv_data["Systolic", counter].Value));
                chrt_bloods.Series["Diastolic"].Points.Add(Convert.ToDouble(dgv_data["Diastolic", counter].Value));
                chrt_bloods.Series["Pulse"].Points.Add(Convert.ToDouble(dgv_data["Pulse", counter].Value));
                chrt_bloods.Series["SPO2"].Points.Add(Convert.ToDouble(dgv_data["SPO2", counter].Value));
                chrt_bloods.Series["Systolic"].Points[counter].AxisLabel = Convert.ToDateTime(dgv_data["Date", counter].Value).ToString("d");

                counter++;
            }

        }

        private void chrt_bloods_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chrt_bloods.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint); // set ChartElementType.PlottingArea for full area, not only DataPoints
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint) // set ChartElementType.PlottingArea for full area, not only DataPoints
                {
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    tooltip.Show(((int)yVal).ToString(), chrt_bloods, pos.X, pos.Y - 15);
                }
            }
        }
    }
}
