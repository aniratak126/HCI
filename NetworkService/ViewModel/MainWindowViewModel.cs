using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using System.Xml;
using NetworkService.AdditionalElements;
using NetworkService.Model;
using System.Collections.ObjectModel;

namespace NetworkService.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {

        public MyICommand<string> NavCommand { get; private set; }
        private NetworkEntitiesViewModel networkEntitiesViewModel = new NetworkEntitiesViewModel();
        private NetworkDisplayViewModel networkDisplayViewModel = new NetworkDisplayViewModel();

        private BindableBase currentViewModel;

        private int count = NetworkEntitiesViewModel.Reactor.Count; // Inicijalna vrednost broja objekata u sistemu
                                                                      // ######### ZAMENITI stvarnim brojem elemenata
                                                                      //           zavisno od broja entiteta u listi

        private Uri path = new Uri("LogFile.txt", UriKind.Relative); //novo
        private static ObservableCollection<Reactor> ListObj { get; set; } //novo
        private bool file = false;//novo
        private int id;//novo
        private double value;//novo
        public MainWindowViewModel()
        {
            // File.WriteAllText(path, "");
            ListObj = new ObservableCollection<Reactor>();//novo
            createListener(); //Povezivanje sa serverskom aplikacijom

            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = networkEntitiesViewModel;  //koji je prozor pocetni otvoren

        }

        public BindableBase CurrentViewModel  //trenutrni view model
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        private void OnNav(string destination)  //funkcije koja odredjuje koji je prozor otvoren
        {
            switch (destination)
            {
                case "entity":
                    CurrentViewModel = networkEntitiesViewModel;
                    break;
                case "display":
                    CurrentViewModel = networkDisplayViewModel;
                    break;

            }
        }

        private void createListener()
        {
            var tcp = new TcpListener(IPAddress.Any, 25567);
            tcp.Start();

            var listeningThread = new Thread(() =>
            {
                while (true)
                {
                    var tcpClient = tcp.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(param =>
                    {
                        //Prijem poruke
                        NetworkStream stream = tcpClient.GetStream();
                        string incomming;
                        byte[] bytes = new byte[1024];
                        int i = stream.Read(bytes, 0, bytes.Length);
                        //Primljena poruka je sacuvana u incomming stringu
                        incomming = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                        //Ukoliko je primljena poruka pitanje koliko objekata ima u sistemu -> odgovor
                        if (incomming.Equals("Need object count"))
                        {
                            //Response
                            /* Umesto sto se ovde salje count.ToString(), potrebno je poslati
                             * duzinu liste koja sadrzi sve objekte pod monitoringom, odnosno
                             * njihov ukupan broj (NE BROJATI OD NULE, VEC POSLATI UKUPAN BROJ)
                             * */
                            Byte[] data = System.Text.Encoding.ASCII.GetBytes(NetworkEntitiesViewModel.Reactor.Count().ToString());
                            stream.Write(data, 0, data.Length);
                            file = false;
                        }
                        else
                        {
                            //U suprotnom, server je poslao promenu stanja nekog objekta u sistemu
                            Console.WriteLine(incomming); //Na primer: "Entitet_1:272"
                            string[] split = incomming.Split('_', ':');   /// splitujemo tj izbacujemo _ i :
                            //ostaje nam Entitet 1 272
                            int index = Int32.Parse(split[1]);  //uzmemo 1
                            if (NetworkEntitiesViewModel.Reactor.Count > index)
                                id = NetworkEntitiesViewModel.Reactor[index].Id;
                            else
                                id = -1;
                            value = double.Parse(split[2]); //uzmemo 272
                            Reactor pz = new Reactor(id);
                            if (id != -1)
                            {
                                NetworkEntitiesViewModel.Reactor[index].Value = value;
                                UpisUFajl();
                            }

                            //################ IMPLEMENTACIJA ####################
                            // Obraditi poruku kako bi se dobile informacije o izmeni
                            // Azuriranje potrebnih stvari u aplikaciji

                        }
                    }, null);
                }
            });

            listeningThread.IsBackground = true;
            listeningThread.Start();
        }

        private void UpisUFajl() //logujemo u txt fajl koji se nalazi u bin/debug
        {
            if (!file)
            {
                StreamWriter wr;
                using (wr = new StreamWriter(path.ToString()))
                {
                    wr.WriteLine("Date Time:\t" + DateTime.Now.ToString() + "\tObject_" + id + "\tValue:\t" + value);
                }
            }
            else
            {
                StreamWriter wr;
                using (wr = new StreamWriter(path.ToString(), true))
                {
                    wr.WriteLine("Date Time:\t" + DateTime.Now.ToString() + "\tObject_" + id + "\tValue:\t" + value);
                }
            }
            file = true;
        }

    }
}
