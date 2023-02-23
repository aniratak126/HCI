using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using NetworkService.AdditionalElements;
using NetworkService.Model;

namespace NetworkService.ViewModel
{
    public class NetworkEntitiesViewModel : BindableBase
    {
        public static ObservableCollection<Reactor> Reactor { get; private set; } = new ObservableCollection<Reactor>(); //kolecija svih reaktora
        public static ObservableCollection<Reactor> ReactorSearch { get; private set; } = new ObservableCollection<Reactor>(); //kolekcija koju koristimo za search

        public static ObservableCollection<Model.Type> Tipovi { get; set; }
        Model.Type tipRtd = new Model.Type { Name = "RTDSensor", Img_src = AppDomain.CurrentDomain.BaseDirectory + "Images\\RTDSensor.jpg" };
        Model.Type tipTermoSprega = new Model.Type { Name = "TermoSpregaSensor", Img_src = AppDomain.CurrentDomain.BaseDirectory + "Images\\TermoSpregaSensor.jpg" };

        public static List<string> TipoviComboBox { get; set; } = new List<string> { "RTDSensor", "TermoSpregaSensor"};

        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        public MyICommand SearchCommand { get; set; }
        public MyICommand ResetCommand { get; set; }
        public MyICommand StartSimulatorCommand { get; set; }
        public MyICommand ShowHelpCommand { get; set; }
        public MyICommand NDCommand { get; set; }

        private Reactor selectedReactor;
        private string idText;
        private string nazivText;
        private string imagePath = "";
        private string pathBeforeImage = "pack://application:,,,/Images/";

        private bool feedBackOnOffND = true;
        private bool networkDataCheck = true;
        private string checkBoxName = "Enable FeedBack";
       

        //za Filter
        private static bool lower = true;
        private static bool higher = false;
        private static string searchText;

        private string selectedTip = string.Empty;
        private string selectedFilterTip = string.Empty;

        public NetworkEntitiesViewModel()
        {
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            AddCommand = new MyICommand(OnAdd);
            SearchCommand = new MyICommand(Search);
            ResetCommand = new MyICommand(ResetSearch);
            ShowHelpCommand = new MyICommand(ShowCommand);
            NDCommand = new MyICommand(OnNetworkData);
        }



        public string IdText
        {
            get { return idText; }
            set
            {
                if(idText != value)
                {
                    idText = value;
                    OnPropertyChanged("IdText");
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string NazivText
        {
            get { return nazivText; }
            set
            {
                if (nazivText != value)
                {
                    nazivText = value;
                    OnPropertyChanged("NazivText");

                }
            }
        }

        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        public bool Lower
        {
            get { return lower; }
            set
            {
                if (lower != value)
                {
                    lower = value;
                    OnPropertyChanged("Lower");
                }
            }
        }
        public bool Higher
        {
            get { return higher; }
            set
            {
                if (higher != value)
                {
                    higher = value;
                    OnPropertyChanged("Higher");
                }
            }
        }

        public bool FeedBackOnOffND
        {
            get { return feedBackOnOffND; }
            set
            {
                feedBackOnOffND = value;
                OnPropertyChanged("FeedBackOnOffND");
            }
        }
        public bool NetworkDataCheck
        {
            get { return networkDataCheck; }
            set
            {
                networkDataCheck = value;
            }
        }
        public string CheckBoxName
        {
            get { return checkBoxName; }
            set
            {
                checkBoxName = value;
                OnPropertyChanged("CheckBoxName");
            }
        }
        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    OnPropertyChanged("SearchText");
                }
            }
        }

