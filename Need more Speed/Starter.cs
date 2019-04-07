using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Need_more_Speed
{
    internal class Starter
    {
        private bool first_time = false;
        private bool ready = false;
        private bool in_start_sequenze = false;

        private double Grid;

        private TextBlock rounds_player_1;
        private TextBlock rounds_player_2;

        Menue Menue;
        Vehicle Car_player_1;
        Vehicle Car_player_2;
        Maps Map;
        MediaElement Backgroundsound;
        Canvas Racingtrack;
        TextBlock Countdown;

        public Starter(Menue menue, Vehicle car_player_1, Vehicle car_player_2, Maps map, MediaElement backgroundsound, Canvas racingtrack, double grid)
        {
            Menue = menue;
            Car_player_1 = car_player_1;
            Car_player_2 = car_player_2;
            Map = map;
            Backgroundsound = backgroundsound;
            Racingtrack = racingtrack;
            Grid = grid;

            Countdown = new TextBlock();

            Rounds_player_1 = new TextBlock();
            Rounds_player_2 = new TextBlock();

            System.Windows.Threading.DispatcherTimer intervall_to_check = new System.Windows.Threading.DispatcherTimer();
            intervall_to_check.Tick += intervall_to_check_Tick;
            intervall_to_check.Interval = new TimeSpan(0, 0, 0, 0, 1);
            intervall_to_check.Start();
        }

        public bool Ready { get => ready; set => ready = value; }
        public TextBlock Rounds_player_1 { get => rounds_player_1; set => rounds_player_1 = value; }
        public TextBlock Rounds_player_2 { get => rounds_player_2; set => rounds_player_2 = value; }
        public bool In_start_sequenze { get => in_start_sequenze; set => in_start_sequenze = value; }

        public async void Start()
        {
            ready = false;

            in_start_sequenze = true;

            Car_player_1.reset_position();
            Car_player_2.reset_position();

            Car_player_1.Up = false;
            Car_player_1.Down = false;
            Car_player_1.Right = false;
            Car_player_1.Left = false;

            Car_player_2.Up = false;
            Car_player_2.Down = false;
            Car_player_2.Right = false;
            Car_player_2.Left = false;

            //Racingtrack.Children.Clear();

            //Car_player_1.redraw();
            //Car_player_2.redraw();

            Countdown.Visibility = System.Windows.Visibility.Visible;
            Canvas.SetLeft(Countdown, Grid * 5);
            Canvas.SetTop(Countdown, Grid * 3);
            Countdown.Foreground = Brushes.Red;
            Countdown.Text = "3";
            Countdown.FontSize = 100;

            Backgroundsound.Play();
            Racingtrack.Children.Clear();
            Map.chose_Map(Menue.Choseed_map, Grid);
            Car_player_1.redraw();
            Car_player_2.redraw();
            Map.set_checkpoints(Car_player_1, Grid);
            Map.set_checkpoints(Car_player_2, Grid);
            Racingtrack.Children.Add(Countdown);
            Racingtrack.Children.Add(Rounds_player_1);
            Racingtrack.Children.Add(Rounds_player_2);

            //Map.chose_Map(Menue.Choseed_map, Grid);

            //Car_player_1.redraw();
            //Car_player_2.redraw();

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

            in_start_sequenze = false;

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
            if (!Menue.Start_the_game)
            {
                Backgroundsound.Pause();
            }

        }
    }
}
