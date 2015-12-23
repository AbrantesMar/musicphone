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
    public partial class Artista : PhoneApplicationPage
    {
        Artist artista;
        public Artista()
        {
            InitializeComponent();
            artista = new Artist();
            artista.BuscaCompleted += new EventHandler<Artist.BuscaEventArgs>(artista_BuscaCompleted);
            artista.BuscaArtiscaAsync(App.nomeArtista.ToLower());
        }

        void artista_BuscaCompleted(object sender, Artist.BuscaEventArgs e)
        {
            try
            {
                artista = e.artista;
                this.txblNomeArtista.Text = artista.artist.desc;
                BitmapImage img = new BitmapImage(new Uri(artista.url + artista.artist.pic_medium, UriKind.RelativeOrAbsolute));
                this.imgArtista.Source = img;
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
                this.txblGenero.Text = gen;
                foreach (var a in artista.artist.toplyrics.item)
                {
                    this.lstMusicas.Items.Add(a.desc);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Artista desconhecido.");
            }
        }

    }
}