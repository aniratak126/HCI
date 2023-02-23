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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KomedijaFilm
{
    /// <summary>
    /// Interaction logic for Izmena.xaml
    /// </summary>
    public partial class Izmena : Window
    {
        public int Index { get; set; }
        public Izmena(Komedija komedija, int index)
        {
            InitializeComponent();

            FontFamilyCmbx.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            List<int> sizeList = new List<int>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            FontSizeCmbx.ItemsSource = sizeList;

            NazivTxb.Text = komedija.Naziv;
            ProdKucaTxb.Text = komedija.ProdukcijskaKuca;
            TrajanjeTxb.Text = komedija.TrajanjeMin.ToString();
            DatePicker.SelectedDate = komedija.DatumPremijere;
            FilmImg.Source = new BitmapImage(new Uri(komedija.PutanjaSlike));

            NazivLbl.Foreground = Brushes.LightSlateGray;
            ProdKucaLbl.Foreground = Brushes.LightSlateGray;
            TrajanjeLbl.Foreground = Brushes.LightSlateGray;

            Index = index;

            Type brushTypes = typeof(System.Windows.Media.Brushes);
            List<string> colorNames = new List<string>();
            var properties = brushTypes.GetProperties();
            foreach (var p in properties)
            {
                colorNames.Add(p.Name);
            }

            ColorCmbx.ItemsSource = colorNames;
            ColorCmbx.SelectedItem = colorNames.FirstOrDefault(c => c.Equals("Black"));



            TextRange txtRange;
            FileStream fileStream;
            if (File.Exists(komedija.Rtf))
            {
                txtRange = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                fileStream = new FileStream(komedija.Rtf, FileMode.OpenOrCreate);
                txtRange.Load(fileStream, System.Windows.DataFormats.Rtf);

                char[] splitWordsBy = "\r\r\n\t .,:;\"'?!".ToArray();
                int wordCount = txtRange.Text.Split(splitWordsBy, StringSplitOptions.RemoveEmptyEntries).Length;
                WordNum.Text = "Words: " + wordCount.ToString();
                
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

        private void FontFamilyCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontFamilyCmbx.SelectedItem != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, FontFamilyCmbx.SelectedItem);
            }

        }

        private void FontSizeCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontSizeCmbx.SelectedItem != null)
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, FontSizeCmbx.SelectedItem.ToString());
        }
        private void ColorCmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ColorCmbx.SelectedItem != null)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.ForegroundProperty, (SolidColorBrush)new BrushConverter().ConvertFromString(ColorCmbx.SelectedValue.ToString()));
            }
        }


        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object tempBold = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            BoldBtn.IsChecked = (tempBold != DependencyProperty.UnsetValue) && (tempBold.Equals(FontWeights.Bold));

            object tempFont = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            FontFamilyCmbx.SelectedItem = tempFont;

            object tempSize = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            FontSizeCmbx.Text = tempSize.ToString();


            object tempItalic = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            ItalicBtn.IsChecked = (tempItalic != DependencyProperty.UnsetValue) && (tempItalic.Equals(FontStyles.Italic));

            object tempUnder = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            UnderlineBtn.IsChecked = (tempUnder != DependencyProperty.UnsetValue) && (tempUnder.Equals(TextDecorations.Underline));

            object tempColor = rtbEditor.Selection.GetPropertyValue(Inline.ForegroundProperty);

        }


        private void RtbEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);

            char[] splitWordsBy = "\r\r\n\t .,:;\"'?!".ToArray();
            int wordCount = textRange.Text.Split(splitWordsBy, StringSplitOptions.RemoveEmptyEntries).Length;
            WordNum.Text = "Words: " + wordCount.ToString();

        }

        private void SlikaBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Dodavanje slike|*.jpg;*.jpeg;*.png";
            string path;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialog.FileName;
                FilmImg.Source = new BitmapImage(new Uri(path));
                ImageBrd.BorderBrush = Brushes.Beige;
            }
        }

        private bool Validacija()
        {
            bool validno = true;

            if (NazivTxb.Text.Trim().Equals(string.Empty)) 
            {
                validno = false;
                NazivLbl.Content = "Unesite naziv filma";
                NazivLbl.Foreground = Brushes.Red;
                NazivTxb.BorderBrush = Brushes.Red;

            }
            else
            {
                NazivTxb.BorderBrush = Brushes.PaleTurquoise; 
            }
            if (ProdKucaTxb.Text.Trim().Equals(string.Empty))
            {
                validno = false;
                ProdKucaLbl.Content = "Unesite produkcijsku kucu";
                ProdKucaLbl.Foreground = Brushes.Red;
                ProdKucaTxb.BorderBrush = Brushes.Red; 
            }
            else
            {
                ProdKucaTxb.BorderBrush = Brushes.PaleTurquoise;
            }


            if (TrajanjeTxb.Text.Trim().Equals(string.Empty)) 
            {
                validno = false;
                TrajanjeLbl.Content = "Unesite trajanje u min";
                TrajanjeLbl.Foreground = Brushes.Red;
                TrajanjeTxb.BorderBrush = Brushes.Red;
            }
            else 
            {
                
                if (uint.TryParse(TrajanjeTxb.Text, out uint result))
                {
                    
                    TrajanjeLbl.Content = ""; 
                    TrajanjeTxb.BorderBrush = Brushes.PaleTurquoise;
                }
                else if (double.TryParse(TrajanjeTxb.Text, out double res))
                {
                    validno = false;
                    TrajanjeLbl.Content = "Unesite celi broj za min";
                    TrajanjeLbl.Foreground = Brushes.Red;
                    TrajanjeTxb.BorderBrush = Brushes.Red;
                    TrajanjeTxb.Text = "";
                }
                else 
                {
                    validno = false;
                    TrajanjeLbl.Content = "Dozvoljen samo brojevni unos";
                    TrajanjeLbl.Foreground = Brushes.Red;
                    TrajanjeTxb.BorderBrush = Brushes.Red;
                    TrajanjeTxb.Text = "";
                }


            }

            
            if (DatePicker.SelectedDate == null)
            {
                validno = false;
                DatumOpis.Content = "Datum mora biti odabran";
                DatumOpis.Foreground = Brushes.Red; 
            }
            else
            {
                if (DatePicker.SelectedDate > DateTime.Now)
                {
                    validno = false;
                    DatumOpis.Content = "Odabran datum nije validan";
                    DatumOpis.Foreground = Brushes.Red;
                }
                else 
                {
                    DatumOpis.Content = "Datum premijere:"; 
                    DatumOpis.Foreground = Brushes.Beige; 
                }


            }


            return validno;
        }

        private void SacuvajBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                var format = string.Format(@"{0}.rtf", Guid.NewGuid()); 

                FileStream fileStream = new FileStream(format, FileMode.Create);
                TextRange textRange = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                textRange.Save(fileStream, System.Windows.DataFormats.Rtf);

                Komedija komedija = new Komedija(NazivTxb.Text, ProdKucaTxb.Text, Int32.Parse(TrajanjeTxb.Text), DatePicker.SelectedDate.Value, format, FilmImg.Source.ToString());
                MainWindow.BindingKomedija[Index] = komedija;

                fileStream.Close();
                fileStream.Dispose();
                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Podaci nisu dobro popunjeni.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void NazivTxb_GotFocus(object sender, RoutedEventArgs e)
        {
            NazivLbl.Content = "";
        }

        private void NazivTxb_LostFocus(object sender, RoutedEventArgs e)
        {

            if (NazivTxb.Text.Trim().Equals(string.Empty))
            {
                NazivLbl.Content = "Unesite naziv filma"; 
            }
        }

        private void ProdKucaTxb_GotFocus(object sender, RoutedEventArgs e)
        {
            ProdKucaLbl.Content = "";
        }

        private void ProdKucaTxb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ProdKucaTxb.Text.Trim().Equals(string.Empty))
            {
                ProdKucaLbl.Content = "Unesite produkcijsku kucu";
            }
        }

        private void TrajanjeTxb_GotFocus(object sender, RoutedEventArgs e)
        {
            TrajanjeLbl.Content = "";
        }

        private void TrajanjeTxb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TrajanjeTxb.Text.Trim().Equals(string.Empty))
            {
                TrajanjeLbl.Content = "Unesite trajanje u min";
            }
        }
    }
}
