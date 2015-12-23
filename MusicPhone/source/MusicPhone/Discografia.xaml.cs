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

namespace MusicPhone
{
    public partial class Discografia : PhoneApplicationPage
    {
        List<Discography> lDiscografia;
        Discography discografia;
        public Discografia()
        {
            InitializeComponent();
            discografia = new Discography();
            discografia.BuscaCompleted += new EventHandler<Discography.BuscaEventArgs>(discografia_BuscaCompleted);
        }

        void discografia_BuscaCompleted(object sender, Discography.BuscaEventArgs e)
        {

            discografia = e.discografia;
            this.txblNomeArtista.Text = discografia.artist.desc;
            this.lDiscografia = new List<Discography>();
            this.lDiscografia.Add(discografia.discografia);
            lstAlbuns.DataContext = lDiscografia;
            //BitmapImage img = new BitmapImage(new Uri(discografia.,));
        }
    }
}