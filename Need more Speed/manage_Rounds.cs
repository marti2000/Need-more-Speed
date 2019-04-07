using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Need_more_Speed
{
    class manage_Rounds
    {

        Maps Map;
        Vehicle Car;
        Canvas Raceingtrack;
        TextBlock Rounds;
        Starter Start;
        Menue Menue;
        double Grid;

        System.Diagnostics.Stopwatch round_timer;

        public manage_Rounds( Vehicle car, Maps map, Canvas raceingtrack, Starter start , Menue menue, double grid )
        {
            Car = car;
            Map = map;
            Raceingtrack = raceingtrack;
            Start = start;
            Grid = grid;
            Menue = menue;
            

            System.Windows.Threading.DispatcherTimer refresh = new System.Windows.Threading.DispatcherTimer();
            refresh.Tick += refresh_Tick;
            refresh.Interval = new TimeSpan(0, 0, 0, 0, 1);
            refresh.Start();

            Rounds = new TextBlock();

            if(Car.Compare_to_player == 1)
            {
                Canvas.SetLeft(Rounds, 0);
                Canvas.SetTop(Rounds, 0);

                Start.Rounds_player_1 = Rounds;
            }
            else if(Car.Compare_to_player == 2)
            {
                Canvas.SetLeft(Rounds, System.Windows.SystemParameters.MaximizedPrimaryScreenWidth-200/*10* Grid*/);
                Canvas.SetTop(Rounds, 0);
                Rounds.TextAlignment = System.Windows.TextAlignment.Right;

                Start.Rounds_player_2 = Rounds;
            }

            Raceingtrack.Children.Add(Rounds);

            Rounds.Text = "Spieler " + Car.Compare_to_player.ToString() + "\n" + (Car.Round + 1).ToString() + "/" + Menue.Anz_rounds.ToString();
            Rounds.FontSize = 40;

            round_timer = new System.Diagnostics.Stopwatch();
        }

        private async void wait_for_end_game()
        {

            await Task.Delay(5000);
            Start.Ready = false;
            round_timer.Stop();
            Car.Speed = 0;
            Car.Up = false;
            Car.Down = false;
            Car.Right = false;
            Car.Left = false;
            Car.Round = 0;
            
            Menue.Show();
        }

        private void refresh_Tick(object sender, EventArgs e)
        {
            if(Car.Round == Menue.Anz_rounds)
            {
                if (Car.Compare_to_player == 1)
                {
                    Menue.Times_player_1 = Car.Round_time;
                }
                else if (Car.Compare_to_player == 2)
                {
                    Menue.Times_player_2 = Car.Round_time;
                }
                round_timer.Stop();

                Menue.time_list_after_game();
                wait_for_end_game();

                Car.Round++;
            }
            else if(Start.Ready)
            {
                round_timer.Start();
            }

            if (Car.Round < Menue.Anz_rounds)
            {
                Rounds.Text = "Spieler " + Car.Compare_to_player.ToString() + "\n" + (Car.Round + 1).ToString() + "/" + Menue.Anz_rounds.ToString();
            }
            else
            {
                Rounds.Text = "Spieler " + Car.Compare_to_player.ToString() + "\nim Ziel";
            }
            

            //Check if the car is on the Road
            if (Map.car_on_road(Car.Position_x, Car.Position_y, Grid, Car.Rotation) == true)
            {
                Car.ON_ROAD = true;
            }
            else
            {
                Car.ON_ROAD = false;
            }

            if (Map.car_over_checkpoint(Car.Position_x, Car.Position_y, Grid, Car.Rotation))
            {
                if ((Car.On_checkpoint == false))
                {
                    Car.checked_checkpoint(Car.Position_x, Car.Position_y, Grid);
                    Car.On_checkpoint = true;
                } 
            }
            else
            {
                Car.On_checkpoint = false;
            }

            if ((Map.car_over_finish(Car.Position_x, Car.Position_y, Grid, Car.Rotation)) && (Car.all_checkpoints() == true))
            {
                if ((Car.On_finish == false))
                {
                    Car.Round_time[Convert.ToInt16(Car.Round)] = round_timer.ElapsedMilliseconds;

                    if (Car.Compare_to_player == 1)
                    {
                        Menue.Times_player_1[Convert.ToInt16(Car.Round)] = Car.Round_time[Convert.ToInt16(Car.Round)];
                    }
                    else if (Car.Compare_to_player == 2)
                    {
                        Menue.Times_player_2[Convert.ToInt16(Car.Round)] = Car.Round_time[Convert.ToInt16(Car.Round)];
                    }

                    Car.Round++;
                    Car.On_finish = true;
                    Car.clear_checkpoint();
                }

            }
            else
            {
                Car.On_finish = false;
            }

            if(Start.In_start_sequenze)
            {
                round_timer.Reset();
            }
        }
    }
}
