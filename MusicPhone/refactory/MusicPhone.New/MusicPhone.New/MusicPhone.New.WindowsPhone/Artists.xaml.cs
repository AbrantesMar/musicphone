using MusicPhone.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MusicPhone.New
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Artists : Page
    {
        private ObservableCollection<Item3> AlbumList = new ObservableCollection<Item3>();
        private ObservableCollection<Item> MusicList = new ObservableCollection<Item>();
        private ObservableCollection<Related> ArtistsList = new ObservableCollection<Related>();


        public Artists()
        {
            this.InitializeComponent();
            this.listMusicas.DataContext = MusicList;
            this.listRelacionados.DataContext = ArtistsList;
            this.listAlbums.DataContext = AlbumList;

        }

        private async void ListArtist(string name)
        {
            var artist = new Artist();
            Artist.RootObject a = await artist.GetArtist(name);
            if (a == null)
                return;

            this.imgArtist.DataContext = a.artist.pic_small;
            for (int i = 0, count = a.artist.genre.Count; i < count; i++)
            {
                var c = i + 1;
                if(c == count)
                    this.txtCategorias.Text = a.artist.genre[i].name;
                else
                    this.txtCategorias.Text = a.artist.genre[i].name + ", ";
            }

            foreach (var item in a.artist.toplyrics.item)
            {
                this.MusicList.Add(item);
            }
            foreach (var item in a.artist.albums.item)
            {
                this.AlbumList.Add(item);
            }
            foreach (var item in a.artist.related)
            {
                this.ArtistsList.Add(item);
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string text = e.Parameter as string;
            if (text != null)
            {
                this.txtName.Text = text;
                ListArtist(text);
                //Do your stuff
            }
        }

        private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            Frame.GoBack();
            e.Handled = true;
        }

        private void btnFavoritar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void listAlbum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listRelacionados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListArtist(((sender as ListBox).SelectedItem as Related).name);
        }

        private void listMusicas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] parameter = new string[2];
            parameter[0] = ((sender as ListBox).SelectedItem as Item).desc;
            parameter[1] = this.txtName.Text;
            this.Frame.Navigate(typeof(Musics), parameter);
        }

        private void btnAdicionarBar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
 