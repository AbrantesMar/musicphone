using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using MusicPhone.App_Code;
using System.Windows.Media.Imaging;

namespace MusicPhone
{
    public partial class NewsPage : PhoneApplicationPage
    {

        public static List<Novidades> lNovi { get; set; }        
        public static Novidades novi { get; set; }
        public static News newPage { get; set; }
        public static NewsPage n { get; set; }
        public string uri;

        public NewsPage()
        {
            InitializeComponent();
            if (NewsPage.n != null)
            {
                this.txblLetraMusica.Text = NewsPage.n.txblLetraMusica.Text;
                this.imgNewsPrincipal.Source = new BitmapImage(new Uri(newPage.news.FirstOrDefault(no => no.headline == NewsPage.n.txblLetraMusica.Text).pic_src, UriKind.RelativeOrAbsolute));
                this.lstImagenNews.ItemsSource = newPage.news;
                n = null;
            }
        }

        private void lstImagenNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItemVar = (sender as ListBox);
            if (selectedItemVar.SelectedItem != null)
            {
                var sele = selectedItemVar.SelectedItem;
                this.txblLetraMusica.Text = (sele as News).headline;
                this.imgNewsPrincipal.Source = new BitmapImage(new Uri((sele as News).pic_src, UriKind.RelativeOrAbsolute));
            }

        }
    }
}