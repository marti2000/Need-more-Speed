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
    class Straight_hotizontal_finish :Straight_hotizontal 
    {
        public Straight_hotizontal_finish(Canvas myCanvas) : base(myCanvas)
        {

        }

        public override string get_type()
        {
            return "straight_horizontal_finish";
        }

        public override void draw(double x_offset, double y_offset, double grid)
        {
            //comming soon
        }
    }
}
//build by Timo