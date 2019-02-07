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


        public byte Compare_to_player { get => compare_to_player; set => compare_to_player = value; }
        public double Positon_x { get => positon_x; set => positon_x = value; }
        public double Positon_y { get => positon_y; set => positon_y = value; }
        public double Rotation { get => rotation; set => rotation = value; }
        public double Speed { get => speed; set => speed = value; }
        public char Type { get => type; set => type = value; }

        public Vehicle(char type,byte compare_to_player)
        {

        }

        public void update_speed()
        {

        }

        private void refresh_position()
        {

        }

    }
}

