﻿using System;
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

        Dictionary<Point, string> road_planner = new Dictionary<Point, string>();

        

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


        private void add_road(double x_position, double y_position, string type)
        {
            Point x_y_position = new Point();
            x_y_position.X = x_position;
            x_y_position.Y = y_position;
            road_planner.Add(x_y_position, type);
        }

        private void draw_road(double x_position, double y_position, double grid)
        {
            string type;
            road_planner.TryGetValue(new Point(x_position, y_position), out type);
            
            if(type == Straight_horizontal)
            {
                straight_horizontal(x_position, y_position, grid);
            }
            else if (type == Straight_vertical)
            {
                straight_vertical(x_position, y_position, grid);
            }
            else if (type == Straight_vertical_finish)
            {
                straight_vertical_finish(x_position, y_position, grid);
            }
            else if (type == Curve_0Degree)
            {
                curve_0Degree(x_position, y_position, grid);
            }
            else if (type == Curve_90Degree)
            {
                curve_90Degree(x_position, y_position, grid);
            }
            else if (type == Curve_180Degree)
            {
                curve_180Degree(x_position, y_position, grid);
            }
            else if (type == Curve_270Degree)
            {
                curve_270Degree(x_position, y_position, grid);
            }
            else if (type == Straight_vertical_checkpoint)
            {
                straight_vertical_checkpoint(x_position, y_position, grid);
            }
            else if(type == Straight_horizontal_checkpoint)
            {
                straight_horizontal_checkpoint(x_position, y_position, grid);
            }
        }
        
        public bool car_on_road(double x_position, double y_position, double grid, double rotation)
        {

            string road_type;
            road_planner.TryGetValue(new Point(Math.Truncate(x_position / grid), Math.Truncate(y_position / grid)), out road_type);
            if((road_type == Straight_horizontal) || (road_type == Straight_vertical) || (road_type == Straight_vertical_finish) || (road_type == Straight_horizontal_checkpoint) || (road_type == Straight_vertical_checkpoint))
            {
                return true;
            }
            else if ((road_type == Curve_0Degree) && ((grid - (y_position % grid)) < Math.Sqrt(Math.Pow(grid, 2) - Math.Pow((grid - (x_position % 100)), 2))))
            {
                return true;
            }
            else if((road_type == Curve_90Degree) && ((grid - (y_position % grid)) < Math.Sqrt(Math.Pow(grid,2) - Math.Pow(x_position % 100,2))))
            {
                return true;
            }
            else if ((road_type == Curve_180Degree) && ((y_position % grid) < Math.Sqrt(Math.Pow(grid, 2) - Math.Pow(x_position % 100, 2))))
            {
                return true;
            }
            else if((road_type == Curve_270Degree) && ((y_position % grid) < Math.Sqrt(Math.Pow(grid,2) - Math.Pow((grid - (x_position % grid)),2)))) // ((road_type == Curve_0Degree) && ((x_position % 100) > Math.Sqrt((grid * grid)-((y_position % 100)*(y_position % 100)))))
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

            string road_type;
            road_planner.TryGetValue(new Point(Math.Truncate(x_position / grid), Math.Truncate(y_position / grid)), out road_type);
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

            string road_type;
            road_planner.TryGetValue(new Point(Math.Truncate(x_position / grid), Math.Truncate(y_position / grid)), out road_type);
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
        }

        public void set_checkpoints(Vehicle car, double grid)
        {
            for (double X = 0; X < Screen_Width / grid; X++)
            {
                for (double Y = 0; Y < Screen_Height / grid; Y++)
                {
                    string road_type;
                    road_planner.TryGetValue(new Point(X , Y ), out road_type);
                    if ((road_type == Straight_horizontal_checkpoint) || (road_type == Straight_vertical_checkpoint))
                    {
                        car.add_checkpoint(X, Y);
                    }
                }
            }
        }

        public void chose_Map(int number, double gird)
        {
            switch(number)
            {
                case 0:
                    {
                        road_planner.Clear();

                        add_road(2, 1, Straight_horizontal);
                        add_road(3, 1, Straight_horizontal);
                        add_road(7, 1, Straight_horizontal);
                        add_road(8, 1, Straight_horizontal);
                        add_road(9, 1, Straight_horizontal);
                        add_road(10, 1, Straight_horizontal);
                        add_road(10, 5, Straight_horizontal);
                        add_road(6, 5, Straight_horizontal);
                        add_road(2, 5, Straight_horizontal);

                        add_road(11, 3, Straight_vertical);
                        add_road(11, 4, Straight_vertical);
                        add_road(9, 4, Straight_vertical);
                        add_road(7, 4, Straight_vertical);
                        add_road(1, 4, Straight_vertical);
                        add_road(1, 2, Straight_vertical);

                        add_road(1, 3, Straight_vertical_finish);

                        add_road(11, 2, Straight_vertical_checkpoint);

                        add_road(8, 3, Straight_horizontal_checkpoint);
                        add_road(5, 2, Straight_horizontal_checkpoint);
                        add_road(4, 4, Straight_horizontal_checkpoint);

                        add_road(1, 1, Curve_0Degree);
                        add_road(6, 1, Curve_0Degree);
                        add_road(7, 3, Curve_0Degree);
                        add_road(3, 4, Curve_0Degree);

                        add_road(4, 1, Curve_90Degree);
                        add_road(11, 1, Curve_90Degree);
                        add_road(9, 3, Curve_90Degree);
                        add_road(5, 4, Curve_90Degree);

                        add_road(6, 2, Curve_180Degree);
                        add_road(11, 5, Curve_180Degree);
                        add_road(7, 5, Curve_180Degree);
                        add_road(3, 5, Curve_180Degree);

                        add_road(4, 2, Curve_270Degree);
                        add_road(9, 5, Curve_270Degree);
                        add_road(5, 5, Curve_270Degree);
                        add_road(1, 5, Curve_270Degree);

                        for(double X = 0; X<Screen_Width/gird;X++)
                        {
                            for (double Y = 0; Y < Screen_Height / gird; Y++)
                            {
                                draw_road(X, Y, gird);
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        road_planner.Clear();

                        add_road(1, 2, Straight_vertical);

                        add_road(1, 3, Straight_vertical_finish);

                        add_road(1, 1, Curve_0Degree);

                        add_road(2, 1, Straight_horizontal);
                        add_road(3, 1, Straight_horizontal);
                        add_road(4, 1, Straight_horizontal);
                        add_road(5, 1, Straight_horizontal);
                        add_road(6, 1, Straight_horizontal);
                        add_road(7, 1, Straight_horizontal);
                        add_road(8, 1, Straight_horizontal);
                        add_road(9, 1, Straight_horizontal);
                        add_road(10, 1, Straight_horizontal);

                        add_road(11, 1, Curve_90Degree);

                        add_road(11, 2, Straight_vertical);
                        add_road(11, 3, Straight_vertical_checkpoint);
                        add_road(11, 4, Straight_vertical);

                        add_road(11, 5, Curve_180Degree);

                        add_road(10, 5, Straight_horizontal);
                        add_road(9, 5, Straight_horizontal);
                        add_road(8, 5, Straight_horizontal);
                        add_road(7, 5, Straight_horizontal);
                        add_road(6, 5, Straight_horizontal);
                        add_road(5, 5, Straight_horizontal);
                        add_road(4, 5, Straight_horizontal);
                        add_road(3, 5, Straight_horizontal);
                        add_road(2, 5, Straight_horizontal);

                        add_road(1, 5, Curve_270Degree);
                        add_road(1, 4, Straight_vertical);

                        for (double X = 0; X < Screen_Width / gird; X++)
                        {
                            for (double Y = 0; Y < Screen_Height / gird; Y++)
                            {
                                draw_road(X, Y, gird);
                            }
                        }

                        break;
                    }
                case 2:
                    {
                        road_planner.Clear();

                        add_road(1, 3, Straight_vertical_finish);

                        add_road(1, 2, Straight_vertical);
                        add_road(1, 1, Straight_vertical);
                        add_road(1, 0, Curve_0Degree);
                        add_road(2, 0, Straight_horizontal);
                        add_road(3, 0, Straight_horizontal);
                        add_road(4, 0, Straight_horizontal);
                        add_road(5, 0, Straight_horizontal);
                        add_road(6, 0, Straight_horizontal);
                        add_road(7, 0, Straight_horizontal);
                        add_road(8, 0, Straight_horizontal);
                        add_road(9, 0, Straight_horizontal);
                        add_road(10, 0, Straight_horizontal);
                        add_road(11, 0, Straight_horizontal);
                        add_road(12, 0, Curve_90Degree);
                        add_road(12, 1, Straight_vertical_checkpoint);
                        add_road(12, 2, Curve_180Degree);
                        add_road(11, 2, Straight_horizontal);
                        add_road(10, 2, Straight_horizontal);
                        add_road(9, 2, Straight_horizontal);
                        add_road(8, 2, Straight_horizontal);
                        add_road(7, 2, Straight_horizontal);
                        add_road(6, 2, Straight_horizontal);
                        add_road(5, 2, Straight_horizontal);
                        add_road(4, 2, Straight_horizontal);
                        add_road(3, 2, Straight_horizontal);
                        add_road(2, 2, Curve_0Degree);
                        add_road(2, 3, Straight_vertical_checkpoint);
                        add_road(2, 4, Curve_270Degree);
                        add_road(3, 4, Straight_horizontal);
                        add_road(4, 4, Straight_horizontal);
                        add_road(5, 4, Straight_horizontal);
                        add_road(6, 4, Straight_horizontal);
                        add_road(7, 4, Straight_horizontal);
                        add_road(8, 4, Straight_horizontal);
                        add_road(9, 4, Straight_horizontal);
                        add_road(10, 4, Straight_horizontal);
                        add_road(11, 4, Straight_horizontal);
                        add_road(12, 4, Curve_90Degree);
                        add_road(12, 5, Straight_vertical_checkpoint);
                        add_road(12, 6, Curve_180Degree);
                        add_road(11, 6, Straight_horizontal);
                        add_road(10, 6, Straight_horizontal);
                        add_road(9, 6, Straight_horizontal);
                        add_road(8, 6, Straight_horizontal);
                        add_road(7, 6, Straight_horizontal);
                        add_road(6, 6, Straight_horizontal);
                        add_road(5, 6, Straight_horizontal);
                        add_road(4, 6, Straight_horizontal);
                        add_road(3, 6, Straight_horizontal);
                        add_road(2, 6, Straight_horizontal);
                        add_road(1, 6, Curve_270Degree);
                        add_road(1, 5, Straight_vertical);
                        add_road(1, 4, Straight_vertical);

                        for (double X = 0; X < Screen_Width / gird; X++)
                        {
                            for (double Y = 0; Y < Screen_Height / gird; Y++)
                            {
                                draw_road(X, Y, gird);
                            }
                        }

                        break;
                    }
            }
        }
    }
}
