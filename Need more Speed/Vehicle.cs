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
        public double Positon_x { get => positon_x; set => positon_x = value; }
        public double Positon_y { get => positon_y; set => positon_y = value; }
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


        }


        private void refresh_position()
        {

        }

        private void position_calculation(double positon_y, double positon_x)
        {

        }


    }
}

