using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using MusicPhone.App_Code;
using System.Windows.Media.Imaging;

namespace MusicPhone
{

    public partial class Detalhes : PhoneApplicationPage
    {
        public string url = "http://www.vagalume.com.br/";
        Artist artista;
        public Artist artist;
        Mu music;

        public Detalhes()
        {
            InitializeComponent();
            this.ChamarArtista(App.nomeArtista.ToLower()); 
        }

        void artista_BuscaCompleted(object sender, Artist.BuscaEventArgs e)
        {
            try
            {
                artista = e.artista;
                this.tltNomeArtista.Text = artista.artist.desc;
                var img = new BitmapImage(new Uri(artista.url + artista.artist.pic_medium, UriKind.RelativeOrAbsolute));
                this.imgTitle.Source = img;
                string gen = "";
                int v = artista.artist.genre.Count - 1;
                int cont = 0;
                foreach (var a in artista.artist.genre)
                {
                
                    if (cont < v)
                        gen += a.name + ",";
                    else
                        gen += a.name;
                                        
                    cont++;
                }
                //this.txblGenero.Text = gen;
                this.txblCategorias.Text = gen;
                this.lstMusic.ItemsSource = artista.artist.toplyrics.item;
                if(artista.artist.albums != null){
                    if (artista.artist.albums.item.Count() != 0)
                    {
                        this.pnIDiscografia.Visibility = Visibility.Visible;
                        this.lstAlbuns.ItemsSource = artista.artist.albums.item;
                    }
                }
                else this.pnIDiscografia.Visibility = Visibility.Collapsed;
                this.lstAtistRelated.ItemsSource = artista.artist.related;
                this.prmDetalhes.DefaultItem = -1;
                
            }
            catch (Exception)
            {
                MessageBox.Show("Artista não encontrado.");
            }
            this.prbArtista.Visibility = Visibility.Collapsed;
        }

        private void lstAtistRelated_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox artistaRelated =  (ListBox)sender;
            if (lstAtistRelated.SelectedItem != null)
            {
                //string nome;
                Related artist = (Related)artistaRelated.SelectedItem;
                lstAtistRelated.SelectedItem = -1;
                //nome = artist.name;
                
                this.ChamarArtista(artist.url);
            }

        } 

        private void ChamarArtista(string nome)
        {
            string nomeS;
            artista = new Artist();
            if (nome.ToLower().Contains(" & "))
                nomeS = nome.ToLower().Replace(" & ", "-");
            else if (nome.ToLower().Contains(" "))
                nomeS = nome.ToLower().Replace(" ", "-");
            else if (nome.ToLower().Contains("/"))
                nomeS = nome.ToLower().Replace("/", "");
            else nomeS = nome.ToLower();
            artista.BuscaCompleted += new EventHandler<Artist.BuscaEventArgs>(artista_BuscaCompleted);
            artista.BuscaArtiscaAsync(nomeS.ToLower()); 
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            this.SalvarArtistaFavorits();
        }

        private void SalvarArtistaFavorits()
        {
            //IsolatedStorege n = new IsolatedStorege();
        }

        private void lstMusic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var musica = (ListBox)sender;
            var item = (Item)musica.SelectedItem;
            var music = new MusicSelect(item);
            App.musicStatic = music;
            BuscarMusica(music.id);
            this.NavigationService.Navigate(new Uri("/Musicas.xaml", UriKind.RelativeOrAbsolute));
            //var videoYoutube = new WebBrowserTask();
            //videoYoutube.Uri = new Uri("http://www.vagalume.com" + music.url, UriKind.RelativeOrAbsolute);
            //videoYoutube.Show();
        }
        public void BuscarMusica(string id)
        {
            music = new Mu();
            music.BuscaCompleted += new EventHandler<Mu.BuscaEventArgs>(music_BuscarMusicaYou);
            music.BuscaMusicAsync(id);
        }

        private void music_BuscarMusicaYou(object sender, Mu.BuscaEventArgs e)
        {
            music = e.music;

            //TODO: tem que implementar este launcher.
            //MediaPlayerLauncher objMediaPlayerLauncher = new MediaPlayerLauncher();
            //objMediaPlayerLauncher.Media = new Uri(music.music.UrlYoutube, UriKind.RelativeOrAbsolute);
            //objMediaPlayerLauncher.Location = MediaLocationType.None;
            //objMediaPlayerLauncher.Controls = MediaPlaybackControls.Pause | MediaPlaybackControls.Stop | MediaPlaybackControls.All;
            //objMediaPlayerLauncher.Orientation = MediaPlayerOrientation.Landscape;
            //objMediaPlayerLauncher.Show();

            //TODO: Temporario.
            //var videoYoutube = new WebBrowserTask();
            //videoYoutube.Uri = new Uri(music.music.UrlYoutube, UriKind.RelativeOrAbsolute);
            //videoYoutube.Show();
        }

    }
}