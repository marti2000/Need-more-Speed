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
using System.Media;

namespace Need_more_Speed
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public const double Grid = 100;

        Vehicle red_car;
        Vehicle blue_car;

        Maps Map;


        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Threading.DispatcherTimer refresh = new System.Windows.Threading.DispatcherTimer();
            refresh.Tick += refresh_Tick;
            refresh.Interval = new TimeSpan(0, 0, 0, 0, 1);
            refresh.Start();

            Dictionary<string, Draw_road> road_planner = new Dictionary<string, Draw_road>();

            Draw_road Road = new Draw_road(racingtrack);

            Map = new Maps(racingtrack);
            Map.chose_Map(0, Grid);

            MediaElement background_sound = new MediaElement();

            Backgroundsound.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            Backgroundsound.Play();
            
            //Backgroundsound.

            //Path source_background_sound = new Path();


            /*string startPath = @"C:\Benutzer\";//Der absolute Ausgangspfad
            string relative = @"..\Windows\explorer.exe";//Der relative Pfad
            string st4ring = @"..\Windows\explorer.exe";//Der relative Pfad
            string absolut = Path.GetFullPath(Path.Combine(startPath, relative));//Die ermittlung eines absoluten Pfades*/

            background_sound.Source = new Uri("Need-more-Speed/Julien Bam - Ready to fight(prod. by Vincent Lee).mp3", UriKind.Relative); //@"C:\Users\Marcel Vögeli\source\repos\marti2000\Need-more-Speed";//"..//Need-more-Speed//Julien Bam - Ready to fight(prod. by Vincent Lee).mp3";

            background_sound.LoadedBehavior = System.Windows.Controls.MediaState.Manual;

            background_sound.Volume = 100;

            background_sound.Play();

            Uri source = new Uri(@"Need-more-Speed/Julien Bam - Ready to fight(prod. by Vincent Lee).mp3", UriKind.Relative);



            MediaElement test = new MediaElement();
            test.Source = new Uri(@"C:\Users\Marcel Vögeli\source\repos\marti2000\Need-more-Speed\Julien Bam - Ready to fight(prod. by Vincent Lee).mp3");//@"C:\Users\Marcel Vögeli\source\repos\marti2000\Need-more-Speed\Julien Bam - Ready to fight(prod. by Vincent Lee).mp3";
            //(new Uri("Need-more-Speed/Julien Bam - Ready to fight(prod. by Vincent Lee).mp3", UriKind.RelativeOrAbsolute)/*new Uri(source.AbsoluteUri)*/);
            //Path.GetFullPath((new Uri(absolute_path)).LocalPath);
            //test.Load();
            test.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            test.Play();
            /*
            Road.curve_0Degree(1, 1, 100);
            Road.curve_90Degree(2, 1, 100);
            Road.curve_180Degree(2, 2, 100);
            Road.curve_270Degree(1, 2, 100);

            Road.straight_horizontal(3, 3, 100);
            */
            road_planner.Add("straight.horizontal", Road); 
            road_planner.Add("straight.vertical", Road);
            road_planner.Add("curve.0Degree", Road);
            road_planner.Add("curve.90Degree", Road);
            road_planner.Add("curve.180Degree", Road);
            road_planner.Add("curve.270Degree", Road);

            red_car = new Vehicle("Car", 1, 145, 365, racingtrack, new TextBlock()/*Speed*/, Brushes.Red);
            red_car.Rotation = 270;

            blue_car = new Vehicle("Car", 2, 165, 365, racingtrack, new TextBlock(), Brushes.Blue);
            blue_car.Rotation = 270;
            /*red_car.Position_x = 200;
            red_car.Position_y = 200;
            red_car.Left = true;
            red_car.Down = true;*/
            
                
                Line line= new Line();
                line.Stroke = Brushes.Gray;
                line.StrokeThickness = 10;
                line.X1 = 1250;
                line.X2 = 1250;
                line.Y1 = 0;
                line.Y2 = 760;
                racingtrack.Children.Add(line);


            //int tester = road_planner["straight.horizontal"];
            /*
            for(int i = 0; i>10; i++)
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

            if (e.Key == Key.Up)
            {
                blue_car.Up = true;
            }
            if (e.Key == Key.Down)
            {
                blue_car.Down = true;
            }
            if (e.Key == Key.Left)
            {
                blue_car.Left = true;
            }
            if (e.Key == Key.Right)
            {
                blue_car.Right = true;
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

            if (e.Key == Key.Up)
            {
                blue_car.Up = false;
            }
            if (e.Key == Key.Down)
            {
                blue_car.Down = false;
            }
            if (e.Key == Key.Left)
            {
                blue_car.Left = false;
            }
            if (e.Key == Key.Right)
            {
                blue_car.Right = false;
            }
        }

        private void Backgroundsound_MediaEnded(object sender, RoutedEventArgs e)
        {
            Backgroundsound.Position = new TimeSpan(0);
            Backgroundsound.Play();
        }

        private void refresh_Tick(object sender, EventArgs e)
        {           
            if(Map.car_on_road(red_car.Position_x, red_car.Position_y, Grid, red_car.Rotation) == true)
            {
                Speed.Text = "ON Road";
            }
            else
            {
                Speed.Text = "OFF Road";
            }
        }
    }
}
