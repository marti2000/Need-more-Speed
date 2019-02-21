using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Need_more_Speed
{
    class Vehicle
    {
        private byte compare_to_player;
        private double positon_x;
        private double positon_y;
        private double rotation;
        private double speed;
        private char type;
        private bool up;
        private bool down;
        private bool left;
        private bool right;


        public byte Compare_to_player { get => compare_to_player; set => compare_to_player = value; }
        public double Position_x { get => positon_x; set => positon_x = value; }
        public double Position_y { get => positon_y; set => positon_y = value; }
        public double Rotation { get => rotation; set => rotation = value; }
        public double Speed { get => speed; set => speed = value; }
        public char Type { get => type; set => type = value; }
        public bool Up { get => up; set => up = value; }
        public bool Down { get => down; set => down = value; }
        public bool Left { get => left; set => left = value; }
        public bool Right { get => right; set => right = value; }

        public Vehicle(char type,byte compare_to_player)
        {

        }


        private void update_speed()
        {
            int zaehler = 0;
            if ((up == true) && (speed > -20))
            {
                speed--;
                if (speed > 1)
                {
                    speed--;
                    speed--;
                }
            }
            else if ((down == true) && (speed < 40))
            {
                speed++;
                if (speed < -1)
                {
                    speed++;
                    speed++;
                }
            }
            else if (zaehler >= 2)
            {
                if (speed > 0) /*&& (speed < 25)*/
                {
                    speed--;
                    // Auto_red_geschwindigkeit--;
                }
                else if (speed < 0)/* && (speed < -15)*/
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


        private void refresh_position()
        {
            /*Canvas.SetLeft(Auto_red, position_x);
            Canvas.SetTop(Auto_red, position_y);*/
        }

        private void position_calculation(double position_y, double position_x)
        {
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
            double angle = Math.PI * rotation / 180.0;
            position_x += (speed / 10) * Math.Cos(angle);
            position_y -= (speed / 10) * Math.Sin(angle);
        }


    }
}

