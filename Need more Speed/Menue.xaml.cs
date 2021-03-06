﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class Menue : Window
    {
        private bool start_the_game = false;
        private bool end_the_game = false;

        private int choseed_map = 0;

        private double Anz_Rounds = 3;

        private string path = "/Need more Speed/GameFiles/Top_10_times";

        private double[] times_player_1 = new double[99];
        private double[] times_player_2 = new double[99];

        Starter starter;

        Credits credits;

        public bool Start_the_game { get => start_the_game; set => start_the_game = value; }
        public int Choseed_map { get => choseed_map; set => choseed_map = value; }
        internal Starter Starter { get => starter; set => starter = value; }
        public double Anz_rounds { get => Anz_Rounds; set => Anz_Rounds = value; }
        public double[] Times_player_1 { get => times_player_1; set => times_player_1 = value; }
        public double[] Times_player_2 { get => times_player_2; set => times_player_2 = value; }
        public bool End_the_game { get => end_the_game; set => end_the_game = value; }

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

            Write_app_storage("1_test", "10", "Marcel");

            string[] test_string_array = new string[2];
            test_string_array = Read_app_data("1_test");
        }

        private void Draw_tracks()
        {
            racetrack_show.Children.Clear();
            Maps draw_map = new Maps(racetrack_show);
            draw_map.chose_Map(Choseed_map, 20);
        }

        private void Change_track_visible()
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

        private void Change_track_hidden()
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

        private void Change_car_visible()
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

        private void Change_car_hidden()
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

        private void Settings_hidden()
        {
            Credits.Visibility = Visibility.Hidden;

            Credits.IsEnabled = false;
        }

        private void Settings_visible()
        {
            Credits.Visibility = Visibility.Visible;

            Credits.IsEnabled = true;
        } 

        private void Change_track_Click(object sender, RoutedEventArgs e)
        {
            Change_track_visible();
            Change_car_hidden();
            Settings_hidden();
            list_of_best.Visibility = Visibility.Hidden;
            Draw_tracks();
        }

        private void Change_car_Click(object sender, RoutedEventArgs e)
        {
            Change_car_visible();
            Change_track_hidden();
            Settings_hidden();
            list_of_best.Visibility = Visibility.Hidden;

            Vehicle car_player_1 = new Vehicle("Car", 0, 80, 0, show_car_player_1, Brushes.Red, 500);
            car_player_1.ON_ROAD = true;
            Vehicle car_player_2 = new Vehicle("Car", 0, 80, 0, show_car_player_2, Brushes.Blue, 500);
            car_player_2.ON_ROAD = true;
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Change_car_hidden();
            Settings_visible();
            Change_track_hidden();
            list_of_best.Visibility = Visibility.Hidden;

            //MessageBox.Show("Um dieses Feature zu nutzten, kaufen Sie bitte die Vollversion", "Lizenzproblem", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public async void Time_list_after_game()
        {

            double total_time_player_1 = 0;
            double total_time_player_2 = 0;

            bool end_race_player_1 = true;
            bool end_race_player_2 = true;

            while (starter.Ready)
            {
                await Task.Delay(10);
            }

            start_the_game = false;

            Change_car_hidden();
            Settings_hidden();
            Change_track_hidden();
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
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(times_player_1[counter] - times_player_1[counter - 1]));
                }
                else
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(times_player_1[counter]));
                }

                if (time.Ticks <= 0)
                {
                    end_race_player_1 = false;
                }
                else
                {
                    total_time_player_1 += time.Ticks;
                    
                }

                if(time.Ticks > 0)
                {
                    time_list_player_1.Items.Add((counter + 1).ToString() + "  " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString());
                }

                for (int counter_ = 1; counter_ <= 10; counter_++)
                {
                    string[] filedata = Read_app_data("TOP_" + counter_ + "_" + choseed_map);
                    long time_ticks;
                    long.TryParse(filedata[0], out time_ticks);
                    TimeSpan old_time = new TimeSpan(time_ticks);
                    if (((time.Ticks < old_time.Ticks) || (old_time.Ticks == 0)) && (time.Ticks > 0))
                    {
                        Name_box name_box = new Name_box();
                        name_box.Show();
                        name_box.set_player_and_place(1, counter_);

                        while (name_box.value_ready == false)
                        {
                            this.Hide();
                            await Task.Delay(300); 
                        }

                        if (counter_ < 10)
                        {
                            for (int _counter_ = 9; _counter_ >= counter_; _counter_--)
                            {
                                string[] storage;
                                storage = Read_app_data("TOP_" + _counter_.ToString() + "_" + choseed_map.ToString());
                                Write_app_storage("TOP_" + (_counter_ + 1).ToString() + "_" + choseed_map.ToString(), storage[0], storage[1]);
                            }

                            Write_app_storage("TOP_" + counter_.ToString() + "_" + choseed_map.ToString(), time.Ticks.ToString(), name_box.name_of_player);

                            name_box.Close();
                            this.Show();
                            counter_ = 11;
                        }
                    }
                }
            }


            for (int counter = 0; counter < Anz_Rounds; counter++)
            {
                TimeSpan time;

                if (counter > 0)
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(times_player_2[counter] - times_player_2[counter - 1]));
                }
                else
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(times_player_2[counter]));
                }

                if(time.Ticks <= 0)
                {
                    end_race_player_2 = false;
                }
                else
                {
                    total_time_player_2 += time.Ticks;
                    
                }

                if(time.Ticks > 0)
                {
                    time_list_player_2.Items.Add((counter + 1).ToString() + "  " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString());
                }

                for (int counter_ = 1; counter_ <= 10; counter_++)
                {
                    string[] filedata = Read_app_data("TOP_" + counter_ + "_" + choseed_map);
                    long time_ticks;
                    long.TryParse(filedata[0], out time_ticks);
                    TimeSpan old_time = new TimeSpan(time_ticks);
                    if (((time.Ticks < old_time.Ticks) || (old_time.Ticks == 0)) && (time.Ticks > 0))
                    {
                        Name_box name_box = new Name_box();
                        name_box.Show();
                        name_box.set_player_and_place(2, counter_);

                        while (name_box.value_ready == false)
                        {
                            this.Hide();
                            await Task.Delay(300);
                        }

                        if (counter_ < 10)
                        {
                            for (int _counter_ = 9; _counter_ >= counter_; _counter_--)
                            {
                                string[] storage;
                                storage = Read_app_data("TOP_" + _counter_.ToString() + "_" + choseed_map.ToString());
                                Write_app_storage("TOP_" + (_counter_ + 1).ToString() + "_" + choseed_map.ToString(), storage[0], storage[1]);
                            }

                            Write_app_storage("TOP_" + counter_.ToString() + "_" + choseed_map.ToString(), time.Ticks.ToString(), name_box.name_of_player);

                            name_box.Close();
                            this.Show();
                            counter_ = 11;
                        }
                    }
                }
            }

            if(((total_time_player_1 < total_time_player_2) && (end_race_player_1)) || ((!end_race_player_2) && (end_race_player_1)))
            {
                Gewinner.Text = "Der Gewinner ist Spieler 1";
            }
            else if (((total_time_player_2 < total_time_player_1) && (end_race_player_2)) || ((!end_race_player_1) && (end_race_player_2)))
            {
                Gewinner.Text = "Der Gewinner ist Spieler 2";
            }
            else
            {
                Gewinner.Text = "Es war unentschieden";
            }

        }

        private void Show_list_of_best_Click(object sender, RoutedEventArgs e)
        {
            Change_car_hidden();
            Settings_hidden();
            Change_track_hidden();
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
            for (int counter = 0; counter < 99; counter++)
            {
                times_player_1[counter] = 0;
                times_player_2[counter] = 0;
            }
            Starter.Start();
        }

        public void Open()
        {
            Menue_screen.Visibility = Visibility.Visible;
        }

        private void Next_left_Click(object sender, RoutedEventArgs e)
        {
            if(Choseed_map > 0)
            {
                Choseed_map--;
            }
            Draw_tracks();
        }

        private void Next_right_Click(object sender, RoutedEventArgs e)
        {
            if (Choseed_map < 3)
            {
                Choseed_map++;
            }
            Draw_tracks();
        }

        private void Map_generator_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Um dieses Feature zu nutzten, kaufen Sie bitte die Vollversion", "Lizenzproblem", MessageBoxButton.OK, MessageBoxImage.Warning);
            MessageBox.Show("Diese Funktion wird bei einer späteren Version hinzugefügt", "Coming soon", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Next_left_player_1_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Um dieses Feature zu nutzten, kaufen Sie bitte die Vollversion", "Lizenzproblem", MessageBoxButton.OK, MessageBoxImage.Warning);
            MessageBox.Show("Diese Funktion wird bei einer späteren Version hinzugefügt", "Coming soon", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Next_right_player_2_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Um dieses Feature zu nutzten, kaufen Sie bitte die Vollversion", "Lizenzproblem", MessageBoxButton.OK, MessageBoxImage.Warning);
            MessageBox.Show("Diese Funktion wird bei einer späteren Version hinzugefügt", "Coming soon", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Next_right_player_1_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Um dieses Feature zu nutzten, kaufen Sie bitte die Vollversion", "Lizenzproblem", MessageBoxButton.OK, MessageBoxImage.Warning);
            MessageBox.Show("Diese Funktion wird bei einer späteren Version hinzugefügt", "Coming soon", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Next_left_player_2_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Um dieses Feature zu nutzten, kaufen Sie bitte die Vollversion", "Lizenzproblem", MessageBoxButton.OK, MessageBoxImage.Warning);
            MessageBox.Show("Diese Funktion wird bei einer späteren Version hinzugefügt", "Coming soon", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Credits_Click(object sender, RoutedEventArgs e)
        {
            credits = new Credits();
            credits.Show();
        }

        private void Menue_screen_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                credits.Close();
            }
            catch
            { }
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
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(times_player_1[counter] - times_player_1[counter - 1]));
                }
                else
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(times_player_1[counter]));
                }

                if(time.Ticks > 0)
                {
                    time_list_player_1.Items.Add((counter + 1).ToString() + "  " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString());
                }
                
            }
            for (int counter = 0; counter < Anz_Rounds; counter++)
            {
                TimeSpan time;

                if (counter > 0)
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(times_player_2[counter] - times_player_2[counter - 1]));
                }
                else
                {
                    time = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(times_player_2[counter]));
                }

                if (time.Ticks > 0)
                {
                    time_list_player_2.Items.Add((counter + 1).ToString() + "  " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString());
                }
            }
        }

        private void Top_10_ever_Click(object sender, RoutedEventArgs e)
        {
            time_list_player_1.Visibility = Visibility.Hidden;
            time_list_player_2.Visibility = Visibility.Hidden;

            time_list_Top_10.Visibility = Visibility.Visible;

            time_list_Top_10.Items.Clear();

            Label_left.Text = "TOP 10";
            Label_right.Text = "TOP 10";

            for(int counter = 1; counter <= 10; counter++)
            {
                string[] storage;
                storage = Read_app_data("TOP_" + counter.ToString() + "_" + choseed_map.ToString());
                long time_ticks;
                long.TryParse(storage[0], out time_ticks);
                TimeSpan best_time = new TimeSpan(time_ticks);
                time_list_Top_10.Items.Add(counter.ToString() + " " + storage[1] + " " + best_time.Minutes.ToString() + ":" + best_time.Seconds.ToString() + ":" + best_time.Milliseconds.ToString());
            }
            
        }

        private void Write_app_storage(string Key, string time, string name)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            StreamWriter writer = new StreamWriter(path + "/" + Key + ".nms");

            writer.WriteLine(time);
            writer.WriteLine(name);

            writer.Close();
        }

        private string[] Read_app_data(string Key)
        {
            string[] saved_data = new string[2];

            if (File.Exists(path + "/" + Key + ".nms"))
            {
                StreamReader reader = new StreamReader(path + "/" + Key + ".nms");

                saved_data[0] = reader.ReadLine();
                saved_data[1] = reader.ReadLine();
                reader.Close();

                return saved_data;

            }
            else
            {
                saved_data[0] = "";
                saved_data[1] = "";
                return saved_data;
            }
        }

    }
}
//build by Marcel