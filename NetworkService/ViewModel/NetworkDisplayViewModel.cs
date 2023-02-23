using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using NetworkService.AdditionalElements;
using NetworkService.Model;


namespace NetworkService.ViewModel
{
    public class NetworkDisplayViewModel : BindableBase
    {
        public static BindingList<Reactor> ReactorDisplay { get; set; }
        public List<Canvas> CanvasList { get; set; } = new List<Canvas>();
        public static Dictionary<string, Reactor> ReactorCanvas { get; set; } = new Dictionary<string, Reactor>();


        private int selectedIndex = 0;
        public static Reactor draggedItem = null;
        private bool dragging = false;

        private static bool postoji = false;
        private ListView listViewItem;
        //private Canvas canvasViewItem;

        public MyICommand<Reactor> SelectionChangedCommand { get; set; }
        public MyICommand<ListView> MouseLeftButtonUpCommand { get; set; }
        public MyICommand<Canvas> DragOverCommand { get; set; }
        public MyICommand<Canvas> DragLeaveCommand { get; set; }
        public MyICommand<Canvas> DropCommand { get; set; }
        public MyICommand<Canvas> FreeCommand { get; set; }
        public MyICommand<Canvas> LoadCommand { get; set; }
        public MyICommand<ListView> LoadListViewCommand { get; set; }
   


        public MyICommand<Canvas> SelectionChangedCanvasCommand { get; set; }
        public MyICommand<Canvas> MouseLeftButtonUpCanvasCommand { get; set; }

        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndex");

            }
        }


        public NetworkDisplayViewModel()
        {
            ReactorDisplay = new BindingList<Reactor>();

            SelectionChangedCommand = new MyICommand<Reactor>(OnSelectionChanged);
            MouseLeftButtonUpCommand = new MyICommand<ListView>(OnMouseLeftButtonUp);
            DragOverCommand = new MyICommand<Canvas>(OnDragOver);
            DragLeaveCommand = new MyICommand<Canvas>(OnDragLeave);
            DropCommand = new MyICommand<Canvas>(OnDrop);
            FreeCommand = new MyICommand<Canvas>(OnFree);
            LoadCommand = new MyICommand<Canvas>(OnLoad);
            LoadListViewCommand = new MyICommand<ListView>(OnLoadListView);
            

            SelectionChangedCanvasCommand = new MyICommand<Canvas>(OnSelectionCanvasChanged);
            MouseLeftButtonUpCanvasCommand = new MyICommand<Canvas>(OnMouseLeftButtonUpCanvas);

            foreach (Reactor pz in NetworkEntitiesViewModel.Reactor)
            {
                postoji = false;
                foreach (Reactor pz2 in ReactorCanvas.Values)       
                {
                    if (pz.Id == pz2.Id)
                    {
                        postoji = true;
                        break;
                    }

                }
                if (postoji == false)
                    ReactorDisplay.Add(new Reactor() { Id = pz.Id, Naziv = pz.Naziv, Tip = pz.Tip, Value = pz.Value });
            }

        }

        public void OnSelectionChanged(Reactor pz)
        {
            if (!dragging)
            {
                dragging = true;
                draggedItem = pz;
                DragDrop.DoDragDrop(listViewItem, draggedItem, DragDropEffects.Move);
            }
        }

        public void OnMouseLeftButtonUp(ListView lw)
        {                                                                   // kada se izvrsi klik, sve se postavlja na pocetne vrednosti
            draggedItem = null;
            lw.SelectedItem = null;
            dragging = false;
        }

//############################################
        public void OnSelectionCanvasChanged(Canvas c)
        {
            if (!dragging)
            {
                if (c.Resources["taken"] != null)
                {
                    dragging = true;
                    draggedItem = ReactorCanvas[c.Name];

                    c.Background = Brushes.White;
                    c.Resources.Remove("taken");
                    ReactorCanvas.Remove(c.Name);
                    DragDrop.DoDragDrop(listViewItem, draggedItem, DragDropEffects.Move);
                }
            }
        }

        public void OnMouseLeftButtonUpCanvas(Canvas c)
        {

        }
