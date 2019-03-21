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
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Vehicle red_car;
        public MainWindow()
        {
            InitializeComponent();

            Dictionary<string, int> road_planner = new Dictionary<string, int>();

            Draw_road Road = new Draw_road(racingtrack);
            Road.curve_0Degree(1, 1, 100);
            Road.curve_90Degree(2, 1, 100);
            Road.curve_180Degree(2, 2, 100);
            Road.curve_270Degree(1, 2, 100);

            Road.straight_horizontal(3, 3, 100);

            road_planner.Add("straight.horizontal", 1);
            road_planner.Add("straight.vertical", 2);
            road_planner.Add("curve.0Degree", 3);
            road_planner.Add("curve.90Degree", 4);
            road_planner.Add("curve.180Degree", 5);
            road_planner.Add("curve.270Degree", 6);

            red_car = new Vehicle("Car", 1, 100, 100, racingtrack);
            red_car.Rotation = 180;
            /*red_car.Position_x = 200;
            red_car.Position_y = 200;
            red_car.Left = true;
            red_car.Down = true;*/
            
           

            //int tester = road_planner["straight.horizontal"];

            /*for(int i = 0; i>10; i++)
            {
                Line[] street = new Line[10];
                street[i] = new Line() { Name = "street" + i };
                street[i].Stroke = Brushes.Gray;
                street[i].X1 = 1;
                street[i].X2 = 50;
                street[i].Y1 = 1;
                street[i].Y2 = 50;

                street[i].StrokeThickness = 2;
                racingtrack.Children.Add(street[i]);
            }*/


            /*SolidColorBrush street = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            Pen pen = new Pen(street, 10);
            Background. .DrawLine(pen, 20, 10, 300, 100);*/



            /*street.X1 = 10;
            street.X2 = 50;
            street.Y1 = 10;
            street.Y2 = 50;

            street.StrokeThickness = 2;
            racingtrack.Children.Add(street);*/
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                red_car.Up = true;
            }
            if (e.Key == Key.S)
            {
                red_car.Down = true;
            }
            if (e.Key == Key.A)
            {
                red_car.Left = true;
            }
            if (e.Key == Key.D)
            {
                red_car.Right = true;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                red_car.Up = false;
            }
            if (e.Key == Key.S)
            {
                red_car.Down = false;
            }
            if (e.Key == Key.A)
            {
                red_car.Left = false;
            }
            if (e.Key == Key.D)
            {
                red_car.Right = false;
            }
        }
    }
}
