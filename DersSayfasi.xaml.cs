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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;



namespace App2
{   
    public sealed partial class DersSayfasi : Page
    {
        public static string DersAdi;
        public DersSayfasi()
        {
            this.Loaded += DersSayfasi_Loaded;
            this.InitializeComponent();
        }

        async void DersSayfasi_Loaded(object sender, RoutedEventArgs e)
        {
            txtDersAdi.Text = DersAdi;
            var _Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            _Folder = await _Folder.GetFolderAsync("Assets");
            var _File = await _Folder.GetFileAsync(MainPage.DersDosyasi);
            if (!MainPage.DersDosyasi.Contains(".jpg"))
            {
                txtDersIcerik.Text = await Windows.Storage.FileIO.ReadTextAsync(_File, Windows.Storage.Streams.UnicodeEncoding.Utf8);
            }
            else
            {
                BitmapImage yeniresim = new BitmapImage(new Uri(_File.Path));
                OrtaImage.Source = yeniresim;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        
    }
}
