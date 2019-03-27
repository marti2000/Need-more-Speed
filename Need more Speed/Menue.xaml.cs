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
    /// <summary>
    /// Interaktionslogik für Menue.xaml
    /// </summary>
    public partial class Menue : Window
    {
        private bool start_the_game = false;

        public bool Start_the_game { get => start_the_game; set => start_the_game = value; }

        public Menue()
        {
            InitializeComponent();
            Menue_screen.Width = 800;
            next_left.Content = "<";
            next_right.Content = ">";

            next_right_player_1.Content = ">";
            next_left_player_1.Content = "<";
            next_right_player_2.Content = ">";
            next_left_player_2.Content = "<";
        }

        private void change_track_visible()
        {
            next_left.Visibility = Visibility.Visible;
            next_right.Visibility = Visibility.Visible;
            racetrack_show.Visibility = Visibility.Visible;
            map_generator.Visibility = Visibility.Visible;

            next_left.IsEnabled = true;
            next_right.IsEnabled = true;
            map_generator.IsEnabled = true;
        }

        private void change_track_hidden()
        {
            next_left.Visibility = Visibility.Hidden;
            next_right.Visibility = Visibility.Hidden;
            racetrack_show.Visibility = Visibility.Hidden;
            map_generator.Visibility = Visibility.Hidden;

            next_left.IsEnabled = false;
            next_right.IsEnabled = false;
            map_generator.IsEnabled = false;
        }

        private void change_car_visible()
        {
            next_left_player_1.Visibility = Visibility.Visible;
            next_right_player_1.Visibility = Visibility.Visible;
            next_left_player_2.Visibility = Visibility.Visible;
            next_right_player_2.Visibility = Visibility.Visible;
            show_car_player_1.Visibility = Visibility.Visible;
            show_car_player_2.Visibility = Visibility.Visible;

            next_left_player_1.IsEnabled = true;
            next_right_player_1.IsEnabled = true;
            next_left_player_2.IsEnabled = true;
            next_right_player_2.IsEnabled = true;
        }

        private void change_car_hidden()
        {
            next_left_player_1.Visibility = Visibility.Hidden;
            next_right_player_1.Visibility = Visibility.Hidden;
            next_left_player_2.Visibility = Visibility.Hidden;
            next_right_player_2.Visibility = Visibility.Hidden;
            show_car_player_1.Visibility = Visibility.Hidden;
            show_car_player_2.Visibility = Visibility.Hidden;

            next_left_player_1.IsEnabled = false;
            next_right_player_1.IsEnabled = false;
            next_left_player_2.IsEnabled = false;
            next_right_player_2.IsEnabled = false;
        }

        private void Change_track_Click(object sender, RoutedEventArgs e)
        {
            change_track_visible();
            change_car_hidden();
        }

        private void Change_car_Click(object sender, RoutedEventArgs e)
        {
            change_car_visible();
            change_track_hidden();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            change_car_hidden();
            change_track_hidden();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            start_the_game = true;
        }

        private void Next_left_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Next_right_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Map_generator_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Next_left_player_1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Next_right_player_2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Next_right_player_1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Next_left_player_2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
