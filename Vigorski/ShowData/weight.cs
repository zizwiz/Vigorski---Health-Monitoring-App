using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Vigorski.ShowData
{
    public partial class Weight : Form
    {
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        private DataGridView dgv_data;

        public Weight(DataGridView dgv)
        {
            InitializeComponent();
            dgv_data = dgv;
        }

        private void btn_Weight_graph_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Weight_Load(object sender, EventArgs e)
        {
            chrt_weight.ChartAreas[0].AxisX.IsMarginVisible = false;
            chrt_weight.Legends.Clear(); // We do not need a legend

            int counter = 0;
            foreach (DataGridViewRow row in dgv_data.Rows)
            {
                chrt_weight.Series["Weight"].Points.Add(Convert.ToDouble(dgv_data["Weight", counter].Value));
                chrt_weight.Series["Weight"].Points[counter].AxisLabel = Convert.ToDateTime(dgv_data["Date", counter].Value).ToString("d");

                counter++;
            }
        }

        private void Weight_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chrt_weight.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint); // set ChartElementType.PlottingArea for full area, not only DataPoints
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint) // set ChartElementType.PlottingArea for full area, not only DataPoints
                {
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    tooltip.Show(((int)yVal).ToString(), chrt_weight, pos.X, pos.Y - 15);
                }
            }
        }
    }
}