//#############################################



        public void OnDragOver(Canvas c)
        {                                                                   // kada predjemo preko zauzete povrsine
            if (c.Resources["taken"] != null)
            {
                ((TextBlock)(c).Children[1]).Text = "ZAUZETO";
                ((TextBlock)(c).Children[1]).FontSize = 22;
                ((TextBlock)(c).Children[1]).FontWeight = FontWeights.ExtraBold;
                ((TextBlock)(c).Children[1]).Foreground = Brushes.DarkRed;
                ((TextBlock)(c).Children[1]).Background = Brushes.Black;

            }

        }

        public void OnDragLeave(Canvas c)
        {                                                                   // kada sklonimo kursor sa zauzete povrsine
            if (((TextBlock)(c).Children[1]).Text == "ZAUZETO")
            {
                ((TextBlock)(c).Children[1]).Text = "";
                ((TextBlock)(c).Children[1]).Background = Brushes.Transparent;
            }
        }

        public void OnDrop(Canvas c)   //spustamo objekat na kanvas
        {

            if (draggedItem != null)
            {
                if (c.Resources["taken"] == null)
                {
                    BitmapImage logo = new BitmapImage();

                    logo.BeginInit();
                    logo.UriSource = new Uri("pack://application:,,,/Images/" + draggedItem.Tip.Name.ToString() + ".jpg", UriKind.Absolute);
                    logo.EndInit();

                    c.Background = new ImageBrush(logo);
                    ReactorCanvas[c.Name] = draggedItem;
                    c.Resources.Add("taken", true); //postavljamo kanvas na ZAUZEET
                    ReactorDisplay.Remove(ReactorDisplay.Single(x => x.Id == draggedItem.Id));
                    SelectedIndex = 0;
                    CheckValue(c);
                }
                else
                { 
                    ((TextBlock)(c).Children[1]).Text = "";
                    ((TextBlock)(c).Children[1]).Background = Brushes.Transparent;
                }
                dragging = false;
            }
        }

        public void OnFree(Canvas c)                                     //kada brisemo objekat sa kanvasa
        {
            try
            {
                if (c.Resources["taken"] != null)
                {
                                                                          // uklanjamo sliku ako je ima
                    c.Background = Brushes.White;
                    foreach (Reactor pz in NetworkEntitiesViewModel.Reactor)
                    {
                        if (!ReactorDisplay.Contains(pz) && ReactorCanvas[c.Name].Id == pz.Id)
                            ReactorDisplay.Add(pz);
                    }
                    c.Resources.Remove("taken");
                    ReactorCanvas.Remove(c.Name);
                }
            }
            catch (Exception) { }

        }


        public void OnLoadListView(ListView listview)
        {
            //lv dobija vrednost ListView-a gde su obj
            listViewItem = listview;
        }

        public void OnLoad(Canvas c) //puni kanvas entitetima ako prelazimo sa prozora na prozor
        {
            if (ReactorCanvas.ContainsKey(c.Name))
            {
                BitmapImage logo = new BitmapImage();

                logo.BeginInit();
                string temp = ReactorCanvas[c.Name].Tip.Name.ToString() + ".jpg";
                logo.UriSource = new Uri("pack://application:,,,/Images/" + temp, UriKind.Absolute);
                logo.EndInit();

                c.Background = new ImageBrush(logo);
                ((TextBlock)(c).Children[1]).Text = "";
                c.Resources.Add("taken", true);

                CheckValue(c);

            }
            if (!CanvasList.Contains(c))
            {
                CanvasList.Add(c);
            }
        }

        private void CheckValue(Canvas c)  //funkcija na osnovu koje proveramo da li je vrednost iz simulatora u opsegu 250-350
        {
            Dictionary<int, Reactor> temp = new Dictionary<int, Reactor>();
            foreach (var pz in NetworkEntitiesViewModel.Reactor)
            {
                temp.Add(pz.Id, pz);
            }
            Task.Delay(1000).ContinueWith(_ =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    ((Border)(c).Children[0]).BorderBrush = Brushes.Transparent;

                    if (ReactorCanvas.Count != 0)
                    {
                        if (ReactorCanvas.ContainsKey(c.Name))
                        {
                            if (temp[ReactorCanvas[c.Name].Id].Value < 250 || temp[ReactorCanvas[c.Name].Id].Value > 350)
                            {
                                ((Border)(c).Children[0]).BorderBrush = Brushes.Red;   //ako je van opsega boji u crveno
                            }
                        }
                    }
                });
                CheckValue(c);
            });
        }

        

    }
}
