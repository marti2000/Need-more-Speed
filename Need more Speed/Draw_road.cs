using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Need_more_Speed
{
    class Draw_road
    {

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



            }


        }
        public void curve_90Degree(int x, int y)
        {

        }
        public void curve_180Degree(int x, int y)
        {

        }
        public void curve_270Degree(int x, int y)
        {

        }
    }
}
