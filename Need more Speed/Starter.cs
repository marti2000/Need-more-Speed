using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Need_more_Speed
{
    class Starter
    {
        private bool first_time = false;
        private bool ready = false;

        private double Grid;

        Menue Menue;
        Vehicle Car_player_1;
        Vehicle Car_player_2;
        Maps Map;
        MediaElement Backgroundsound;
        Canvas Racingtrack;
        TextBlock Countdown;

        public Starter(Menue menue, Vehicle car_player_1, Vehicle car_player_2, Maps map, MediaElement backgroundsound, Canvas racingtrack/*, TextBlock countdown*/, double grid)
        {
            Menue = menue;
            Car_player_1 = car_player_1;
            Car_player_2 = car_player_2;
            Map = map;
            Backgroundsound = backgroundsound;
            Racingtrack = racingtrack;
            Grid = grid;
            //Countdown = countdown;
            Countdown = new TextBlock();

            System.Windows.Threading.DispatcherTimer intervall_to_check = new System.Windows.Threading.DispatcherTimer();
            intervall_to_check.Tick += intervall_to_check_Tick;
            intervall_to_check.Interval = new TimeSpan(0, 0, 0, 0, 1);
            intervall_to_check.Start();
        }

        public bool Ready { get => ready; set => ready = value; }

        public async void Start()
        {
            Countdown.Visibility = System.Windows.Visibility.Visible;
            Canvas.SetLeft(Countdown, Grid * 5);
            Canvas.SetTop(Countdown, Grid * 3);
            Countdown.Foreground = Brushes.Red;
            Countdown.Text = "3";
            Countdown.FontSize = 100;

            for (int counter = 100; counter > 1; counter -= 3)
            {
                await Task.Delay(30);
                Countdown.FontSize = counter;
            }

            Countdown.Text = "2";
            Countdown.FontSize = 100;

            for (int counter = 100; counter > 1; counter -= 3)
            {
                await Task.Delay(30);
                Countdown.FontSize = counter;
            }

            Countdown.Text = "1";
            Countdown.FontSize = 100;

            for (int counter = 100; counter > 1; counter -= 3)
            {
                await Task.Delay(30);
                Countdown.FontSize = counter;
            }

            Ready = true;

            Countdown.Text = "Los";
            Countdown.FontSize = 100;

            for (int counter = 100; counter > 1; counter -= 3)
            {
                await Task.Delay(30);
                Countdown.FontSize = counter;
            }
            Countdown.Visibility = System.Windows.Visibility.Hidden;

        }

        private void intervall_to_check_Tick(object sender, EventArgs e)
        {
            if (Menue.Start_the_game)
            {
                if (first_time == false)
                {
                    Backgroundsound.Play();
                    Racingtrack.Children.Clear();
                    Map.chose_Map(Menue.Choseed_map, Grid);
                    Car_player_1.redraw();
                    Car_player_2.redraw();
                    Map.set_checkpoints(Car_player_1, Grid);
                    Map.set_checkpoints(Car_player_2, Grid);
                    Racingtrack.Children.Add(Countdown);
                    first_time = true;
                }
            }
            else if (!Menue.Start_the_game)
            {
                Backgroundsound.Pause();
                first_time = false;
            }

        }
    }
}
