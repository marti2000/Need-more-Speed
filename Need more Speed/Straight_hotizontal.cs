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
    class Straight_hotizontal : Straight 
    {
        /*public Straight_hotizontal()
        {
        }*/

        public Straight_hotizontal(Canvas myCanvas) : base(myCanvas)
        {

        }

        public void draw(double x_offset, double y_offset, double grid)
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
    }
}
