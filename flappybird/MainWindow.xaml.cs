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
        DispatcherTimer timer;
        DispatcherTimer spawnTimer;
        Kesek kesek;
		public MainWindow()
        {
            InitializeComponent();
            kesek = new Kesek();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(65);
            timer.Tick += Timer_Tick;

			spawnTimer = new DispatcherTimer();
            spawnTimer.Interval = TimeSpan.FromSeconds(4);
            spawnTimer.Tick += SpawnTimer_Tick;
		}
		int speed = 1;
        const int kesspeed = 4;
		private void Timer_Tick(object sender, EventArgs e)
        {
            MoveSajd();
            MoveKes(kesek);
        }
        private void MoveSajd()
        {
			double currentTop = Canvas.GetTop(sajd);
			Canvas.SetTop(sajd, currentTop + speed);
			speed += 1;
		}
        private void MoveKes(Kesek kesek)
        {
            if (kesek.KesLista != null) 
            {
				foreach (Rectangle kes in kesek.KesLista)
				{
					double currentLeft = Canvas.GetLeft(kes);
                    Canvas.SetLeft(kes, currentLeft - kesspeed);
				}
			}
        }
        private void SpawnTimer_Tick(object sender, EventArgs e)
        {
            Spawn(kesek);
        }
        private void Spawn(Kesek kesek)
        {
            double randomTop = kesek.RandomTop();
            mainCanvas.Children.Add(kesek.LefeleKesLetrehozas(randomTop));
            mainCanvas.Children.Add(kesek.FelfeleKesLetrehozas(randomTop));
        }
        private void SpaceDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
				double currentTop = Canvas.GetTop(sajd);
				Canvas.SetTop(sajd, currentTop - 20);
                speed = 1;
			}
        }
        
		private void Button_Click(object sender, RoutedEventArgs e)
		{
            Start(timer, spawnTimer);
		}
        private void Start(DispatcherTimer timer, DispatcherTimer spawnTimer)
        {
			sp.Visibility = Visibility.Hidden;
			sajd.Visibility = Visibility.Visible;
			hatter.Visibility = Visibility.Visible;
            timer.Start();
            spawnTimer.Start();
		}
	}
}