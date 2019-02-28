using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Need_more_Speed
{
    class Draw_road
    {
        private Canvas myCanvas;

        public Draw_road(Canvas myCanvas)
        {
            this.myCanvas = myCanvas;
        }

        public void straight_horizontal(int x, int y)
        {
            
        }
        public void straight_vertical(int x, int y)
        {

        }
        public void curve_0Degree(int x_offset, int y_offset, double grid)
        {
            double x_curve = 0;
            double y_curve = 0;

            for (x_curve = 0; x_curve <= grid; x_curve++) 
            {
                y_curve = Math.Sqrt(Math.Pow(grid, 2) - Math.Pow(x_curve, 2));

                Line[] street = new Line[Convert.ToInt16(grid) + 1];
                street[Convert.ToInt16(x_curve)] = new Line() { Name = "street" + Convert.ToInt16(x_curve) };
                street[Convert.ToInt16(x_curve)].Stroke = Brushes.Gray;
                street[Convert.ToInt16(x_curve)].X1 = x_offset;
                street[Convert.ToInt16(x_curve)].X2 = x_offset + Convert.ToInt16(x_curve);
                street[Convert.ToInt16(x_curve)].Y1 = y_offset;
                street[Convert.ToInt16(x_curve)].Y2 = y_offset - Convert.ToInt16(y_curve); ;

                street[Convert.ToInt16(x_curve)].StrokeThickness = 2;
                myCanvas.Children.Add(street[Convert.ToInt16(x_curve)]);

            }
        }
        public void curve_90Degree(int x_offset, int y_offset, double grid)
        {
            double x_curve = 0;
            double y_curve = 0;

            for (x_curve = 0; x_curve <= grid; x_curve++)
            {
                y_curve = Math.Sqrt(Math.Pow(grid, 2) - Math.Pow(x_curve, 2));

                Line[] street = new Line[Convert.ToInt16(grid) + 1];
                street[Convert.ToInt16(x_curve)] = new Line() { Name = "street" + Convert.ToInt16(x_curve) };
                street[Convert.ToInt16(x_curve)].Stroke = Brushes.Gray;
                street[Convert.ToInt16(x_curve)].X1 = x_offset;
                street[Convert.ToInt16(x_curve)].X2 = x_offset + Convert.ToInt16(x_curve);
                street[Convert.ToInt16(x_curve)].Y1 = y_offset;
                street[Convert.ToInt16(x_curve)].Y2 = y_offset + Convert.ToInt16(y_curve); ;

                street[Convert.ToInt16(x_curve)].StrokeThickness = 2;
                myCanvas.Children.Add(street[Convert.ToInt16(x_curve)]);

            }
        }
        public void curve_180Degree(int x_offset, int y_offset, double grid)
        {
            double x_curve = 0;
            double y_curve = 0;

            for (x_curve = 0; x_curve <= grid; x_curve++)
            {
                y_curve = Math.Sqrt(Math.Pow(grid, 2) - Math.Pow(x_curve, 2));

                Line[] street = new Line[Convert.ToInt16(grid) + 1];
                street[Convert.ToInt16(x_curve)] = new Line() { Name = "street" + Convert.ToInt16(x_curve) };
                street[Convert.ToInt16(x_curve)].Stroke = Brushes.Gray;
                street[Convert.ToInt16(x_curve)].X1 = x_offset;
                street[Convert.ToInt16(x_curve)].X2 = x_offset +grid - Convert.ToInt16(x_curve);
                street[Convert.ToInt16(x_curve)].Y1 = y_offset;
                street[Convert.ToInt16(x_curve)].Y2 = y_offset - Convert.ToInt16(y_curve); ;

                street[Convert.ToInt16(x_curve)].StrokeThickness = 2;
                myCanvas.Children.Add(street[Convert.ToInt16(x_curve)]);

            }
        }
        public void curve_270Degree(int x_offset, int y_offset, double grid)
        {
            double x_curve = 0;
            double y_curve = 0;

            for (x_curve = 0; x_curve <= grid; x_curve++)
            {
                y_curve = Math.Sqrt(Math.Pow(grid, 2) - Math.Pow(x_curve, 2));

                Line[] street = new Line[Convert.ToInt16(grid) + 1];
                street[Convert.ToInt16(x_curve)] = new Line() { Name = "street" + Convert.ToInt16(x_curve) };
                street[Convert.ToInt16(x_curve)].Stroke = Brushes.Gray;
                street[Convert.ToInt16(x_curve)].X1 = x_offset;
                street[Convert.ToInt16(x_curve)].X2 = x_offset + grid - Convert.ToInt16(x_curve);
                street[Convert.ToInt16(x_curve)].Y1 = y_offset;
                street[Convert.ToInt16(x_curve)].Y2 = y_offset + Convert.ToInt16(y_curve); ;

                street[Convert.ToInt16(x_curve)].StrokeThickness = 2;
                myCanvas.Children.Add(street[Convert.ToInt16(x_curve)]);

            }
        }
    }
}
