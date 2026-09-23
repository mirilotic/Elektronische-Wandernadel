using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Elektronische_Wandernadel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Database database = new Database();
            database.Initialisieren();
        }

        public void eintragenButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
            this.Close();
        }

        public void tabelleButton_Click(Object sender, RoutedEventArgs e)
        {
            Window2 window = new Window2();
            window.Show();
            this.Close();
        }

        public void statistikButton_Click(Object sender, RoutedEventArgs e)
        {
            Window4 window = new Window4();
            window.Show();
            this.Close();
        }

        public void zimmerButton_Click(Object sender, RoutedEventArgs e)
        {
            Window3 window = new Window3();
            window.Show();
            this.Close();
        }
    }
}