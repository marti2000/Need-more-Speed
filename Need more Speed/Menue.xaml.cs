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

        private int choseed_map = 0;

        private double Anz_Rounds = 3;

        private double[] times_player_1 = new double[99];
        private double[] times_player_2 = new double[99];

        Starter starter;

        public bool Start_the_game { get => start_the_game; set => start_the_game = value; }
        public int Choseed_map { get => choseed_map; set => choseed_map = value; }
        internal Starter Starter { get => starter; set => starter = value; }
        public double Anz_rounds { get => Anz_Rounds; set => Anz_Rounds = value; }
        public double[] Times_player_1 { get => times_player_1; set => times_player_1 = value; }
        public double[] Times_player_2 { get => times_player_2; set => times_player_2 = value; }

        public Menue()
        {
            InitializeComponent();

            Menue_screen.Width = 800;

            next_left.Content = "<";
            next_right.Content = ">";
            remove_round.Content = "<";
            add_round.Content = ">";

            next_right_player_1.Content = ">";
            next_left_player_1.Content = "<";
            next_right_player_2.Content = ">";
            next_left_player_2.Content = "<";

            anz_rounds.Text = Anz_Rounds.ToString();
        }

        private void draw_tracks()
        {
            racetrack_show.Children.Clear();
            Maps draw_map = new Maps(racetrack_show);
            draw_map.chose_Map(Choseed_map, 20);
        }

        private void change_track_visible()
        {
            next_left.Visibility = Visibility.Visible;
            next_right.Visibility = Visibility.Visible;
            racetrack_show.Visibility = Visibility.Visible;
            map_generator.Visibility = Visibility.Visible;
            add_round.Visibility = Visibility.Visible;
            remove_round.Visibility = Visibility.Visible;
            anz_rounds.Visibility = Visibility.Visible;
            Label_Rounds.Visibility = Visibility.Visible;

            next_left.IsEnabled = true;
            next_right.IsEnabled = true;
            map_generator.IsEnabled = true;
            add_round.IsEnabled = true;
            remove_round.IsEnabled = true;
        }

        private void change_track_hidden()
        {
            next_left.Visibility = Visibility.Hidden;
            next_right.Visibility = Visibility.Hidden;
            racetrack_show.Visibility = Visibility.Hidden;
            map_generator.Visibility = Visibility.Hidden;
            add_round.Visibility = Visibility.Hidden;
            remove_round.Visibility = Visibility.Hidden;
            anz_rounds.Visibility = Visibility.Hidden;
            Label_Rounds.Visibility = Visibility.Hidden;

            next_left.IsEnabled = false;
            next_right.IsEnabled = false;
            map_generator.IsEnabled = false;
            add_round.IsEnabled = false;
            remove_round.IsEnabled = false;
        }

        private void change_car_visible()
        {
            next_left_player_1.Visibility = Visibility.Visible;
            next_right_player_1.Visibility = Visibility.Visible;
            next_left_player_2.Visibility = Visibility.Visible;
            next_right_player_2.Visibility = Visibility.Visible;
            show_car_player_1.Visibility = Visibility.Visible;
            show_car_player_2.Visibility = Visibility.Visible;
            label_car_player_1.Visibility = Visibility.Visible;
            label_car_player_2.Visibility = Visibility.Visible;

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
            label_car_player_1.Visibility = Visibility.Hidden;
            label_car_player_2.Visibility = Visibility.Hidden;

            next_left_player_1.IsEnabled = false;
            next_right_player_1.IsEnabled = false;
            next_left_player_2.IsEnabled = false;
            next_right_player_2.IsEnabled = false;
        }

        private void Change_track_Click(object sender, RoutedEventArgs e)
        {
            change_track_visible();
            change_car_hidden();
            list_of_best.Visibility = Visibility.Hidden;
            draw_tracks();
        }

        private void Change_car_Click(object sender, RoutedEventArgs e)
        {
            change_car_visible();
            change_track_hidden();
            list_of_best.Visibility = Visibility.Hidden;
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            change_car_hidden();
            change_track_hidden();
            list_of_best.Visibility = Visibility.Hidden;
        }

        public void time_list_after_game()
        {
            change_car_hidden();
            change_track_hidden();
            list_of_best.Visibility = Visibility.Visible;

            Label_left.Text = "Spieler 1";
            Label_right.Text = "Spieler 2";

            time_list_player_1.Visibility = Visibility.Visible;
            time_list_player_2.Visibility = Visibility.Visible;

            time_list_Top_10.Visibility = Visibility.Hidden;

            time_list_player_1.Items.Clear();
            time_list_player_2.Items.Clear();

            for (int counter = 0; counter < Anz_Rounds; counter++)
            {
                TimeSpan time;

                if (counter > 0)
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(times_player_1[counter] - times_player_1[counter - 1]));
                }
                else
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(times_player_1[counter]));
                }
                time_list_player_1.Items.Add((counter + 1).ToString() + "  " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString());
            }
            for (int counter = 0; counter < Anz_Rounds; counter++)
            {
                TimeSpan time;

                if (counter > 0)
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(times_player_2[counter] - times_player_2[counter - 1]));
                }
                else
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(times_player_2[counter]));
                }
                time_list_player_2.Items.Add((counter + 1).ToString() + "  " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString());
            }
        }

        private void Show_list_of_best_Click(object sender, RoutedEventArgs e)
        {
            change_car_hidden();
            change_track_hidden();
            list_of_best.Visibility = Visibility.Visible;

            Label_left.Text = "Spieler 1";
            Label_right.Text = "Spieler 2";

            time_list_player_1.Visibility = Visibility.Visible;
            time_list_player_2.Visibility = Visibility.Visible;

            time_list_Top_10.Visibility = Visibility.Hidden;

            time_list_player_1.Items.Clear();
            time_list_player_2.Items.Clear();

            for (int counter = 0; counter < Anz_Rounds; counter++)
            {
                TimeSpan time;

                if (counter > 0)
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(times_player_1[counter] - times_player_1[counter - 1]));
                }
                else
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(times_player_1[counter]));
                }
                time_list_player_1.Items.Add((counter + 1).ToString() + "  " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString());
            }
            for (int counter = 0; counter < Anz_Rounds; counter++)
            {
                TimeSpan time;

                if (counter > 0)
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(times_player_2[counter] - times_player_2[counter - 1]));
                }
                else
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(times_player_2[counter]));
                }
                time_list_player_2.Items.Add((counter + 1).ToString() + "  " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString());
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            start_the_game = true;
            Menue_screen.Visibility = Visibility.Hidden;
            Starter.Start();
        }

        public void Open()
        {
            Menue_screen.Visibility = Visibility.Visible;
        }

        private void Next_left_Click(object sender, RoutedEventArgs e)
        {
            Choseed_map--;
            draw_tracks();
        }

        private void Next_right_Click(object sender, RoutedEventArgs e)
        {
            Choseed_map++;
            draw_tracks();
        }

        private void Map_generator_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Um dieses Feature zu nutzten, kaufen Sie bitte die Vollversion", "Lizenzproblem", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void Menue_screen_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void Remove_round_Click(object sender, RoutedEventArgs e)
        {
            if(Anz_Rounds > 1)
            {
                Anz_Rounds--;
            }
            anz_rounds.Text = Anz_Rounds.ToString();
        }

        private void Add_round_Click(object sender, RoutedEventArgs e)
        {
            if(Anz_Rounds < 99)
            {
                Anz_Rounds++;
            }
            anz_rounds.Text = Anz_Rounds.ToString();
        }

        private void Actuell_race_Click(object sender, RoutedEventArgs e)
        {
            time_list_player_1.Visibility = Visibility.Visible;
            time_list_player_2.Visibility = Visibility.Visible;

            time_list_Top_10.Visibility = Visibility.Hidden;

            Label_left.Text = "Spieler 1";
            Label_right.Text = "Spieler 2";

            time_list_player_1.Items.Clear();
            time_list_player_2.Items.Clear();

            for (int counter = 0; counter < Anz_Rounds; counter++)
            {
                TimeSpan time;

                if (counter > 0)
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(times_player_1[counter] - times_player_1[counter - 1]));
                }
                else
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(times_player_1[counter]));
                }
                time_list_player_1.Items.Add((counter + 1).ToString() + "  " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString());
            }
            for (int counter = 0; counter < Anz_Rounds; counter++)
            {
                TimeSpan time;

                if (counter > 0)
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(times_player_2[counter] - times_player_2[counter - 1]));
                }
                else
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(times_player_2[counter]));
                }
                time_list_player_2.Items.Add((counter + 1).ToString() + "  " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString());
            }
        }

        private void Top_10_ever_Click(object sender, RoutedEventArgs e)
        {
            time_list_player_1.Visibility = Visibility.Hidden;
            time_list_player_2.Visibility = Visibility.Hidden;

            time_list_Top_10.Visibility = Visibility.Visible;

            Label_left.Text = "TOP 10";
            Label_right.Text = "TOP 10";
        }
    }
}
