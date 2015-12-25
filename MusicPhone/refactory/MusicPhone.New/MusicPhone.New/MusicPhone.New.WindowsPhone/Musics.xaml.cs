using MusicPhone.Domain;
using System;
using System.Collections.Generic;
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
    public sealed partial class Musics : Page
    {
        public Musics()
        {
            this.InitializeComponent();
        }

        private async void BuscarMusica(string artis, string name)
        {
            var artist = new Music();
            Music.RootObject a = await artist.GetMusic(artis, name);
            if (a == null)
                return;
            this.txtMusicLetra.Text = a.mus.FirstOrDefault().text;
            this.txtMusicLTraducao.Text = a.mus.FirstOrDefault().translate.FirstOrDefault(t => t.lang.Equals(1)).text;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string[] text = e.Parameter as string[];
            if (text != null)
            {
                BuscarMusica(text[1], text[0]);
            }
        }
    }
}
