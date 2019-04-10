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
        public Canvas myCanvas;

        public Draw_road(Canvas myCanvas)
        {
            this.myCanvas = myCanvas;
        }

        public virtual void draw(double x_offset, double y_offset, double grid)
        {

        }

        public virtual string get_type()
        {
            return "road";
        }
    }
}
//build by Timo