        public Reactor SelectedReactor  //reaktor koji izaberemo da obrisemo
        {
            get { return selectedReactor; }
            set
            {
                selectedReactor = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public string SelectedTip           //tip koji smo izabrali u comboboxu za dodavanje novog reaktora
        {
            get { return selectedTip; }
            set
            {
                if(selectedTip != value)
                {
                    selectedTip = value;
                    ImagePath = pathBeforeImage + value.ToString() + ".jpg";
                    OnPropertyChanged("ImagePath");
                    OnPropertyChanged("SelectedTip");
                }
            }
        }
        public string SelectedFilterTip    //tip koji smo izabrali u comboboxu u xamlu za filter
        {
            get { return selectedFilterTip; }
            set
            {
                if (selectedFilterTip != value)
                {
                    selectedFilterTip = value;


                    OnPropertyChanged("SelectedFilterTip");
                }
            }
        }

        private bool CanDelete()
        {
            return SelectedReactor != null;
        }

        private void OnDelete()
        {
            Reactor.Remove(SelectedReactor);
            ResetSearch();
        }

        private void OnAdd()
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(idText);

                if (id < 0)
                {
                    System.Windows.MessageBox.Show("ID mora biti pozitivan broj.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                System.Windows.MessageBox.Show("ID mora biti ceo broj.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error); // ako nije broj
                return;
            }

            bool vecPostoji = false;

            foreach (Reactor pz in Reactor)
            {
                 if (pz.Id == id)
                 {
                   vecPostoji = true;
                 }
            }

            if (vecPostoji)
            {
                System.Windows.MessageBox.Show("ID mora biti jedinstven.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string naziv = NazivText;
            if (string.IsNullOrWhiteSpace(naziv))
            {
                System.Windows.MessageBox.Show("Naziv mora biti unet.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Model.Type tip;
            if(selectedTip == tipRtd.Name)
            {
                tip = tipRtd;
            }
            else if(selectedTip == tipTermoSprega.Name)
            {
                tip = tipTermoSprega;
            }
            else
            {
                System.Windows.MessageBox.Show("Tip mora biti izabran.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var vr = 0;  //dok ne ukljucimo simulator
            Reactor.Add(new Reactor { Id = id, Naziv = naziv, Tip = tip, Value = vr });
            ResetSearch();


        }

        private void Search()
        {

            if (SearchText != "")   //ZA KOMBINOVANO FILTRIRANJE I FILTIRANJE PREKO RADIO BUTTONA
            {

                if (Lower)
                {
                    ReactorSearch.Clear();

                        for (int i = 0; i < Reactor.Count; i++)
                        {
                            try
                            {
                                if (Reactor[i].Id < Convert.ToInt32(SearchText))
                                {
                                    ReactorSearch.Add(Reactor[i]);
                                }
                            }
                            catch {
                                System.Windows.MessageBox.Show("ID mora biti broj.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                }
                else
                {
                    ReactorSearch.Clear();

                        for (int i = 0; i < Reactor.Count; i++)
                        {
                            try
                            {
                                if (Reactor[i].Id > Convert.ToInt32(SearchText))
                                {
                                    ReactorSearch.Add(Reactor[i]);
                                }
                            }
                            catch
                            {
                                System.Windows.MessageBox.Show("ID mora biti broj.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                    }
                }
                if(SelectedFilterTip != "")
                {
                    foreach(var r in ReactorSearch)
                        {
                            if(SelectedFilterTip != r.Tip.Name)
                            {
                                ReactorSearch.Remove(r);
                            }
                        }

                }


            }
            else  //za filter samo preko TIPOVA
            {
                ReactorSearch.Clear();

                for (int i = 0; i < Reactor.Count; i++)
                {
                    if(SelectedFilterTip == Reactor[i].Tip.Name)
                        ReactorSearch.Add(Reactor[i]);
                }
            }
        }

        private void ResetSearch()
        {
            ReactorSearch.Clear();
            for(int i = 0; i < Reactor.Count; i++)
            {
                ReactorSearch.Add(Reactor[i]);
            }
            SearchText = "";
            Lower = true;
            Higher = false;
        }
        private void OnNetworkData()    //uklanjanje tooltipova
        {
            if (NetworkDataCheck) 
            {
                FeedBackOnOffND = false;
                NetworkDataCheck = false;

            }
            else
            {
                FeedBackOnOffND = true;
                NetworkDataCheck = true;

            }
        }

        private void ShowCommand()  //komanda za Help
        {
            System.Windows.MessageBox.Show("-Za dodavanje ispunite polja i zavrsite akciju pritiskom na dugme Add  - Za brisanje selektujte reaktor i kliknite dugme Delete", "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }


    }
}
