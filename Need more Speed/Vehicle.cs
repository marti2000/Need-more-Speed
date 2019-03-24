using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Need_more_Speed
{
    class Vehicle
    {
        private byte compare_to_player;
        private double position_x;
        private double position_y;
        private double rotation;
        private double speed;
        private char type;
        private bool up;
        private bool down;
        private bool left;
        private bool right;

        private Canvas racingtrack;
        Rectangle car = new Rectangle();

        public byte Compare_to_player { get => compare_to_player; set => compare_to_player = value; }
        public double Position_x { get => position_x; set => position_x = value; }
        public double Position_y { get => position_y; set => position_y = value; }
        public double Rotation { get => rotation; set => rotation = value; }
        public double Speed { get => speed; set => speed = value; }
        public char Type { get => type; set => type = value; }
        public bool Up { get => up; set => up = value; }
        public bool Down { get => down; set => down = value; }
        public bool Left { get => left; set => left = value; }
        public bool Right { get => right; set => right = value; }
        int zaehler = 0;

        public Vehicle(string type,byte compare_to_player, double start_position_x, double start_position_y ,Canvas myCanvas)
        {
            position_x = start_position_x;
            position_y = start_position_y;

            racingtrack = myCanvas;
            car.Height = 10;
            car.Width = 20;
            car.Stroke = Brushes.Red;
            car.Fill = Brushes.Red;
            racingtrack.Children.Add(car);

            System.Windows.Threading.DispatcherTimer Speed_timer = new System.Windows.Threading.DispatcherTimer();
            Speed_timer.Tick += Speed_timer_Tick;
            Speed_timer.Interval = new TimeSpan(10000);
            Speed_timer.Start();

            System.Windows.Threading.DispatcherTimer Speed_higher_timer = new System.Windows.Threading.DispatcherTimer();
            Speed_higher_timer.Tick += Speed_higher_timer_Tick;
            Speed_higher_timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            Speed_higher_timer.Start();
        }

        private void Speed_timer_Tick(object sender, EventArgs e)
        {
            rebound();
            position_calculation();
            refresh_position();
        }

        private void Speed_higher_timer_Tick(object sender, EventArgs e)
        {
            update_speed();
        }

        private void update_speed()
        {
            
            if ((up == true) && (speed > -50))
            {
                speed--;
                if (speed > 0)
                {
                    //speed--;
                    speed--;
                }
            }
            else if ((down == true) && (speed < 20))
            {   
                speed++;
                if (speed < 0)
                {
                    //speed++;
                    speed++;
                }
            }
            else if (zaehler >= 2)
            {
                if ((speed > 0) && (speed < 250))
                {
                    speed--;
                    // Auto_red_geschwindigkeit--;
                }
                else if ((speed < 0) && (speed > -150))
                {
                    speed++;
                    
                }
                zaehler = 0;
            }
            else
            {
                zaehler++;
            }
        }


        private void rebound()
        {
            if(position_x >= 1250)
            {
                speed = 0.5*speed;
                position_x = position_x - 10;
               // rotation = ;
            }

        }

        private void position_calculation(/*double position_y, double position_x*/)
        {
            RotateTransform ro_rotation = new RotateTransform(0);

            if (speed != 0)
            {   // Steuerung
                if (left == true)
                {
                    rotation++;
                    rotation++;
                }

                if (right == true)
                {
                    rotation--;
                    rotation--;
                }
            }
            ro_rotation.Angle = -rotation;
            car.RenderTransform = ro_rotation;
            double angle = Math.PI * rotation / 180.0;
            position_x += (speed / 10) * Math.Cos(angle);
            position_y -= (speed / 10) * Math.Sin(angle);
        }

        private void refresh_position()
        {
            Canvas.SetLeft(car, position_x);
            Canvas.SetTop(car, position_y);
        }
    }
}

