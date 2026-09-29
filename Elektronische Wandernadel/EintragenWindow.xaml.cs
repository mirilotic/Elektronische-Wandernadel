using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Database database = new Database();
        public Window1()
        {
            InitializeComponent();
        }

        public void eintragenzurückButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        public void fertigButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using SqliteConnection connection = database.DatenbankVerbinden();

                string sql = @"
                        INSERT INTO Wandernadel (HWNNr, Name, Erreicht, Stempel)
                        VALUES ($hwnnr, $name, $erreicht, $stempel);";

                using SqliteCommand command = new SqliteCommand(sql, connection);

                command.Parameters.AddWithValue("$hwnnr", hwnBox.Text);
                command.Parameters.AddWithValue("$name", nameBox.Text);
                command.Parameters.AddWithValue("$erreicht", datumBox.Text);
                command.Parameters.AddWithValue("$stempel", stempelBox.Text);

                command.ExecuteNonQuery();

                MessageBox.Show("Deine Daten wurden eingetragen!","Erfolg");

                hwnBox.Clear();
                nameBox.Clear();
                datumBox.SelectedDate = null;
                stempelBox.Clear();
            }

            catch
            {
                MessageBox.Show("Fehler! Die HWN- und Stempelnummern müssen Ganzzahlen sein. Hast du dich vielleicht verschrieben?","Ungültige Eingabe");
            }


        }

        public void w1fragezeichenButton_Click(Object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Die HWN-Nummer und der Name sind die Nummer und der Name, welche auf der Stempelstelle bzw. in deinem Buch stehen." +
                "\n\nOptional kannst du noch das Datum, an welchem du den Stempel erreicht hast, und dein wievielter Stempel es war eintragen. Wenn du das nicht mehr weißt, lass die Stellen einfach leer.", "Hilfe");
        }

    }
}
