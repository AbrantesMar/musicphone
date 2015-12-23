using System;
using Microsoft.Phone.Controls;
using MusicPhone.App_Code;
using Microsoft.Phone.Tasks;
//using PhoneClassLibraryYouTube;

namespace MusicPhone
{
    public partial class Musicas : PhoneApplicationPage
    {
        Mu music;
        public static MusicSelect musicSelect;
        public static Artist artistaSelected;
        public Musicas()
        {
            InitializeComponent();
            string m;
            Mu mu = new Mu();
            mu.BuscaCompleted += new EventHandler<Mu.BuscaEventArgs>(music_BuscaCompleted);
            mu.BuscaMusicAsync(App.musicStatic.id); 
            ////mleVideo.Source();
            //this.ChamarVideo();

            //music = new Music();
            //music.BuscaCompleted += new EventHandler<Artist.BuscaEventArgs>(music_BuscaCompleted);
            //music.BuscaArtiscaAsync(App.nomeArtista);
        }

        void ChamarVideo(string url, bool tipo)
        {
            if (tipo)
            {

                //Api Youtube
                //IVideoUrl yVideo = new VideoUrl();
                //yVideo.OnVideoUrlLoaded += new VideoUrlLoaded(yVideo_OnVideoUrlLoaded);
                //yVideo.GetVideoUrl(url);



                //MediaPlayerLauncher objMediaPlayerLauncher = new MediaPlayerLauncher();
                //objMediaPlayerLauncher.Media = new Uri(@url, UriKind.RelativeOrAbsolute);
                //    //new Uri(@"http://www.youtube.com/v/u1zgFlCw8Aw?rel=1&color1=0x2b405b&color2=0x6b8ab6&border=1&fs=1", UriKind.RelativeOrAbsolute);
                //objMediaPlayerLauncher.Location = MediaLocationType.None;
                //objMediaPlayerLauncher.Controls = MediaPlaybackControls.Pause | MediaPlaybackControls.Stop |
                //                                  MediaPlaybackControls.All;
                //objMediaPlayerLauncher.Orientation = MediaPlayerOrientation.Landscape;
                //objMediaPlayerLauncher.Show();
            }
            else
            {
                WebBrowserTask webBrowserTask = new WebBrowserTask();
                webBrowserTask.Uri = new Uri(@"http://www.youtube.com/watch?v="+url+"&autoplay=1", UriKind.RelativeOrAbsolute);
                webBrowserTask.Show();
            }
        }
        //void yVideo_OnVideoUrlLoaded(object sender, VideoUrlArgs e)
        //{
        //    string str = e.StrVideoUrl;
        //    MediaPlayerLauncher objMediaPlayerLauncher = new MediaPlayerLauncher();
        //    objMediaPlayerLauncher.Media = new Uri(@str, UriKind.RelativeOrAbsolute);
        //    //new Uri(@"http://www.youtube.com/v/u1zgFlCw8Aw?rel=1&color1=0x2b405b&color2=0x6b8ab6&border=1&fs=1", UriKind.RelativeOrAbsolute);
        //    objMediaPlayerLauncher.Location = MediaLocationType.None;
        //    objMediaPlayerLauncher.Controls = MediaPlaybackControls.Pause | MediaPlaybackControls.Stop |
        //                                      MediaPlaybackControls.All;
        //    objMediaPlayerLauncher.Orientation = MediaPlayerOrientation.Landscape;
        //    objMediaPlayerLauncher.Show();
        //    //MediaPlayerLauncher media = new MediaPlayerLauncher();
        //    //media.Media = new Uri(str, UriKind.RelativeOrAbsolute);
        //    //media.Show();
        //}

        void music_BuscaCompleted(object sender, Mu.BuscaEventArgs e)
        {
            music = new Mu();
            music = e.music;
            this.txtLetra.DataContext = music;
        }

        private void GoMusic_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ChamarVideo(music.ytid, false);
        }

        private void btnCompartilhar_Click(object sender, EventArgs e)
        {
            ShareStatusTask share = new ShareStatusTask();
            share.Status = "\n Nome da Musica: " + music.name + "\n\n Autor:" + artistaSelected.desc + "\n\n" + this.txtLetra.Text; 
            share.Show();
        }

    }
}