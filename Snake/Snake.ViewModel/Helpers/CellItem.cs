using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.ViewModel.Helpers
{
    public class CellItem
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Fill { get; set; }

        public CellItem(double x, double y, double width, double height, string fill)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Fill = fill;
        }
    }
}
