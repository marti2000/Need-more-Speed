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

        //public const 

        public Maps(Canvas myCanvas) : base (myCanvas)
        {
            this.myCanvas = myCanvas;
        }

        public void chose_Map(int number, int gird)
        {
            switch(number)
            {
                case 0:
                    {
                        //Draw_road Road = new Draw_road(racingtrack);


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
