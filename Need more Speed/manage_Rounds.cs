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
        double Grid;

        public manage_Rounds( Vehicle car, Maps map, Canvas raceingtrack, double grid )
        {
            Map = map;
            Car = car;
            Grid = grid;

            System.Windows.Threading.DispatcherTimer refresh = new System.Windows.Threading.DispatcherTimer();
            refresh.Tick += refresh_Tick;
            refresh.Interval = new TimeSpan(0, 0, 0, 0, 1);
            refresh.Start();

            if(Car.Compare_to_player == 1)
            {

            }
            else if(Car.Compare_to_player == 2)
            {

            }

            System.Diagnostics.Stopwatch round_timer = new System.Diagnostics.Stopwatch();

            /*
             * 
             * 
             *  round_timer.Start(); // Start Zeitlauf
             *  // Algorithmus
             *  round_timer.Stop(); // Ende Zeitlauf
             *  TimeSpan timeSpan = round_timer.Elapsed;
             *  Console.WriteLine("Time: {0}h {1}m {2}s {3}ms", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
             * 
             * 
             */


        }

        private void refresh_Tick(object sender, EventArgs e)
        {
            //Check if the car is on the Road
            if (Map.car_on_road(Car.Position_x, Car.Position_y, Grid, Car.Rotation) == true)
            {
                //Speed.Text = "ON Road";
                Car.ON_ROAD = true;
            }
            else
            {
                //Speed.Text = "OFF Road";
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
                    Car.Round++;
                    Car.On_finish = true;
                    Car.clear_checkpoint();
                }

            }
            else
            {
                Car.On_finish = false;
            }
        }
    }
}
