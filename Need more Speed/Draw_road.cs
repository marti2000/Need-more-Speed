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

        public void straight_horizontal(double x_offset, double y_offset, double grid)
        {
            x_offset = x_offset * grid;
            y_offset = y_offset * grid;

            Rectangle street = new Rectangle();
            street.Width = grid;
            street.Height = grid;
            street.Stroke = Brushes.Gray;
            street.Fill = Brushes.Gray;
            Canvas.SetTop(street, y_offset);
            Canvas.SetLeft(street, x_offset);
            myCanvas.Children.Add(street);
        }
        public void straight_vertical(double x_offset, double y_offset, double grid)
        {
            x_offset = x_offset * grid;
            y_offset = y_offset * grid;

            Rectangle street = new Rectangle();
            street.Width = grid;
            street.Height = grid;
            street.Stroke = Brushes.Gray;
            street.Fill = Brushes.Gray;
            Canvas.SetTop(street, y_offset);
            Canvas.SetLeft(street, x_offset);
            myCanvas.Children.Add(street);
        }
        public void curve_0Degree(double x_offset, double y_offset, double grid)
        {
            double x_curve = 0;
            double y_curve = 0;

            x_offset = x_offset * grid;
            y_offset = (y_offset * grid)+100;


            for (x_curve = 0; x_curve <= grid; x_curve++)
            {
                y_curve = Math.Sqrt(Math.Pow(grid, 2) - Math.Pow(x_curve, 2));

                Line[] street = new Line[Convert.ToInt16(grid) + 1];
                street[Convert.ToInt16(x_curve)] = new Line() { Name = "street" + Convert.ToInt16(x_curve) };
                street[Convert.ToInt16(x_curve)].Stroke = Brushes.Gray;
                street[Convert.ToInt16(x_curve)].X1 = x_offset + grid - Convert.ToInt16(x_curve);
                street[Convert.ToInt16(x_curve)].X2 = x_offset + grid - Convert.ToInt16(x_curve);
                street[Convert.ToInt16(x_curve)].Y1 = y_offset;
                street[Convert.ToInt16(x_curve)].Y2 = y_offset - Convert.ToInt16(y_curve); ;

                street[Convert.ToInt16(x_curve)].StrokeThickness = 2;
                myCanvas.Children.Add(street[Convert.ToInt16(x_curve)]);

            }
        }
        public void curve_90Degree(double x_offset, double y_offset, double grid)
        {
            double x_curve = 0;
            double y_curve = 0;

            x_offset = x_offset * grid;
            y_offset = (y_offset * grid)+100;

            for (x_curve = 0; x_curve <= grid; x_curve++)
            {
                y_curve = Math.Sqrt(Math.Pow(grid, 2) - Math.Pow(x_curve, 2));

                Line[] street = new Line[Convert.ToInt16(grid) + 1];
                street[Convert.ToInt16(x_curve)] = new Line() { Name = "street" + Convert.ToInt16(x_curve) };
                street[Convert.ToInt16(x_curve)].Stroke = Brushes.Gray;
                street[Convert.ToInt16(x_curve)].X1 = x_offset + Convert.ToInt16(x_curve); ;
                street[Convert.ToInt16(x_curve)].X2 = x_offset + Convert.ToInt16(x_curve);
                street[Convert.ToInt16(x_curve)].Y1 = y_offset;
                street[Convert.ToInt16(x_curve)].Y2 = y_offset - Convert.ToInt16(y_curve); ;

                street[Convert.ToInt16(x_curve)].StrokeThickness = 2;
                myCanvas.Children.Add(street[Convert.ToInt16(x_curve)]);

            }
        }
        public void curve_180Degree(double x_offset, double y_offset, double grid)
        {
            double x_curve = 0;
            double y_curve = 0;

            x_offset = x_offset * grid;
            y_offset = y_offset * grid;

            for (x_curve = 0; x_curve <= grid; x_curve++)
            {
                y_curve = Math.Sqrt(Math.Pow(grid, 2) - Math.Pow(x_curve, 2));

                Line[] street = new Line[Convert.ToInt16(grid) + 1];
                street[Convert.ToInt16(x_curve)] = new Line() { Name = "street" + Convert.ToInt16(x_curve) };
                street[Convert.ToInt16(x_curve)].Stroke = Brushes.Gray;
                street[Convert.ToInt16(x_curve)].X1 = x_offset + Convert.ToInt16(x_curve);
                street[Convert.ToInt16(x_curve)].X2 = x_offset + Convert.ToInt16(x_curve);
                street[Convert.ToInt16(x_curve)].Y1 = y_offset;
                street[Convert.ToInt16(x_curve)].Y2 = y_offset + Convert.ToInt16(y_curve); ;

                street[Convert.ToInt16(x_curve)].StrokeThickness = 2;
                myCanvas.Children.Add(street[Convert.ToInt16(x_curve)]);

            }
        }
        public void curve_270Degree(double x_offset, double y_offset, double grid)
        {
            double x_curve = 0;
            double y_curve = 0;

            x_offset = x_offset * grid;
            y_offset = y_offset * grid;

            for (x_curve = 0; x_curve <= grid; x_curve++)
            {
                y_curve = Math.Sqrt(Math.Pow(grid, 2) - Math.Pow(x_curve, 2));

                Line[] street = new Line[Convert.ToInt16(grid) + 1];
                street[Convert.ToInt16(x_curve)] = new Line() { Name = "street" + Convert.ToInt16(x_curve) };
                street[Convert.ToInt16(x_curve)].Stroke = Brushes.Gray;
                street[Convert.ToInt16(x_curve)].X1 = x_offset + grid - Convert.ToInt16(x_curve);
                street[Convert.ToInt16(x_curve)].X2 = x_offset + grid - Convert.ToInt16(x_curve);
                street[Convert.ToInt16(x_curve)].Y1 = y_offset;
                street[Convert.ToInt16(x_curve)].Y2 = y_offset + Convert.ToInt16(y_curve); ;

                street[Convert.ToInt16(x_curve)].StrokeThickness = 2;
                myCanvas.Children.Add(street[Convert.ToInt16(x_curve)]);

            }
        }
    }
}
