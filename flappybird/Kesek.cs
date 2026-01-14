using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace flappybird
{
	internal class Kesek
	{
		List<Rectangle> kesLista;

		public Kesek()
		{
			kesLista = new List<Rectangle>();
		}

		public List<Rectangle> KesLista { get => kesLista; }


		Random rnd = new Random();
		public double RandomTop()
		{
			return -250 + rnd.NextDouble() * 100;
		}
		public Rectangle LefeleKesLetrehozas(double randomY)
		{
			Rectangle kesLe = new Rectangle();
			kesLe.Width = 75;
			kesLe.Height = 350;
			Canvas.SetTop(kesLe, randomY);
			Canvas.SetLeft(kesLe, 700);
			kesLe.Fill = new ImageBrush
			{
				ImageSource = new BitmapImage(
					new Uri("./Images/kesle.png", UriKind.Relative)
				)
			};
			kesLista.Add(kesLe);
			return kesLe;
		}
		public Rectangle FelfeleKesLetrehozas(double randomY)
		{
			Rectangle kesFel = new Rectangle();
			kesFel.Width = 75;
			kesFel.Height = 350;
			Canvas.SetTop(kesFel, randomY + 450);
			Canvas.SetLeft(kesFel, 700);
			kesFel.Fill = new ImageBrush
			{
				ImageSource = new BitmapImage(
					new Uri("./Images/kes.png", UriKind.Relative)
				)
			};
			kesLista.Add(kesFel);
			return kesFel;
		}
	}
}
