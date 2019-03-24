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

        public const string Straight_horizontal = "straight_horizontal";
        public const string Straight_vertical = "straight_vertical";
        public const string Straight_vertical_finish = "straight_vertical_finish";
        public const string Curve_0Degree = "curve_0Degree";
        public const string Curve_90Degree = "curve_90Degree";
        public const string Curve_180Degree = "curve_180Degree";
        public const string Curve_270Degree = "curve_270Degree";


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
            switch()//road_planner.TryGetValue(new Point(x_position, y_position), out type))
            {
                case 1:
                    {

                        break;
                    }
            }
        }

        public void chose_Map(int number, int gird)
        {
            switch(number)
            {
                case 0:
                    {
                        //Draw_road Road = new Draw_road(racingtrack);

                        add_road(2, 1, Straight_horizontal);
                        add_road(3, 1, Straight_horizontal);
                        add_road(5, 1, Straight_horizontal);
                        add_road(7, 1, Straight_horizontal);
                        add_road(8, 1, Straight_horizontal);
                        add_road(9, 1, Straight_horizontal);
                        add_road(10, 1, Straight_horizontal);
                        add_road(10, 5, Straight_horizontal);
                        add_road(8, 3, Straight_horizontal);
                        add_road(6, 5, Straight_horizontal);
                        add_road(4, 4, Straight_horizontal);
                        add_road(2, 5, Straight_horizontal);

                        add_road(11, 2, Straight_vertical);
                        add_road(11, 3, Straight_vertical);
                        add_road(11, 4, Straight_vertical);
                        add_road(9, 4, Straight_vertical);
                        add_road(7, 4, Straight_vertical);
                        add_road(1, 4, Straight_vertical);
                        add_road(1, 2, Straight_vertical);
                        add_road(1, 1, Straight_vertical);

                        add_road(1, 3, Straight_vertical_finish);

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

                        /*
                        straight_horizontal(2, 1, gird);
                        straight_horizontal(3, 1, gird);
                        straight_horizontal(5, 2, gird);
                        straight_horizontal(7, 1, gird);
                        straight_horizontal(8, 1, gird);
                        straight_horizontal(9, 1, gird);
                        straight_horizontal(10, 1, gird);
                        straight_horizontal(10, 5, gird);
                        straight_horizontal(8, 3, gird);
                        straight_horizontal(6, 5, gird);
                        straight_horizontal(4, 4, gird);
                        straight_horizontal(2, 5, gird);

                        straight_vertical(11, 2, gird);
                        straight_vertical(11, 3, gird);
                        straight_vertical(11, 4, gird);
                        straight_vertical(9, 4, gird);
                        straight_vertical(7, 4, gird);
                        straight_vertical(1, 4, gird);
                        //straight_vertical(1, 3, gird);
                        straight_vertical_finish(1, 3, gird);
                        straight_vertical(1, 2, gird);

                        curve_0Degree(1, 1, gird);
                        curve_0Degree(6, 1, gird);
                        curve_0Degree(7, 3, gird);
                        curve_0Degree(3, 4, gird);

                        curve_90Degree(4, 1, gird);
                        curve_90Degree(11, 1, gird);
                        curve_90Degree(9, 3, gird);
                        curve_90Degree(5, 4, gird);

                        curve_180Degree(6, 2, gird);
                        curve_180Degree(11, 5, gird);
                        curve_180Degree(7, 5, gird);
                        curve_180Degree(3, 5, gird);

                        curve_270Degree(4, 2, gird);
                        curve_270Degree(9, 5, gird);
                        curve_270Degree(5, 5, gird);
                        curve_270Degree(1, 5, gird);
                        */

                        break;
                    }
                case 1:
                    {
                        break;
                    }
            }
        }
    }
}
