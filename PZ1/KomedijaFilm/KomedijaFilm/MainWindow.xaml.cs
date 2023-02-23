using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KomedijaFilm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public static BindingList<Komedija> BindingKomedija { get; set; }
        public MainWindow()
        {
            if (BindingKomedija == null)
                BindingKomedija = new BindingList<Komedija>();
            DataContext = this;
            InitializeComponent();
        }

        
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IzmenaBtn_Click(object sender, RoutedEventArgs e)
        {
            Komedija komedija = BindingKomedija[dataGridKomedija.SelectedIndex];
            Izmena izmena = new Izmena(komedija, dataGridKomedija.SelectedIndex);
            izmena.ShowDialog();
        }

        private void PrikazBtn_Click(object sender, RoutedEventArgs e)
        {
            Komedija komedija = BindingKomedija[dataGridKomedija.SelectedIndex];
            Prikaz prikaz = new Prikaz(komedija);
            prikaz.ShowDialog();

        }

        private void BrisanjeBtn_Click(object sender, RoutedEventArgs e)
        {
            BindingKomedija.RemoveAt(dataGridKomedija.SelectedIndex);
        }

        private void DodajBtn_Click(object sender, RoutedEventArgs e)
        {
            DodavanjeFilma noviFilm = new DodavanjeFilma();
            noviFilm.ShowDialog();

        }
    }
    
}
