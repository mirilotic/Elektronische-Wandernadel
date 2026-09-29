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
    /// Interaktionslogik für Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        Database database = new Database();
        public Window3()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void zimmerzurueckButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        public ImageSource Bildpfad
        {
          get
           { string bildPfad = "";
                int anzahl;
                using SqliteConnection connection = database.DatenbankVerbinden();

                using SqliteCommand command = new SqliteCommand("SELECT COUNT(*) FROM Wandernadel", connection);

                anzahl = Convert.ToInt32(command.ExecuteScalar());

                switch (anzahl)
                {
                    case int n when (n < 8): bildPfad = "ab 0.png"; break;
                    case int n when (n >= 8 && n < 11): bildPfad = "ab 8.png"; break;
                    case int n when (n >= 11 && n < 16): bildPfad = "ab 11.png"; break;
                    case int n when (n >= 16 && n < 24): bildPfad = "ab 16.png"; break;
                    case int n when (n >= 24 && n < 50): bildPfad = "ab 24.png"; break;
                    case int n when (n >= 50 && n < 100): bildPfad = "ab 50.png"; break;
                    case int n when (n >= 100 && n < 150): bildPfad = "ab 100.png"; break;
                    case int n when (n >= 150 && n < 222): bildPfad = "ab 150.png"; break;
                    case int n when (n >= 222): bildPfad = "222.png"; break;
                }

                return new BitmapImage(
                    new Uri($"pack://application:,,,/{bildPfad}"));
            }

        }

        private void fragezeichenButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hier bist du in deinem Zimmer. Deine Abzeichen werden hier abgelegt - Stück für Stück wird es sich füllen. Viel Spaß beim Sammeln!", "Hilfe");
        }
    }
}
