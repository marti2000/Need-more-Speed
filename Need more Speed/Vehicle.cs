using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Drawing;
using System.Windows;

namespace Need_more_Speed
{
    class Vehicle
    {
        private double compare_to_player;
        private double position_x;
        private double position_y;
        private double rotation;
        private double speed;
        private double round;
        private double[] round_time = new double[99];
        private char type;
        private bool up;
        private bool down;
        private bool left;
        private bool right;
        private bool oN_ROAD;
        private bool on_finish;
        private bool on_checkpoint;
        

        private Canvas racingtrack;
        private TextBlock Speed_tacho;
        Canvas car = new Canvas();

        Dictionary<Point, bool> checked_checkpoints = new Dictionary<Point, bool>();

        private const double acceleration_value = 20;//2;
        private const double breaking_value = 10;//9;

        private const int speed_timer_up_value = 100;

        private const double speed_to_turn = 1;

        public double Compare_to_player { get => compare_to_player; set => compare_to_player = value; }
        public double Position_x { get => position_x; set => position_x = value; }
        public double Position_y { get => position_y; set => position_y = value; }
        public double Rotation { get => rotation; set => rotation = value; }
        public double Speed { get => speed; set => speed = value; }
        public char Type { get => type; set => type = value; }
        public bool Up { get => up; set => up = value; }
        public bool Down { get => down; set => down = value; }
        public bool Left { get => left; set => left = value; }
        public bool Right { get => right; set => right = value; }
        public bool ON_ROAD { get => oN_ROAD; set => oN_ROAD = value; }
        public bool On_finish { get => on_finish; set => on_finish = value; }
        public double Round { get => round; set => round = value; }
        public bool On_checkpoint { get => on_checkpoint; set => on_checkpoint = value; }
        public double[] Round_time { get => round_time; set => round_time = value; }

        int zaehler = 0;

        

        public Vehicle(string type, double compare_to_player, double start_position_x, double start_position_y ,Canvas myCanvas, TextBlock _Speed ,Brush color)
        {
            position_x = start_position_x;
            position_y = start_position_y;

            this.compare_to_player = compare_to_player;

            Speed_tacho = _Speed;

            racingtrack = myCanvas;

            //System.Drawing.Rectangl.Union

            Rectangle Body = new Rectangle();
            

            Body.Height = 10;
            Body.Width = 20;
            Body.Stroke = color;//Brushes.Red;
            Body.Fill = color;//Brushes.Red;
            Canvas.SetTop(Body, 3);
            Canvas.SetLeft(Body, 0);

            Rectangle wheels_front = new Rectangle();

            wheels_front.Height = 16;
            wheels_front.Width = 4;
            wheels_front.Stroke = Brushes.Black;//Brushes.Red;
            wheels_front.Fill = Brushes.Black;//Brushes.Red;
            Canvas.SetTop(wheels_front, 0);
            Canvas.SetLeft(wheels_front, 3);

            Rectangle wheels_behinde = new Rectangle();

            wheels_behinde.Height = 16;
            wheels_behinde.Width = 4;
            wheels_behinde.Stroke = Brushes.Black;//Brushes.Red;
            wheels_behinde.Fill = Brushes.Black;//Brushes.Red;
            Canvas.SetTop(wheels_behinde, 0);
            Canvas.SetLeft(wheels_behinde, 13);

            Rectangle spoiler = new Rectangle();

            spoiler.Height = 16;
            spoiler.Width = 3;
            spoiler.Stroke = color;//Brushes.Red;
            spoiler.Fill = color;//Brushes.Red;
            Canvas.SetTop(spoiler, 0);
            Canvas.SetLeft(spoiler, 22);

            Rectangle spoiler_holder_right = new Rectangle();

            spoiler_holder_right.Height = 3;
            spoiler_holder_right.Width = 3;
            spoiler_holder_right.Stroke = color;//Brushes.Red;
            spoiler_holder_right.Fill = color;//Brushes.Red;
            Canvas.SetTop(spoiler_holder_right, 4);
            Canvas.SetLeft(spoiler_holder_right, 20);

            Rectangle spoiler_holder_left = new Rectangle();

            spoiler_holder_left.Height = 3;
            spoiler_holder_left.Width = 3;
            spoiler_holder_left.Stroke = color;//Brushes.Red;
            spoiler_holder_left.Fill = color;//Brushes.Red;
            Canvas.SetTop(spoiler_holder_left, 9);
            Canvas.SetLeft(spoiler_holder_left, 20);

            Ellipse Driver = new Ellipse();
            Driver.Height = 8;
            Driver.Width = 8;
            Driver.Stroke = Brushes.DimGray;
            Driver.Fill = Brushes.DimGray;
            Canvas.SetTop(Driver, 4);
            Canvas.SetLeft(Driver, 6);

            car.Children.Add(wheels_front);
            car.Children.Add(wheels_behinde);
            car.Children.Add(Body);
            car.Children.Add(spoiler);
            car.Children.Add(spoiler_holder_right);
            car.Children.Add(spoiler_holder_left);
            car.Children.Add(Driver);

            racingtrack.Children.Add(car);

            System.Windows.Threading.DispatcherTimer Speed_timer = new System.Windows.Threading.DispatcherTimer();
            Speed_timer.Tick += Speed_timer_Tick;
            Speed_timer.Interval = new TimeSpan(10000);
            Speed_timer.Start();

            System.Windows.Threading.DispatcherTimer Speed_higher_timer = new System.Windows.Threading.DispatcherTimer();
            Speed_higher_timer.Tick += Speed_higher_timer_Tick;
            Speed_higher_timer.Interval = new TimeSpan(0, 0, 0, 0, speed_timer_up_value);
            Speed_higher_timer.Start();
        }
        
