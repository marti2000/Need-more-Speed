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
        Vehicle car_player_1;
        Vehicle car_player_2;
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
            car_player_1 = new Vehicle("Car", 1, 145, 365, racingtrack, new TextBlock()/*Speed*/, Brushes.Red);
            car_player_1.Rotation = 270;

            car_player_2 = new Vehicle("Car", 2, 165, 365, racingtrack, new TextBlock(), Brushes.Blue);
            car_player_2.Rotation = 270;


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
                car_player_1.Up = true;
            }
            if (e.Key == Key.S)
            {
                car_player_1.Down = true;
            }
            if (e.Key == Key.A)
            {
                car_player_1.Left = true;
            }
            if (e.Key == Key.D)
            {
                car_player_1.Right = true;
            }

            //Keys for Player 2
            if (e.Key == Key.Up)
            {
                car_player_2.Up = true;
            }
            if (e.Key == Key.Down)
            {
                car_player_2.Down = true;
            }
            if (e.Key == Key.Left)
            {
                car_player_2.Left = true;
            }
            if (e.Key == Key.Right)
            {
                car_player_2.Right = true;
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
                car_player_1.Up = false;
            }
            if (e.Key == Key.S)
            {
                car_player_1.Down = false;
            }
            if (e.Key == Key.A)
            {
                car_player_1.Left = false;
            }
            if (e.Key == Key.D)
            {
                car_player_1.Right = false;
            }

            //Keys for Player 2
            if (e.Key == Key.Up)
            {
                car_player_2.Up = false;
            }
            if (e.Key == Key.Down)
            {
                car_player_2.Down = false;
            }
            if (e.Key == Key.Left)
            {
                car_player_2.Left = false;
            }
            if (e.Key == Key.Right)
            {
                car_player_2.Right = false;
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
            if (Map.car_on_road(car_player_1.Position_x, car_player_1.Position_y, Grid, car_player_1.Rotation) == true)
            {
                //Speed.Text = "ON Road";
                car_player_1.ON_ROAD = true;
            }
            else
            {
                //Speed.Text = "OFF Road";
                car_player_1.ON_ROAD = false;
            }

            if (Map.car_over_checkpoint(car_player_1.Position_x, car_player_1.Position_y, Grid, car_player_1.Rotation))
            {
                if ((car_player_1.On_checkpoint == false))
                {
                    car_player_1.checked_checkpoint(car_player_1.Position_x, car_player_1.Position_y, Grid);
                    car_player_1.On_checkpoint = true;
                }
            }
            else
            {
                car_player_1.On_checkpoint = false;
            }

            if((Map.car_over_finish(car_player_1.Position_x, car_player_1.Position_y, Grid, car_player_1.Rotation)) && (car_player_1.all_checkpoints() == true))
            {
                if((car_player_1.On_finish == false) )
                {
                    car_player_1.Round++;
                    car_player_1.On_finish = true;
                    car_player_1.clear_checkpoint();
                    Speed.Text = car_player_1.Round.ToString();
                }

            }
            else
            {
                car_player_1.On_finish = false;
            }

            if (Map.car_on_road(car_player_2.Position_x, car_player_2.Position_y, Grid, car_player_2.Rotation) == true)
            {
                //Speed.Text = "ON Road";
                car_player_2.ON_ROAD = true;
            }
            else
            {
                //Speed.Text = "OFF Road";
                car_player_2.ON_ROAD = false;
            }

            if (menue.Start_the_game)
            {
                if(first == false)
                {
                    Backgroundsound.Play();
                    racingtrack.Children.Clear();
                    Map.chose_Map(menue.Choseed_map, Grid);
                    car_player_1.redraw();
                    car_player_2.redraw();
                    Map.set_checkpoints(car_player_1, Grid);
                    Map.set_checkpoints(car_player_2, Grid);
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
