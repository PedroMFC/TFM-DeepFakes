using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using iTextSharp.text;

namespace FocaPluginExample.Models
{
    public class PieChart
    {
        private readonly double[] _values;
        private double[] _angles;
        private readonly string[] _captions;
        private readonly int _length;
        private readonly BaseColor[] _chartcolors;
        private double _totalValues;

        /// <summary>
        /// Calculates angles based on the values for the chart
        /// </summary>
        private void CalculateAngles()
        {
            _angles = new double[_values.Length];

            _totalValues = 0;
            foreach (var v in _values)
                _totalValues += v;

            var counter = 0;
            foreach (var v in _values)
                _angles[counter++] = v * 360 / _totalValues;
        }

        /// <summary>
        /// Expects chart values and captions for the chart
        /// </summary>
        /// <param name="values">chart values</param>
        /// <param name="captions">captions (label) for the various segments in order of values</param>
        public PieChart(double[] values, string[] captions)
        {
            if (values.Length != captions.Length)
            {
                throw (new Exception("Length of values must be equal to the length of captions of chart."));
            }

            if (values.Length > 10)
            {
                throw (new Exception("Pie chart does not support items more than 10."));
            }

            _length = values.Length;
            _values = values;
            _captions = captions;

            CalculateAngles();

            _chartcolors = new BaseColor[_length];
            _chartcolors[0] = BaseColor.RED;
            if (_length > 1) _chartcolors[1] = BaseColor.GREEN;
            if (_length > 2) _chartcolors[2] = BaseColor.BLUE;
            if (_length > 3) _chartcolors[3] = BaseColor.BLACK;
            if (_length > 4) _chartcolors[4] = BaseColor.YELLOW;
            if (_length > 5) _chartcolors[5] = BaseColor.ORANGE;
            if (_length > 6) _chartcolors[6] = BaseColor.CYAN;
            if (_length > 7) _chartcolors[7] = BaseColor.MAGENTA;
            if (_length > 8) _chartcolors[8] = BaseColor.PINK;
            if (_length > 9) _chartcolors[9] = BaseColor.LIGHT_GRAY;
        }

        /// <summary>
        /// Expects chart values, captions and colors for the chart
        /// </summary>
        /// <param name="values">chart values</param>
        /// <param name="captions">captions (label) for the various segments in order of values</param>
        /// <param name="chartcolors">colors to be used for the charts in order of values and captions</param>
        public PieChart(double[] values, string[] captions, Color[] chartcolors)
        {
            if (chartcolors == null)
            {
                throw (new Exception("Chart colors cannot be null."));
            }

            if (values.Length != captions.Length || values.Length != chartcolors.Length)
            {
                throw (new Exception("Length of values, chart colors must be equal to the length of captions of chart."));
            }

            _length = values.Length;
            _values = values;
            _captions = captions;
            _chartcolors = Array.ConvertAll(chartcolors, new Converter<Color, BaseColor>(DoubleToFloat));

            CalculateAngles();
        }

        /// <summary>
        /// Expects chart values, captions and colors for the chart
        /// </summary>
        /// <param name="values">chart values</param>
        /// <param name="captions">captions (label) for the various segments in order of values</param>
        /// <param name="schartcolors">colors to be used for the charts in order of values and captions</param>
        public PieChart(double[] values, string[] captions, BaseColor[] schartcolors)
        {
            if (schartcolors == null)
            {
                throw (new Exception("Chart colors cannot be null."));
            }

            if (values.Length != captions.Length || values.Length != schartcolors.Length)
            {
                throw (new Exception("Length of values, chart colors must be equal to the length of captions of chart."));
            }

            _length = values.Length;
            _values = values;
            _captions = captions;
            _chartcolors = schartcolors;

            CalculateAngles();
        }

        private static BaseColor DoubleToFloat(Color c)
        {
            return new BaseColor(c);
        }

        public double[] Values { get { return _values; } }
        public string[] Captions { get { return _captions; } }
        public BaseColor[] ChartColors { get { return _chartcolors; } }
        public int Length { get { return _length; } }
        public double TotalValues { get { return _totalValues; } }
        public double[] Angles { get { return _angles; } }
    }
}
