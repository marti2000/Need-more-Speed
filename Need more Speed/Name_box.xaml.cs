using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Need_more_Speed
{
    public partial class Name_box : Window
    {
        private bool Value_ready = false;
        private double Compare_to_player;
        private string Name_of_player;

        public Name_box()
        {
            InitializeComponent();

            Name.Focus();
        }

        public bool value_ready { get => Value_ready; set => Value_ready = value; }
        public string name_of_player { get => Name_of_player; set => Name_of_player = value; }

        public void set_player_and_place(double compare_to_Player, int place_in_top_10)
        {
            Compare_to_player = compare_to_Player;
            Label.Text = "Spieler " + compare_to_Player.ToString() + " Bitte Namen eingeben:\nGesamtplatztierung: " + place_in_top_10.ToString();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Name_of_player = Name.Text;

            Value_ready = true;
        }

        private void Name_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Name_of_player = Name.Text;

                Value_ready = true;
            }
        }
    }

}
