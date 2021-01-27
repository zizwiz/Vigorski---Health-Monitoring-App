using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Vigorski.ShowData
{
    public partial class Temperature : Form
    {
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        private DataGridView dgv_data;

        public Temperature(DataGridView dgv)
        {
            InitializeComponent();
            dgv_data = dgv;
        }

        private void btn_temptur_graph_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Temperature_Load(object sender, EventArgs e)
        {
            chrt_temperature.ChartAreas[0].AxisX.IsMarginVisible = false;
            chrt_temperature.Legends.Clear(); // We do not need a legend

            int counter = 0;
            foreach (DataGridViewRow row in dgv_data.Rows)
            {
                chrt_temperature.Series["Temperature"].Points.Add(Convert.ToDouble(dgv_data["Temperature", counter].Value));
                chrt_temperature.Series["Temperature"].Points[counter].AxisLabel = Convert.ToDateTime(dgv_data["Date", counter].Value).ToString("d");

                counter++;
            }
        }

        private void Temperature_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chrt_temperature.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint); // set ChartElementType.PlottingArea for full area, not only DataPoints
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint) // set ChartElementType.PlottingArea for full area, not only DataPoints
                {
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    tooltip.Show(((int)yVal).ToString(), chrt_temperature, pos.X, pos.Y - 15);
                }
            }
        }
    }
}
