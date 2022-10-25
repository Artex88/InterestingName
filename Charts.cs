using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace Names
{
    internal static class Charts
    {
        public static void ShowHistogram(HistogramData stats)
        {
            // Графики строятся сторонней библиотекой ZedGraph.
            // Примеры можно найти тут https://jenyay.net/Programming/ZedGraph или тут https://web.archive.org/web/20051127161423/http://zedgraph.sourceforge.net/samples.html
            // Не бойтесь экспериментировать с кодом самостоятельно!

            var chart = new ZedGraphControl
            {
                Dock = DockStyle.Fill
            };
            chart.GraphPane.Title.Text = stats.Title;
            chart.GraphPane.YAxis.Title.Text = "Y";
            chart.GraphPane.AddBar("", Enumerable.Range(0, stats.YValues.Length).Select(i => (double) i).ToArray(),
                stats.YValues, Color.Blue);
            chart.GraphPane.YAxis.Scale.MaxAuto = true;
            chart.GraphPane.YAxis.Scale.MinAuto = true;
            chart.GraphPane.XAxis.Type = AxisType.Text;
            chart.GraphPane.XAxis.Scale.TextLabels = stats.XLabels;

            chart.AxisChange();
            // Form — это привычное нам окно программы.
            // Это одна из главных частей подсистемы под названием Windows Forms http://msdn.microsoft.com/ru-ru/library/ms229601.aspx
            var form = new Form
            {
                Text = stats.Title,
                Size = new Size(800, 600)
            };
            form.Controls.Add(chart);
            form.ShowDialog();
        }
    }
}