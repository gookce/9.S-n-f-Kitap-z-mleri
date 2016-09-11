using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
  
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.Loaded += MainPage_Loaded;
            this.InitializeComponent();
        }
        public static string DersDosyasi;
        string[] Edebiyat1= {"80","20","100","106","113","12","121","132","134","23","29","32","38","41","46","51","58","60","63","65","67","70","72","76","80","90","94"};
        string[] Edebiyat2= {"89","22","105","112","120","19","131","133","137","28","31","37","0","45","50","57","59","62","64","66","69","71","75","79","89","93","99"};
        string[] DilAnlatım1= {"1","10","110","112","116","118","121","125","127","18","28","3","35","38","43","49","5","52","59","69","7","72","77","84","92","95"};
        string[] DilAnlatım2= {"2","17","111","115","117","120","124","126","130","27","34","4","36","42","48","51","6","58","68","70","9","76","83","91","94","109"};
        string[] Matematik = {"17","104","105","106","107","109","110","111","123","124","133","134","14","142","143","152","166","22","23","39","38","44","52","62","63","73","74","84","85","95","96","103","108","167"};
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DersSayfasi.DersAdi = "Edebiyat";
            DersDosyasi = DosyaDondur(txtNumaraArama.Text, "edb", Edebiyat1, Edebiyat2);
            Frame.Navigate(typeof(DersSayfasi));
        }
        public string DosyaDondur(string SayfaSayisi,string Prefix,string[] Dizim1,string[] Dizim2)
        {
            string dondurulecek = null;
            if (txtNumaraArama.Text.Length == 0)
            {
                SayfaSayisi = "99999"; 
            }
           for (int i = 0; i < 26; i++) 
            {
                if (Convert.ToInt32(SayfaSayisi) >= Convert.ToInt32(Dizim1[i]) && Convert.ToInt32(SayfaSayisi) <= Convert.ToInt32(Dizim2[i]))
                {
                    dondurulecek = Prefix + " " + Dizim1[i] + "-" + Dizim2[i] + ".txt";
                    break; 
                }
               else
                {
                    dondurulecek =  "bos.txt";
                }
            }
            return dondurulecek;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DersSayfasi.DersAdi = "Dil ve Anlatım";
            DersDosyasi = DosyaDondur(txtNumaraArama.Text, "dil", DilAnlatım1, DilAnlatım2);
            Frame.Navigate(typeof(DersSayfasi));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DersSayfasi.DersAdi = "Matematik";
            DersDosyasi = DosyaSec(txtNumaraArama.Text,"mat",Matematik);
            Frame.Navigate(typeof(DersSayfasi));
           
        }
        public string DosyaSec(string SayfaSayisi, string mat, string[] Dizim1)
        {
            string dondurulecek2 = null;
            if (txtNumaraArama.Text.Length == 0)
            {
                SayfaSayisi = "99999";
            }
            for (int i = 0; i < 33; i++)
            {
                if (Int32.Parse(SayfaSayisi)==Int32.Parse(Dizim1[i]))
                {
                    dondurulecek2 = "mat"+ " " + Dizim1[i] + ".jpg";
                    break;
                }
                else
                {
                    dondurulecek2 = "bos.txt";
                }
            }
            return dondurulecek2;

           
            
        }
    }
}
