using System;
using System.Collections.Generic;
using System.IO;
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

namespace KomedijaFilm
{
    /// <summary>
    /// Interaction logic for Prikaz.xaml
    /// </summary>
    public partial class Prikaz : Window
    {
        public Prikaz(Komedija komedija)
        {
            InitializeComponent();

            Naziv.Text = "Naziv: " + komedija.Naziv;
            ProdKuca.Text = "Produkcijska kuca: " + komedija.ProdukcijskaKuca;
            Trajanje.Text = "Trajanje Filma: " + komedija.TrajanjeMin + " min";
            Premijera.Text = "Premijera: " + komedija.DatumPremijere.ToShortDateString(); 
            FilmImg.Source = new BitmapImage(new Uri(komedija.PutanjaSlike));

            TextRange txtRange;
            FileStream fileStream;
            if (File.Exists(komedija.Rtf))
            {
                txtRange = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                fileStream = new FileStream(komedija.Rtf, System.IO.FileMode.OpenOrCreate);
                txtRange.Load(fileStream, DataFormats.Rtf);

                fileStream.Close();
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void IzlazBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
