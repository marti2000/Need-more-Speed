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
    class Straight_vertical_finish : Straight_vertical
    {
        public Straight_vertical_finish(Canvas myCanvas) : base(myCanvas)
        {

        }

        public override string get_type()
        {
            return "straight_vertical_finish";
        }

        public override void draw(double x_offset, double y_offset, double grid)
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
            double zaehler;
            for (zaehler = 0; zaehler < 10; zaehler++)
            {
                Rectangle[] finish_line_black = new Rectangle[Convert.ToInt16(grid / 10) + 10];
                Rectangle[] finish_line_white = new Rectangle[Convert.ToInt16(grid / 10) + 10];


                finish_line_black[Convert.ToInt16(zaehler)] = new Rectangle() { Name = "finish_line_black" + Convert.ToInt16(zaehler) };

                finish_line_black[Convert.ToInt16(zaehler)].Height = grid / 10;
                finish_line_black[Convert.ToInt16(zaehler)].Width = grid / 10;

                finish_line_black[Convert.ToInt16(zaehler)].Stroke = Brushes.Black;
                finish_line_black[Convert.ToInt16(zaehler)].Fill = Brushes.Black;


                finish_line_white[Convert.ToInt16(zaehler)] = new Rectangle() { Name = "finish_line_white" + Convert.ToInt16(zaehler) };

                finish_line_white[Convert.ToInt16(zaehler)].Height = grid / 10;
                finish_line_white[Convert.ToInt16(zaehler)].Width = grid / 10;

                finish_line_white[Convert.ToInt16(zaehler)].Stroke = Brushes.White;
                finish_line_white[Convert.ToInt16(zaehler)].Fill = Brushes.White;

                if (zaehler % 2 == 0)
                {
                    Canvas.SetTop(finish_line_black[Convert.ToInt16(zaehler)], y_offset + grid / 2);
                    Canvas.SetTop(finish_line_white[Convert.ToInt16(zaehler)], y_offset + grid / 2 - grid / 10);
                }
                else
                {
                    Canvas.SetTop(finish_line_black[Convert.ToInt16(zaehler)], y_offset + grid / 2 - grid / 10);
                    Canvas.SetTop(finish_line_white[Convert.ToInt16(zaehler)], y_offset + grid / 2);
                }

                Canvas.SetLeft(finish_line_black[Convert.ToInt16(zaehler)], x_offset + (zaehler * (grid / 10)));
                Canvas.SetLeft(finish_line_white[Convert.ToInt16(zaehler)], x_offset + (zaehler * (grid / 10)));

                myCanvas.Children.Add(finish_line_black[Convert.ToInt16(zaehler)]);
                myCanvas.Children.Add(finish_line_white[Convert.ToInt16(zaehler)]);
            }
        }
    }
}
