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
using System.Windows.Threading;

namespace flappybird
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
        }
		int speed = 1;
		private void Timer_Tick(object sender, EventArgs e)
        {
           
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
            sp.Visibility = Visibility.Hidden;
            sajd.Visibility = Visibility.Visible;
            hatter.Visibility = Visibility.Visible;
		}
	}
}