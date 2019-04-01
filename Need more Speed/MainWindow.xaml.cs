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

        public const double Grid = 100; //To define the size of the Raceingtrack

        private bool first = false;

        //include the Cars global
        Vehicle red_car;
        Vehicle blue_car;
        Menue menue;

        //include the Map global
        Maps Map;


        public MainWindow()
        {
            InitializeComponent();

            //generate a Menu
            menue = new Menue();
            menue.Show();
            //while(menue.Start_the_game == false);

            Backgroundsound.LoadedBehavior = MediaState.Manual;
           

            //Generate the timer for the on the road check
            /*
             *
             * TODD move into a other class
             *
             */
            System.Windows.Threading.DispatcherTimer refresh = new System.Windows.Threading.DispatcherTimer();
            refresh.Tick += refresh_Tick;
            refresh.Interval = new TimeSpan(0, 0, 0, 0, 1);
            refresh.Start();

            //generate the Map
            Map = new Maps(racingtrack);
            Map.chose_Map(menue.Choseed_map, Grid);


            //Creating the different Cars for the Race
            red_car = new Vehicle("Car", 1, 145, 365, racingtrack, new TextBlock()/*Speed*/, Brushes.Red);
            red_car.Rotation = 270;

            blue_car = new Vehicle("Car", 2, 165, 365, racingtrack, new TextBlock(), Brushes.Blue);
            blue_car.Rotation = 270;


            //Testline for develop the rebounce
            Line line = new Line();
            line.Stroke = Brushes.Gray;
            line.StrokeThickness = 10;
            line.X1 = 1250;
            line.X2 = 1250;
            line.Y1 = 0;
            line.Y2 = 760;
            racingtrack.Children.Add(line);


        }

        /*
         * 
         * TODO Move the Key events (KeyDown and KeyUp) in a other Class
         * 
         */

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //Keys for Player 1
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

            //Keys for Player 2
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

            if(e.Key == Key.Escape)
            {
                menue.Visibility = Visibility.Visible;
                menue.Start_the_game = false;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            //Keys for Player 1
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

            //Keys for Player 2
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
            //endless loop of backgroundmusic
            Backgroundsound.Position = new TimeSpan(0);
            Backgroundsound.Play();
        }

        private void save_time(double time)
        {
            
        }

        private void refresh_Tick(object sender, EventArgs e)
        {
            //Check if the car is on the Road
            if (Map.car_on_road(red_car.Position_x, red_car.Position_y, Grid, red_car.Rotation) == true)
            {
                //Speed.Text = "ON Road";
                red_car.ON_ROAD = true;
            }
            else
            {
                //Speed.Text = "OFF Road";
                red_car.ON_ROAD = false;
            }

            if(Map.car_over_finish(red_car.Position_x, red_car.Position_y, Grid, red_car.Rotation))
            {
                if(red_car.On_finish == false)
                {
                    red_car.Round++;
                    red_car.On_finish = true;
                    Speed.Text = red_car.Round.ToString();
                }
            }
            else
            {
                red_car.On_finish = false;
            }

            if (Map.car_on_road(blue_car.Position_x, blue_car.Position_y, Grid, blue_car.Rotation) == true)
            {
                //Speed.Text = "ON Road";
                blue_car.ON_ROAD = true;
            }
            else
            {
                //Speed.Text = "OFF Road";
                blue_car.ON_ROAD = false;
            }

            if (menue.Start_the_game)
            {
                if(first == false)
                {
                    Backgroundsound.Play();
                    racingtrack.Children.Clear();
                    Map.chose_Map(menue.Choseed_map, Grid);
                    red_car.redraw();
                    blue_car.redraw();
                    first = true;
                }
            }
            else if(!menue.Start_the_game)
            {
                Backgroundsound.Pause();
                first = false;
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menue.Close();
        }
    }
}
