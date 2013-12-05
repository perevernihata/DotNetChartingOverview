using System.Drawing;
using System.Linq;
using ChartingCore;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using Color = System.Drawing.Color;

namespace ILNumericsCharting
{
    /// <summary>
    /// You can download ILNumerics sources from here: http://ilnumerics.net/download-ilnumerics.html
    /// </summary>
    public class ILNumericsChartingAdapter : BaseChartAdapter
    {
        public ILNumericsChartingAdapter(ChartParameters parameters)
            : base(parameters)
        {
        }

        protected override Image DoCreateChartImage()
        {
            var scene = new ILScene();
            var tmpArray = new float[2, Parameters.SeriaData.Count()];
            var i = 0;
            foreach (var item in Parameters.SeriaData)
            {
                tmpArray[0, i] = item.Key;
                tmpArray[1, i] = item.Value;
                i++;
            }
            ILArray<float> data = tmpArray;
            var cube = new ILPlotCube { AutoScaleOnAdd = true };
            cube.Add(new ILLinePlot(data.T));
            scene.Add(cube);
            var driver = new ILGDIDriver(Parameters.ChartWidth, Parameters.ChartHeight, scene, Color.White);
            driver.Render();
            return driver.BackBuffer.Bitmap;
        }
    }
}
