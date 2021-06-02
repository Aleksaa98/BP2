using Baze2;
using System;
using System.Collections.Generic;
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
using System.ComponentModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataRepository.Instance.GetAerodome();
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void OnPropertyChanged(string name)
        //{
        //    if(PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(name));
        //    }
        //}

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Combo.SelectedItem.ToString().Split(' ')[1] == "Aerodrom")
            {
                groupBoxCentrala.Visibility = Visibility.Hidden;
                groupBoxAvion.Visibility = Visibility.Hidden;
                groupBoxKompanija.Visibility = Visibility.Hidden;
                groupBoxOsoblje.Visibility = Visibility.Hidden;
                groupBoxLet.Visibility = Visibility.Hidden;
                groupBoxAerodrom.Visibility = Visibility.Visible;
                TextBP.Text = String.Empty;
                foreach (var item in DataRepository.Instance.GetAerodome())
                {
                    TextBP.Text += "ID: " + item.Id + "  Naziv: " + item.Naziv + "  Adresa: " + item.Adresa +"\n";
                }
            }
            else if(Combo.SelectedItem.ToString().Split(' ')[1] == "Avion")
            {
                groupBoxAerodrom.Visibility = Visibility.Hidden;
                groupBoxCentrala.Visibility = Visibility.Hidden;
                groupBoxKompanija.Visibility = Visibility.Hidden;
                groupBoxLet.Visibility = Visibility.Hidden;
                groupBoxOsoblje.Visibility = Visibility.Hidden;
                groupBoxAvion.Visibility = Visibility.Visible;
                TextBP.Text = String.Empty;
                foreach (var item in DataRepository.Instance.GetAvioni())
                {
                    TextBP.Text += "ID: " + item.Id + "  Naziv: " + item.Naziv + "  Broj Mesta: " + item.BrojMesta + "\n";
                }
            }
            else if (Combo.SelectedItem.ToString().Split(' ')[1] == "Centrala")
            {
                groupBoxAerodrom.Visibility = Visibility.Hidden;
                groupBoxAvion.Visibility = Visibility.Hidden;
                groupBoxKompanija.Visibility = Visibility.Hidden;
                groupBoxLet.Visibility = Visibility.Hidden;
                groupBoxOsoblje.Visibility = Visibility.Hidden;
                groupBoxCentrala.Visibility = Visibility.Visible;
                TextBP.Text = String.Empty;
                foreach (var item in DataRepository.Instance.GetCentrale())
                {
                    TextBP.Text += "ID: " + item.Id + "  Naziv: " + item.Naziv  + "\n";
                }
            }
            else if (Combo.SelectedItem.ToString().Split(' ')[1] == "Kompanija")
            {
                groupBoxAerodrom.Visibility = Visibility.Hidden;
                groupBoxAvion.Visibility = Visibility.Hidden;
                groupBoxCentrala.Visibility = Visibility.Hidden;
                groupBoxLet.Visibility = Visibility.Hidden;
                groupBoxOsoblje.Visibility = Visibility.Hidden;
                groupBoxKompanija.Visibility = Visibility.Visible;
                TextBP.Text = String.Empty;
                foreach (var item in DataRepository.Instance.GetKompanije())
                {
                    TextBP.Text += "ID: " + item.Id + "  Naziv: " + item.Naziv + "\n";
                }
            }
            else if (Combo.SelectedItem.ToString().Split(' ')[1] == "Let")
            {
                groupBoxAerodrom.Visibility = Visibility.Hidden;
                groupBoxAvion.Visibility = Visibility.Hidden;
                groupBoxCentrala.Visibility = Visibility.Hidden;
                groupBoxKompanija.Visibility = Visibility.Hidden;
                groupBoxOsoblje.Visibility = Visibility.Hidden;
                groupBoxLet.Visibility = Visibility.Visible;
                TextBP.Text = String.Empty;
                foreach (var item in DataRepository.Instance.GetLetovi())
                {
                    TextBP.Text += "ID: " + item.Id + "  MestoPolaska: " + item.MestoPolaska + "  Destinacija: " + item.Destinacija + "\n" + "  Datum: " + item.Datum + "  Vreme: " + item.Vreme + "\n\n";
                }
            }
            else if (Combo.SelectedItem.ToString().Split(' ')[1] == "Osoblje")
            {
                groupBoxAerodrom.Visibility = Visibility.Hidden;
                groupBoxAvion.Visibility = Visibility.Hidden;
                groupBoxCentrala.Visibility = Visibility.Hidden;
                groupBoxKompanija.Visibility = Visibility.Hidden;
                groupBoxLet.Visibility = Visibility.Hidden;
                groupBoxOsoblje.Visibility = Visibility.Visible;
                TextBP.Text = String.Empty;
                foreach (var item in DataRepository.Instance.GetOsobljes())
                {
                    if (item is Pilot)
                    {
                        TextBP.Text += "PILOT: ";
                    }
                    else
                    {
                        TextBP.Text += "OP_LETOVA: ";
                    }
                    TextBP.Text += "ID: " + item.Id + "  Ime: " + item.Ime + "  Prezime: " + item.Prezime + "  AerodromId: " + item.AerodromId + "\n";
                }
            }
        }

        #region AERODROM

        private void AddAerodrom_Click(object sender, RoutedEventArgs e)
        {
            if(nazivAerodrom.Text != string.Empty && adresaAerodrom.Text != string.Empty)
            {
                Aerodrom a = new Aerodrom
                {
                    Naziv = nazivAerodrom.Text,
                    Adresa = adresaAerodrom.Text
                };

                DataRepository.Instance.AddAerodrom(a);
                TextBP.Text = string.Empty;
                foreach (var item in DataRepository.Instance.GetAerodome())
                {
                    TextBP.Text += "ID: " + item.Id + "  Naziv: " + item.Naziv + "  Adresa: " + item.Adresa +"\n";
                }
            }
            else 
            {
                MessageBox.Show("Fill out all needed properties","ERROR",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void EditAerodrom_Click(object sender, RoutedEventArgs e)
        {
            if (idAerodrom1.Text != string.Empty && (nazivAerodrom.Text != string.Empty || adresaAerodrom.Text != string.Empty))
            {
                Aerodrom a = new Aerodrom
                {
                    Naziv = nazivAerodrom.Text,
                    Adresa = adresaAerodrom.Text,
                    Id = Int32.Parse(idAerodrom1.Text)
                };

                bool provera = DataRepository.Instance.ModifyAerodrom(a);
                
                if(provera)
                {
                    a = DataRepository.Instance.GetAerodrom(Int32.Parse(idAerodrom1.Text));

                    TextBP.Text = string.Empty;
                    TextBP.Text += "ID: " + a.Id + "  Naziv: " + a.Naziv + "  Adresa: " + a.Adresa + "\n";

                }
                else
                {
                    MessageBox.Show("Entity with this ID doesn not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteAerodrom_Click(object sender, RoutedEventArgs e)
        {
            if (idAerodrom2.Text != string.Empty)
            {
                bool provera = DataRepository.Instance.DeleteAerodrom(Int32.Parse(idAerodrom2.Text));

                TextBP.Text = string.Empty;
                if (provera)
                    foreach (var item in DataRepository.Instance.GetAerodome())
                    {
                        TextBP.Text += "ID: " + item.Id + "  Naziv: " + item.Naziv + "  Adresa: " + item.Adresa + "\n";
                    }
                else
                    MessageBox.Show("Entity with this ID does not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetAerodrom_Click(object sender, RoutedEventArgs e)
        {
            if(idAerodrom2.Text != string.Empty)
            {
                Aerodrom a = DataRepository.Instance.GetAerodrom(Int32.Parse(idAerodrom2.Text));

                TextBP.Text = string.Empty;
                if (a != null)
                    TextBP.Text += "ID: " + a.Id + "  Naziv: " + a.Naziv + "  Adresa: " + a.Adresa + "\n";
                else
                    MessageBox.Show("Entity with this ID does not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region AVION

        private void AddAvion_Click(object sender, RoutedEventArgs e)
        {
            Aerodrom aerodrom = null;
            Centrala centrala = null;
            if ( centralaIDAvion.Text != string.Empty && aerodromIdAvion.Text != string.Empty && nazivAvion.Text != string.Empty && mestaAvion.Text != string.Empty)
            {
                Avion a = new Avion
                {
                    Naziv = nazivAvion.Text,
                    BrojMesta = mestaAvion.Text,
                };
                centrala = DataRepository.Instance.GetCentrala(Int32.Parse(centralaIDAvion.Text));
                aerodrom = DataRepository.Instance.GetAerodrom(Int32.Parse(aerodromIdAvion.Text));

                if(centrala != null & aerodrom != null)
                {
                    a.CentralaId = Int32.Parse(centralaIDAvion.Text);
                    a.AerodromId = Int32.Parse(aerodromIdAvion.Text);
                    DataRepository.Instance.AddAvion(a);
                    TextBP.Text = string.Empty;
                    foreach (var item in DataRepository.Instance.GetAvioni())
                    {
                        TextBP.Text += "ID: " + item.Id + "  Naziv: " + item.Naziv + "  Broj Mesta: " + item.BrojMesta + "\n";
                    }
                }
                else
                {
                    MessageBox.Show("There is no centrala or aerodrom with this ID", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditAvion_Click(object sender, RoutedEventArgs e)
        {
            Aerodrom aerodrom = null;
            Centrala centrala = null;
            if (idAvion1.Text != string.Empty && (centralaIDAvion.Text != string.Empty || aerodromIdAvion.Text != string.Empty || nazivAvion.Text != string.Empty || mestaAvion.Text != string.Empty))
            {
                Avion a = new Avion
                {
                    Naziv = nazivAvion.Text,
                    BrojMesta = mestaAvion.Text,
                    Id = Int32.Parse(idAvion1.Text),
                };

                if (centralaIDAvion.Text != string.Empty)
                {
                    a.CentralaId = Int32.Parse(centralaIDAvion.Text);
                    centrala = DataRepository.Instance.GetCentrala(a.CentralaId);
                }
                else
                    a.CentralaId = 0;
                if (centralaIDAvion.Text != string.Empty)
                {
                    a.AerodromId = Int32.Parse(aerodromIdAvion.Text);
                    aerodrom = DataRepository.Instance.GetAerodrom(a.AerodromId);
                }
                else
                    a.AerodromId = 0;

                if ((centrala != null && aerodrom != null)  ||  a.AerodromId == 0)
                {
                    bool provera = DataRepository.Instance.ModifyAvion(a);

                    if (provera)
                    {
                        a = DataRepository.Instance.GetAvion(Int32.Parse(idAvion1.Text));

                        TextBP.Text = string.Empty;
                        TextBP.Text += "ID: " + a.Id + "  Naziv: " + a.Naziv + "  BrojMesta: " + a.BrojMesta + "\n";
                    }
                    else
                    {
                        MessageBox.Show("Entity with this ID doesn not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Entity Aerodrom or Centrala with this ID doesn not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteAvion_Click(object sender, RoutedEventArgs e)
        {
            if (idAvion2.Text != string.Empty)
            {
                bool provera = DataRepository.Instance.DeleteAvion(Int32.Parse(idAvion2.Text));
                TextBP.Text = string.Empty;
                if (provera)
                    foreach (var item in DataRepository.Instance.GetAvioni())
                    {
                        TextBP.Text += "ID: " + item.Id + "  Naziv: " + item.Naziv + "  Broj Mesta: " + item.BrojMesta + "\n";
                    }
                else
                    MessageBox.Show("Entity with this ID does not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetAvion_Click(object sender, RoutedEventArgs e)
        {
            if (idAvion2.Text != string.Empty)
            {
                Avion a = DataRepository.Instance.GetAvion(Int32.Parse(idAvion2.Text));

                TextBP.Text = string.Empty;
                if(a != null)
                    TextBP.Text += "ID: " + a.Id + "  Naziv: " + a.Naziv + "  Broj Mesta: " + a.BrojMesta + "\n";
                else
                    MessageBox.Show("Entity with this ID does not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        #endregion

        #region CENTRALA

        private void AddCentrala_Click(object sender, RoutedEventArgs e)
        {
            if (nazivCentrala.Text != string.Empty)
            {
                Centrala c = new Centrala
                {
                    Naziv = nazivCentrala.Text,
                };

                DataRepository.Instance.AddCentrala(c);
                TextBP.Text = string.Empty;
                foreach (var item in DataRepository.Instance.GetCentrale())
                {
                    TextBP.Text += "ID: " + item.Id + "  Naziv: " + item.Naziv + "\n";
                }
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditCentrala_Click(object sender, RoutedEventArgs e)
        {
            if (idCentrala1.Text != string.Empty && nazivCentrala.Text != string.Empty)
            {
                Centrala c = new Centrala
                {
                    Naziv = nazivCentrala.Text,
                    Id = Int32.Parse(idCentrala1.Text)
                };

                bool provera = DataRepository.Instance.ModifyCentrala(c);

                if(provera)
                {
                    c = DataRepository.Instance.GetCentrala(Int32.Parse(idCentrala1.Text));

                    TextBP.Text = string.Empty;
                    TextBP.Text += "ID: " + c.Id + "  Naziv: " + c.Naziv + "\n";
                }
                else
                {
                    MessageBox.Show("Entity with this ID does not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteCentrala_Click(object sender, RoutedEventArgs e)
        {
            if (idCentrala2.Text != string.Empty)
            {
                bool provera = DataRepository.Instance.DeleteCentrala(Int32.Parse(idCentrala2.Text));

                TextBP.Text = string.Empty;
                if (provera)
                    foreach (var item in DataRepository.Instance.GetCentrale())
                    {
                        TextBP.Text += "ID: " + item.Id + "  Naziv: " + item.Naziv + "\n";
                    }
                else
                    MessageBox.Show("Entity with this ID does not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetCentrala_Click(object sender, RoutedEventArgs e)
        {
            if (idCentrala2.Text != string.Empty)
            {
                Centrala c = DataRepository.Instance.GetCentrala(Int32.Parse(idCentrala2.Text));

                TextBP.Text = string.Empty;
                if (c != null)
                    TextBP.Text += "ID: " + c.Id + "  Naziv: " + c.Naziv + "\n";
                else
                    MessageBox.Show("Entity with this ID does not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        #endregion

        #region KOMPANIJA
        private void AddKompanija_Click(object sender, RoutedEventArgs e)
        {
            if (nazivKompanija.Text != string.Empty)
            {
                Kompanija k = new Kompanija
                {
                    Naziv = nazivKompanija.Text,
                };

                DataRepository.Instance.AddKompanija(k);
                TextBP.Text = string.Empty;
                foreach (var item in DataRepository.Instance.GetKompanije())
                {
                    TextBP.Text += "ID: " + item.Id + "  Naziv: " + item.Naziv + "\n";
                }
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditKompanija_Click(object sender, RoutedEventArgs e)
        {
            if (idKompanija1.Text != string.Empty && nazivKompanija.Text != string.Empty)
            {
                Kompanija k = new Kompanija
                {
                    Naziv = nazivKompanija.Text,
                    Id = Int32.Parse(idKompanija1.Text)
                };

                bool provera = DataRepository.Instance.ModifyKompanija(k);

                if (provera)
                {
                    k = DataRepository.Instance.GetKompanija(Int32.Parse(idKompanija1.Text));

                    TextBP.Text = string.Empty;
                    TextBP.Text += "ID: " + k.Id + "  Naziv: " + k.Naziv + "\n";
                }
                else
                {
                    MessageBox.Show("Entity with this ID does not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteKompanja_Click(object sender, RoutedEventArgs e)
        {
            if (idKompanija2.Text != string.Empty)
            {
                bool provera = DataRepository.Instance.DeleteKompanija(Int32.Parse(idKompanija2.Text));

                TextBP.Text = string.Empty;
                if (provera)
                    foreach (var item in DataRepository.Instance.GetKompanije())
                    {
                        TextBP.Text += "ID: " + item.Id + "  Naziv: " + item.Naziv + "\n";
                    }
                else
                    MessageBox.Show("Entity with this ID does not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetKompanija_Click(object sender, RoutedEventArgs e)
        {
            if (idKompanija2.Text != string.Empty)
            {
                Kompanija K = DataRepository.Instance.GetKompanija(Int32.Parse(idKompanija2.Text));

                TextBP.Text = string.Empty;
                if (K != null)
                    TextBP.Text += "ID: " + K.Id + "  Naziv: " + K.Naziv + "\n";
                else
                    MessageBox.Show("Entity with this ID does not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region LET

        private void AddLet_Click(object sender, RoutedEventArgs e)
        {
            Centrala centrala = null;

            if (CentralaIdLet.Text != string.Empty && Destinacija.Text != string.Empty && MestoPolaska.Text != string.Empty && DatumLet.Text != string.Empty && VremeLet.Text != string.Empty)
            {
                Let let = new Let
                {
                    Destinacija = Destinacija.Text,
                    MestoPolaska = MestoPolaska.Text,
                    Datum = DatumLet.Text,
                    Vreme = VremeLet.Text
                };

                centrala = DataRepository.Instance.GetCentrala(Int32.Parse(CentralaIdLet.Text));

                if(centrala != null)
                {
                    let.CentralaId = Int32.Parse(CentralaIdLet.Text);
                    DataRepository.Instance.AddLet(let);
                    TextBP.Text = string.Empty;
                    foreach (var item in DataRepository.Instance.GetLetovi())
                    {
                        TextBP.Text += "ID: " + item.Id + "  MestoPolaska: " + item.MestoPolaska + "  Destinacija: " + item.Destinacija + "\n" + "  Datum: " + item.Datum + "  Vreme: " + item.Vreme + "\n\n";
                    }
                }
                else
                {
                    MessageBox.Show("There is no Centrala with this ID", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditLet_Click(object sender, RoutedEventArgs e)
        {
            Centrala c = null;
            if (idLet1.Text != string.Empty && (Destinacija.Text != string.Empty || MestoPolaska.Text != string.Empty || VremeLet.Text != string.Empty || DatumLet.Text != string.Empty || CentralaIdLet.Text != string.Empty))
            {
                Let let = new Let
                {
                    Id = Int32.Parse(idLet1.Text),
                    Destinacija = Destinacija.Text,
                    MestoPolaska = MestoPolaska.Text,
                    Vreme = VremeLet.Text,
                    Datum = DatumLet.Text
                };

                if (CentralaIdLet.Text != string.Empty)
                {
                    let.CentralaId = Int32.Parse(CentralaIdLet.Text);
                    c = DataRepository.Instance.GetCentrala(let.CentralaId);
                }   
                else
                    let.CentralaId = 0;

                
                if( c != null || let.CentralaId == 0)
                {
                    bool provera = DataRepository.Instance.ModifyLet(let);

                    if (provera)
                    {
                        let = DataRepository.Instance.GetLet(Int32.Parse(idLet1.Text));

                        TextBP.Text = string.Empty;
                        TextBP.Text += "ID: " + let.Id + "  MestoPolaska: " + let.MestoPolaska + "  Destinacija: " + let.Destinacija + "\n" + "  Datum: " + let.Datum + "  Vreme: " + let.Vreme + "\n\n";
                    }
                    else
                    {
                        MessageBox.Show("Entity with this ID doesn not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Entity Centrala with this ID doesn not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteLet_Click(object sender, RoutedEventArgs e)
        {
            if (idLet2.Text != string.Empty)
            {
                bool provera = DataRepository.Instance.DeleteLet(Int32.Parse(idLet2.Text));

                TextBP.Text = string.Empty;
                if (provera)
                    foreach (var item in DataRepository.Instance.GetLetovi())
                    {
                        TextBP.Text += "ID: " + item.Id + "  MestoPolaska: " + item.MestoPolaska + "  Destinacija: " + item.Destinacija + "\n" + "  Datum: " + item.Datum + "  Vreme: " + item.Vreme + "\n\n";
                    }
                else
                    MessageBox.Show("Entity with this ID does not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetLet_Click(object sender, RoutedEventArgs e)
        {
            if (idLet2.Text != string.Empty)
            {
                Let let = DataRepository.Instance.GetLet(Int32.Parse(idLet2.Text));

                TextBP.Text = string.Empty;
                if (let != null)
                    TextBP.Text += "ID: " + let.Id + "  MestoPolaska: " + let.MestoPolaska + "  Destinacija: " + let.Destinacija + "\n" + "  Datum: " + let.Datum + "  Vreme: " + let.Vreme + "\n\n";
                else
                    MessageBox.Show("Entity with this ID does not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        #endregion

        #region OSOBLJE

        private void AddOsoblje_Click(object sender, RoutedEventArgs e)
        {
            Aerodrom aerodrom = null;
            Centrala centrala = null;
            bool provera = true;
         
            if (aerodromIdOsoblje.Text != string.Empty && imeOsoblje.Text != string.Empty && prezimeOsoblje.Text != string.Empty && comboOsoblje.SelectedItem != null)
            {
                aerodrom = DataRepository.Instance.GetAerodrom(Int32.Parse(aerodromIdOsoblje.Text));
                if(centralaOsoblje.Text != string.Empty)
                    centrala = DataRepository.Instance.GetCentrala(Int32.Parse(centralaOsoblje.Text));
                TextBP.Text = string.Empty;
                if (aerodrom != null)
                {
                    if (comboOsoblje.SelectedItem.ToString().Split(' ')[1] == "Pilot")
                    {
                        Pilot pilot = new Pilot();
                        pilot.AerodromId = Int32.Parse(aerodromIdOsoblje.Text);
                        pilot.Ime = imeOsoblje.Text;
                        pilot.Prezime = prezimeOsoblje.Text;

                        DataRepository.Instance.AddOsoblje(pilot);
                      
                    }
                    else if (comboOsoblje.SelectedItem.ToString().Split(' ')[1] == "OperatorLetova")
                    {
                        if (centrala != null)
                        {
                            Op_Letova op = new Op_Letova();
                            op.AerodromId = Int32.Parse(aerodromIdOsoblje.Text);
                            op.Ime = imeOsoblje.Text;
                            op.Prezime = prezimeOsoblje.Text;
                            op.CentralaId = Int32.Parse(centralaOsoblje.Text);

                            DataRepository.Instance.AddOsoblje(op);
                            
                        }
                        else
                        {
                            MessageBox.Show("There is no centrala with this ID", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                       
                    }

                    foreach (var item in DataRepository.Instance.GetOsobljes())
                    {
                        if (item is Pilot)
                        {
                            TextBP.Text += "PILOT: ";
                        }
                        else
                        {
                            TextBP.Text += "OP_LETOVA: ";
                        }
                        TextBP.Text += "ID: " + item.Id + "  Ime: " + item.Ime + "  Prezime: " + item.Prezime + "  AerodromId: " + item.AerodromId + "\n";
                    }
                }
                else
                {
                    MessageBox.Show("There is no aerodrom with this ID", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditOsoblje_Click(object sender, RoutedEventArgs e)
        {
            Aerodrom aerodrom = null;

            if (idOsoblje1.Text != string.Empty && (imeOsoblje.Text != string.Empty || prezimeOsoblje.Text != string.Empty || aerodromIdOsoblje.Text != string.Empty || centralaOsoblje.Text != string.Empty))
            {
                Osoblje osoba = DataRepository.Instance.GetOsoblje(Int32.Parse(idOsoblje1.Text));

                if (osoba != null)
                {
                    if (osoba is Pilot)
                    {
                        Pilot pilot = new Pilot();
                        pilot.Ime = imeOsoblje.Text;
                        pilot.Prezime = prezimeOsoblje.Text;
                        pilot.Id = Int32.Parse(idOsoblje1.Text);

                        if (aerodromIdOsoblje.Text != string.Empty)
                            aerodrom = DataRepository.Instance.GetAerodrom(Int32.Parse(aerodromIdOsoblje.Text));

                        if (aerodrom == null)
                            pilot.AerodromId = 0;
                        else
                            pilot.AerodromId = Int32.Parse(aerodromIdOsoblje.Text);

                        DataRepository.Instance.ModifyOsoblje(pilot);

                    }
                    else if (osoba is Op_Letova)
                    {
                        Op_Letova op = new Op_Letova();
                        op.Ime = imeOsoblje.Text;
                        op.Prezime = prezimeOsoblje.Text;
                        op.Id = Int32.Parse(idOsoblje1.Text);

                        if (aerodromIdOsoblje.Text != string.Empty)
                            aerodrom = DataRepository.Instance.GetAerodrom(Int32.Parse(aerodromIdOsoblje.Text));

                        if (aerodrom == null)
                            op.AerodromId = 0;
                        else
                            op.AerodromId = Int32.Parse(aerodromIdOsoblje.Text);

                        DataRepository.Instance.ModifyOsoblje(op);
                    }

                    TextBP.Text = String.Empty;

                    foreach (var item in DataRepository.Instance.GetOsobljes())
                    {
                        if(item is Pilot)
                        {
                            TextBP.Text += "PILOT: ";
                        }
                        else
                        {
                            TextBP.Text += "OP_LETOVA: ";
                        }
                        TextBP.Text += "ID: " + item.Id + "  Ime: " + item.Ime + "  Prezime: " + item.Prezime + "  AerodromId: " + item.AerodromId + "\n";
                    }

                }
                else
                {
                    MessageBox.Show("There is no osoba with this ID", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteOsoblje_Click(object sender, RoutedEventArgs e)
        {
            if (idOsoblje2.Text != string.Empty)
            {
                bool provera = DataRepository.Instance.DeleteOsoblje(Int32.Parse(idOsoblje2.Text));

                TextBP.Text = string.Empty;
                if (provera)
                    foreach (var item in DataRepository.Instance.GetOsobljes())
                    {
                        if (item is Pilot)
                        {
                            TextBP.Text += "PILOT: ";
                        }
                        else
                        {
                            TextBP.Text += "OP_LETOVA: ";
                        }
                        TextBP.Text += "ID: " + item.Id + "  Ime: " + item.Ime + "  Prezime: " + item.Prezime + "  AerodromId: " + item.AerodromId + "\n";
                    }
                else
                    MessageBox.Show("Entity with this ID does not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetOsoblje_Click(object sender, RoutedEventArgs e)
        {
            if (idOsoblje2.Text != string.Empty)
            {
                Osoblje osoba = DataRepository.Instance.GetOsoblje(Int32.Parse(idOsoblje2.Text));

                TextBP.Text = string.Empty;
                if (osoba != null)
                {
                    if (osoba is Pilot)
                    {
                        TextBP.Text += "PILOT: ";
                    }
                    else
                    {
                        TextBP.Text += "OP_LETOVA: ";
                    }
                    TextBP.Text += "ID: " + osoba.Id + "  Ime: " + osoba.Ime + "  Prezime: " + osoba.Prezime + "  AerodromId: " + osoba.AerodromId + "\n";
                } 
                else
                    MessageBox.Show("Entity with this ID does not exits", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Fill out all needed properties", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        #endregion

  
    }
}
