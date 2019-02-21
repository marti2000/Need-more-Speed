using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Dictionary<string, int> road_planner = new Dictionary<string, int>();

            road Road = new road();

            road_planner.Add("straight.horizontal", 1);
            road_planner.Add("straight.vertical", 2);
            road_planner.Add("curve.0Degree", 3);
            road_planner.Add("curve.90Degree", 4);
            road_planner.Add("curve.180Degree", 5);
            road_planner.Add("curve.270Degree", 6);

            int tester = road_planner["straight.horizontal"];
        }


    }
}
