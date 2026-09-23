using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Elektronische_Wandernadel
{
    /// <summary>
    /// Interaktionslogik für Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            StatistikLaden();
        }

        internal void w4zurückButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        internal void StatistikLaden()
        {
            int anzahl;
            int zumnaechsten = 0;
            string abzeichen = "nichts";
            string connectionString = "Data Source = HWN_Datenbank.db";

            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();

            using SqliteCommand command = new SqliteCommand("SELECT COUNT(*) FROM Wandernadel", connection);

            anzahl = Convert.ToInt32(command.ExecuteScalar());

            erreichtLabel.Content = anzahl;
            zuholenLabel.Content = 222 - anzahl;

            switch (anzahl)
            {
                case int n when (n >= 8 && n < 11): abzeichen = "Bronze"; break;
                case int n when (n >= 11 && n < 16): abzeichen = "Wanderprinz*essin"; break;
                case int n when (n >= 16 && n < 24): abzeichen = "Silber"; break;
                case int n when (n >= 24): abzeichen = "Gold"; break;
                default: abzeichen = "nichts"; break;
            }

            abzeichenLabel.Content = abzeichen;

            switch (anzahl)
            {
                case int n when (n < 8): zumnaechsten = 8 - anzahl; break;
                case int n when (n >= 8 && n < 11): zumnaechsten = 11 - anzahl; break;
                case int n when (n >= 11 && n < 16): zumnaechsten = 16 - anzahl; break;
                case int n when (n >= 16 && n < 24): zumnaechsten = 24 - anzahl; break;
            }

            zumnächstenLabel.Content = zumnaechsten;

        }

    }
}
