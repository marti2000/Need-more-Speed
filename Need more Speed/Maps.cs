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
    class Maps : Draw_road
    {
        private Canvas myCanvas;

        //Dictionary<Point, string> road_planner = new Dictionary<Point, string>();

        //Dictionary<double, > testing = new Dictionary<double, Dictionary>
        Dictionary<Point, Draw_road> road_planner = new Dictionary<Point, Draw_road>();



        public double Screen_Width = System.Windows.SystemParameters.PrimaryScreenWidth;
        public double Screen_Height = System.Windows.SystemParameters.PrimaryScreenHeight;

        public const string Straight_horizontal = "straight_horizontal";
        public const string Straight_vertical = "straight_vertical";
        public const string Straight_vertical_finish = "straight_vertical_finish";
        public const string Curve_0Degree = "curve_0Degree";
        public const string Curve_90Degree = "curve_90Degree";
        public const string Curve_180Degree = "curve_180Degree";
        public const string Curve_270Degree = "curve_270Degree";
        public const string Straight_vertical_checkpoint = "straight_vertical_checkpoint";
        public const string Straight_horizontal_checkpoint = "straight_horizontal_checkpoint";


        public Maps(Canvas myCanvas) : base (myCanvas)
        {
            this.myCanvas = myCanvas;
        }
        
        public bool car_on_road(double x_position, double y_position, double grid, double rotation)
        {
                Draw_road road_segment;
                string road_type = "";
                road_planner.TryGetValue(new Point(Math.Truncate(x_position / grid), Math.Truncate(y_position / grid)), out road_segment);
                if(road_segment != null)
                {
                    road_type = road_segment.get_type();
                }
                if ((road_type == Straight_horizontal) || (road_type == Straight_vertical) || (road_type == Straight_vertical_finish) || (road_type == Straight_horizontal_checkpoint) || (road_type == Straight_vertical_checkpoint))
                {
                    return true;
                }
                else if ((road_type == Curve_0Degree) && ((grid - (y_position % grid)) < Math.Sqrt(Math.Pow(grid, 2) - Math.Pow((grid - (x_position % 100)), 2))))
                {
                    return true;
                }
                else if ((road_type == Curve_90Degree) && ((grid - (y_position % grid)) < Math.Sqrt(Math.Pow(grid, 2) - Math.Pow(x_position % 100, 2))))
                {
                    return true;
                }
                else if ((road_type == Curve_180Degree) && ((y_position % grid) < Math.Sqrt(Math.Pow(grid, 2) - Math.Pow(x_position % 100, 2))))
                {
                    return true;
                }
                else if ((road_type == Curve_270Degree) && ((y_position % grid) < Math.Sqrt(Math.Pow(grid, 2) - Math.Pow((grid - (x_position % grid)), 2)))) // ((road_type == Curve_0Degree) && ((x_position % 100) > Math.Sqrt((grid * grid)-((y_position % 100)*(y_position % 100)))))
                {
                    double Out_value = Math.Sqrt((grid * grid) - ((grid - (y_position % grid)) * (grid - (y_position % grid))));
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public bool car_over_finish(double x_position, double y_position, double grid, double rotation)
        {
                Draw_road road_segment;
                string road_type = "";
                road_planner.TryGetValue(new Point(Math.Truncate(x_position / grid), Math.Truncate(y_position / grid)), out road_segment);
                if (road_segment != null)
                {
                    road_type = road_segment.get_type();
                }
                if ((road_type == Straight_vertical_finish) && ((y_position % grid) < (grid / 2)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public bool car_over_checkpoint(double x_position, double y_position, double grid, double rotation)
        {
            Draw_road road_segment;
            string road_type = "";

            road_planner.TryGetValue(new Point(Math.Truncate(x_position / grid), Math.Truncate(y_position / grid)), out road_segment);
            if (road_segment != null)
            {
                road_type = road_segment.get_type();
            }
            if ((road_type == Straight_vertical_checkpoint) && ((y_position % grid) < (grid / 2)))
            {
                return true;
            }
            else if ((road_type == Straight_horizontal_checkpoint) && ((x_position % grid) < (grid / 2)))
            {
                return true;
            }
            else
            {
                return false;
            }
            /*
            Draw_road road_segment;
            string road_type = "";
            road_planner.TryGetValue(new Point(Math.Truncate(x_position / grid), Math.Truncate(y_position / grid)), out road_segment);
            road_type = road_segment.get_type();
            if ((road_type == Straight_vertical_checkpoint) && ((y_position % grid) < (grid / 2)))
            {
                return true;
            }
            else if ((road_type == Straight_horizontal_checkpoint) && ((x_position % grid) < (grid / 2)))
            {
                return true;
            }
            else
            {
                return false;
            }*/
        }

        public void set_checkpoints(Vehicle car, double grid)
        {
            string road_type;
            foreach (var point_in_dictionary in road_planner.Keys.ToArray())
            {
                road_type = road_planner[point_in_dictionary].get_type();
                if ((road_type == Straight_horizontal_checkpoint) || (road_type == Straight_vertical_checkpoint))
                {
                    car.add_checkpoint(point_in_dictionary.X, point_in_dictionary.Y);
                }
            }
            /*for (double X = 0; X < Screen_Width / grid; X++)
            {
                for (double Y = 0; Y < Screen_Height / grid; Y++)
                {
                    Draw_road road_segment;
                    //string road_type = "";
                    road_planner.TryGetValue(new Point(X , Y ), out road_segment);
                    road_type = road_segment.get_type();
                    if ((road_type == Straight_horizontal_checkpoint) || (road_type == Straight_vertical_checkpoint))
                    {
                        car.add_checkpoint(X, Y);
                    }
                }
            }*/
        }

        public void chose_Map(int number, double gird)
        {
            switch(number)
            {
                case 0:
                    {
                        road_planner.Clear();

                        road_planner.Add(new Point(2, 1), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(3, 1), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(7, 1), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(8, 1), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(9, 1), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(10, 1), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(10, 5), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(6, 5), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(2, 5), new Straight_hotizontal(myCanvas));

                        road_planner.Add(new Point(11, 3), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(11, 4), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(9, 4), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(7, 4), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(1, 4), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(1, 2), new Straight_vertical(myCanvas));

                        road_planner.Add(new Point(1, 3), new Straight_vertical_finish(myCanvas));

                        road_planner.Add(new Point(11, 2), new Straight_vertical_checkpoint(myCanvas));

                        road_planner.Add(new Point(8, 3), new Straight_hotizontal_checkpoint(myCanvas));
                        road_planner.Add(new Point(5, 2), new Straight_hotizontal_checkpoint(myCanvas));
                        road_planner.Add(new Point(4, 4), new Straight_hotizontal_checkpoint(myCanvas));

                        road_planner.Add(new Point(1, 1), new Curve0degree(myCanvas));
                        road_planner.Add(new Point(6, 1), new Curve0degree(myCanvas));
                        road_planner.Add(new Point(7, 3), new Curve0degree(myCanvas));
                        road_planner.Add(new Point(3, 4), new Curve0degree(myCanvas));

                        road_planner.Add(new Point(4, 1), new Curve90degree(myCanvas));
                        road_planner.Add(new Point(11, 1), new Curve90degree(myCanvas));
                        road_planner.Add(new Point(9, 3), new Curve90degree(myCanvas));
                        road_planner.Add(new Point(5, 4), new Curve90degree(myCanvas));

                        road_planner.Add(new Point(6, 2), new Curve180degree(myCanvas));
                        road_planner.Add(new Point(11, 5), new Curve180degree(myCanvas));
                        road_planner.Add(new Point(7, 5), new Curve180degree(myCanvas));
                        road_planner.Add(new Point(3, 5), new Curve180degree(myCanvas));

                        road_planner.Add(new Point(4, 2), new Curve270degree(myCanvas));
                        road_planner.Add(new Point(9, 5), new Curve270degree(myCanvas));
                        road_planner.Add(new Point(5, 5), new Curve270degree(myCanvas));
                        road_planner.Add(new Point(1, 5), new Curve270degree(myCanvas));

                        break;
                    }
                case 1:
                    { 
                        road_planner.Clear();

                        road_planner.Add(new Point(1, 2), new Straight_vertical(myCanvas));

                        road_planner.Add(new Point(1, 3), new Straight_vertical_finish(myCanvas));

                        road_planner.Add(new Point(1, 1), new Curve0degree(myCanvas));

                        road_planner.Add(new Point(2, 1), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(3, 1), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(4, 1), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(5, 1), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(6, 1), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(7, 1), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(8, 1), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(9, 1), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(10, 1), new Straight_hotizontal(myCanvas));

                        road_planner.Add(new Point(11, 1), new Curve90degree(myCanvas));

                        road_planner.Add(new Point(11, 2), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(11, 3), new Straight_vertical_checkpoint(myCanvas));
                        road_planner.Add(new Point(11, 4), new Straight_vertical(myCanvas));

                        road_planner.Add(new Point(11, 5), new Curve180degree(myCanvas));

                        road_planner.Add(new Point(10, 5), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(9, 5), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(8, 5), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(7, 5), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(6, 5), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(5, 5), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(4, 5), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(3, 5), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(2, 5), new Straight_hotizontal(myCanvas));

                        road_planner.Add(new Point(1, 5), new Curve270degree(myCanvas));
                        road_planner.Add(new Point(1, 4), new Straight_vertical(myCanvas));

                        break;
                    }
                case 2:
                    {
                        road_planner.Clear();

                        road_planner.Add(new Point(1, 3), new Straight_vertical_finish(myCanvas));

                        road_planner.Add(new Point(1, 2), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(1, 1), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(1, 0), new Curve0degree(myCanvas));
                        road_planner.Add(new Point(2, 0), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(3, 0), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(4, 0), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(5, 0), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(6, 0), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(7, 0), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(8, 0), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(9, 0), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(10, 0), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(11, 0), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(12, 0), new Curve90degree(myCanvas));
                        road_planner.Add(new Point(12, 1), new Straight_vertical_checkpoint(myCanvas));
                        road_planner.Add(new Point(12, 2), new Curve180degree(myCanvas));
                        road_planner.Add(new Point(11, 2), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(10, 2), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(9, 2), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(8, 2), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(7, 2), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(6, 2), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(5, 2), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(4, 2), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(3, 2), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(2, 2), new Curve0degree(myCanvas));
                        road_planner.Add(new Point(2, 3), new Straight_vertical_checkpoint(myCanvas));
                        road_planner.Add(new Point(2, 4), new Curve270degree(myCanvas));
                        road_planner.Add(new Point(3, 4), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(4, 4), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(5, 4), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(6, 4), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(7, 4), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(8, 4), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(9, 4), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(10, 4), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(11, 4), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(12, 4), new Curve90degree(myCanvas));
                        road_planner.Add(new Point(12, 5), new Straight_vertical_checkpoint(myCanvas));
                        road_planner.Add(new Point(12, 6), new Curve180degree(myCanvas));
                        road_planner.Add(new Point(11, 6), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(10, 6), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(9, 6), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(8, 6), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(7, 6), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(6, 6), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(5, 6), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(4, 6), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(3, 6), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(2, 6), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(1, 6), new Curve270degree(myCanvas));
                        road_planner.Add(new Point(1, 5), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(1, 4), new Straight_vertical(myCanvas));

                        break;
                    }
                case 3:
                    {
                        road_planner.Clear();

                        road_planner.Add(new Point(1, 3), new Straight_vertical_finish(myCanvas));

                        road_planner.Add(new Point(1, 2), new Curve0degree(myCanvas));
                        road_planner.Add(new Point(2, 2), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(3, 2), new Curve90degree(myCanvas));
                        road_planner.Add(new Point(3, 3), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(3, 4), new Curve270degree(myCanvas));
                        road_planner.Add(new Point(4, 4), new Straight_hotizontal_checkpoint(myCanvas));
                        road_planner.Add(new Point(5, 4), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(6, 4), new Curve180degree(myCanvas));
                        road_planner.Add(new Point(6, 3), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(6, 2), new Curve90degree(myCanvas));
                        road_planner.Add(new Point(5, 2), new Curve270degree(myCanvas));
                        road_planner.Add(new Point(5, 1), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(5, 0), new Curve0degree(myCanvas));
                        road_planner.Add(new Point(6, 0), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(7, 0), new Straight_hotizontal_checkpoint(myCanvas));
                        road_planner.Add(new Point(8, 0), new Curve90degree(myCanvas));
                        road_planner.Add(new Point(8, 1), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(8, 2), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(8, 3), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(8, 4), new Straight_vertical_checkpoint(myCanvas));
                        road_planner.Add(new Point(8, 5), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(8, 6), new Curve180degree(myCanvas));
                        road_planner.Add(new Point(7, 6), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(6, 6), new Straight_hotizontal_checkpoint(myCanvas));
                        road_planner.Add(new Point(5, 6), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(4, 6), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(3, 6), new Straight_hotizontal(myCanvas));
                        road_planner.Add(new Point(2, 6), new Straight_hotizontal_checkpoint(myCanvas));
                        road_planner.Add(new Point(1, 6), new Curve270degree(myCanvas));
                        road_planner.Add(new Point(1, 5), new Straight_vertical(myCanvas));
                        road_planner.Add(new Point(1, 4), new Straight_vertical(myCanvas));

                        break;
                    }
            }

            foreach (var point_in_dictionary in road_planner.Keys.ToArray())
            {
                road_planner[point_in_dictionary].draw(point_in_dictionary.X, point_in_dictionary.Y, gird);
            }

        }
    }
}
