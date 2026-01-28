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
        DispatcherTimer pontTimer;
        Kesek kesek;
        bool esos;
        bool kodos;
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

            pontTimer = new DispatcherTimer();
            pontTimer.Interval = TimeSpan.FromSeconds(4);
            pontTimer.Tick += PontTimer_Tick;
		}
		int speed = 1;
        const int kesspeed = 4;
		private void Timer_Tick(object sender, EventArgs e)
        {
            MoveSajd();
            MoveKes();
            CheckCollision();
        }
        private void MoveSajd()
        {
			double currentTop = Canvas.GetTop(sajd);
			Canvas.SetTop(sajd, currentTop + speed);
			speed += 1;
		}

        private void MoveKes()
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
        private void CheckCollision()
        {
            if (kesek.KesLista != null)
            {
                foreach (Rectangle kes in kesek.KesLista)
                {
                    EllipseGeometry ellipseGeometry = new EllipseGeometry(new Rect(Canvas.GetLeft(sajd), Canvas.GetTop(sajd), sajd.ActualWidth, sajd.ActualHeight));
                    RectangleGeometry rectangleGeometry = new RectangleGeometry(new Rect(Canvas.GetLeft(kes), Canvas.GetTop(kes), kes.ActualWidth, kes.ActualHeight));
                    if (ellipseGeometry.FillContainsWithDetail(rectangleGeometry) != IntersectionDetail.Empty)
                    {
                        End();
                    }
                }
            }
            if (Canvas.GetTop(sajd) <= 0 || Canvas.GetTop(sajd) + sajd.ActualHeight >= mainCanvas.ActualHeight)
            {
                End();
            }
        }
        int tickNum = 0;
        private void SpawnTimer_Tick(object sender, EventArgs e)
        {
            tickNum++;
            if (tickNum == 4)
            {
                pontTimer.Start();
            }
            Spawn();
        }
        private void Spawn()
        {
            double randomTop = kesek.RandomTop();
            mainCanvas.Children.Add(kesek.LefeleKesLetrehozas(randomTop));
            mainCanvas.Children.Add(kesek.FelfeleKesLetrehozas(randomTop));
        }
        int pont = 0;
        private void PontTimer_Tick(Object sender, EventArgs e)
        {
            pont++;
            pontszam.Text = pont.ToString();
        }

        private void SpaceDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
				double currentTop = Canvas.GetTop(sajd);
				if (!esos)
                {
					Canvas.SetTop(sajd, currentTop - 20);
				}
                else
                {
                    Canvas.SetTop(sajd, currentTop - 10);
                }
                speed = 1;
			}
        }
        
		private void Button_Click(object sender, RoutedEventArgs e)
		{
            esos = false;
            kodos = false;
            Start();
		}
		private void Esos_Click(object sender, RoutedEventArgs e)
		{
            esos = true;
            kodos = false;
            Start();
		}

		private void Kodos_Click(object sender, RoutedEventArgs e)
		{
            esos = false;
            kodos = true;
            Start();
		}
        private void Ujra_Click(object sender, RoutedEventArgs e)
        {
            Canvas.SetTop(sajd, 120);
            pont = 0;
            speed = 1;
            Start();
        }
		private void Start()
        {
			sp.Visibility = Visibility.Hidden;
			sajd.Visibility = Visibility.Visible;
			pontszam.Visibility = Visibility.Visible;
            if (esos)
            {
                esoshatter.Visibility = Visibility.Visible;
            }
            else if (kodos)
            {
                hatter.Visibility = Visibility.Visible;
                kod.Visibility = Visibility.Visible;
            }
            else
            {
				hatter.Visibility = Visibility.Visible;
			}
            timer.Start();
            spawnTimer.Start();
		}
        private void End()
        {
            timer.Stop();
            spawnTimer.Stop();
            pontTimer.Stop();
            sajd.Visibility = Visibility.Hidden;
            hatter.Visibility = Visibility.Hidden;
            esoshatter.Visibility = Visibility.Hidden;
            kod.Visibility = Visibility.Hidden;
            pontszam.Visibility = Visibility.Hidden;
            foreach (Rectangle kes in kesek.KesLista)
            {
                kes.Visibility = Visibility.Hidden;
            }
            sp_end.Visibility = Visibility.Visible;
            tb_pont.Text = $"Pontszám: {pont}";
        }
	}
}