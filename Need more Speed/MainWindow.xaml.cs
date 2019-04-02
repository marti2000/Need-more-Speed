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

        //include the Cars global
        Vehicle car_player_1;
        Vehicle car_player_2;

        //incude the Rounds Manager global
        manage_Rounds rounds_player_1;
        manage_Rounds rounds_player_2;

        //include the Menue global
        Menue menue;

        //include the Map global
        Maps Map;

        //include the Starter global
        Starter Start;

        public MainWindow()
        {
            InitializeComponent();

            //generate a Menu
            menue = new Menue();
            menue.Show();

            //switch the Controll of the Backgroundsound to Manuel
            Backgroundsound.LoadedBehavior = MediaState.Manual;

            //generate the Map
            Map = new Maps(racingtrack);
            Map.chose_Map(menue.Choseed_map, Grid);

            //Creating the different Cars for the Race
            car_player_1 = new Vehicle("Car", 1, 145, 365, racingtrack, Brushes.Red, Grid);
            car_player_1.Rotation = 270;

            car_player_2 = new Vehicle("Car", 2, 165, 365, racingtrack, Brushes.Blue, Grid);
            car_player_2.Rotation = 270;

            //Creating the Starter for the Game
            Start = new Starter(menue, car_player_1, car_player_2, Map, Backgroundsound, racingtrack, Grid);

            //Creating the Overwatch for the Stuff around the Rounds
            rounds_player_1 = new manage_Rounds(car_player_1, Map, racingtrack, Start, menue ,Grid);
            rounds_player_2 = new manage_Rounds(car_player_2, Map, racingtrack, Start, menue, Grid);

            

            
            menue.Starter = Start;



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
            if(Start.Ready)
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
            }
            //For the Ingame Menue 
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menue.Close();
        }
    }
}