        public void redraw()
        {
            racingtrack.Children.Add(car);
        }

        private void Speed_timer_Tick(object sender, EventArgs e)
        {
            rebound();
            OFF_ROAD_SLOW();
            position_calculation();
            refresh_position();
        }

        private void Speed_higher_timer_Tick(object sender, EventArgs e)
        {
            update_speed();
        }

        private void update_speed()
        {
            
            if ((up == true) && (speed > -100))
            {
                speed--;
                if (speed > 0)
                {
                    //speed§
                    speed -= acceleration_value;
                }
            }
            else if ((down == true) && (speed < 20))
            {   
                speed++;
                if (speed < 0)
                {
                    //speed++;
                    speed += acceleration_value *2 ;
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
                    speed += breaking_value;

                }
                zaehler = 0;
            }
            else
            {
                zaehler++;
            }


            Speed_tacho.Text = ((speed*-1)*2).ToString();
        }


        private void rebound()
        {
            if (position_y <= 0)
            {
                Speed = Math.Truncate(Speed * 0.5);
                position_y = position_y + 10;
                // rotation = ;
            }
            else if (position_y >= 705)
            {
                Speed = Math.Truncate(Speed * 0.5);
                position_y = position_y - 10;
               // rotation = ;
            }
            else if (position_x <= 0)
            {
                Speed = Math.Truncate(Speed * 0.5);
                position_x = position_x + 10;
                // rotation = ;
            }
            else if (position_x >= 1370)
            {
                Speed = Math.Truncate(Speed * 0.5);
                position_x = position_x - 10;
                // rotation = ;
            }

        }

        void OFF_ROAD_SLOW ()
        {
            if(oN_ROAD == false)
            {
                Speed = Math.Truncate(Speed * 0.999);
                if (speed >= -5)
                {
                    if (speed <= 5)
                    {
                        speed = 5;
                    }
                    else
                    {
                        speed = -5;
                    }

                }
                
            }
            else
            {
                
            }
        }

        private void position_calculation(/*double position_y, double position_x*/)
        {
            RotateTransform ro_rotation = new RotateTransform(0);

            if ((speed < -speed_to_turn) || (speed > speed_to_turn))
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

        public void add_checkpoint(double x_position, double y_position)
        {
            Point x_y_position = new Point();
            x_y_position.X = x_position;
            x_y_position.Y = y_position;
            checked_checkpoints.Add(x_y_position, false);
        }

        public void checked_checkpoint(double x_position, double y_position, double grid)
        {
            checked_checkpoints[new Point(Math.Truncate(x_position / grid), Math.Truncate(y_position / grid))] = true;    
        }

        public void clear_checkpoint()
        {
            foreach (var point_in_dictionary in checked_checkpoints.Keys.ToArray())
            {
                checked_checkpoints[point_in_dictionary] = false;
            }
               
        }

        public bool all_checkpoints()
        {
            int unchecked_checkpoints_counter = 0;
            foreach (var point_in_dictionary in checked_checkpoints)
            {
                if(checked_checkpoints[point_in_dictionary.Key] == false)
                {
                    unchecked_checkpoints_counter++;
                }
                
            }
            if (unchecked_checkpoints_counter == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    } 
}

