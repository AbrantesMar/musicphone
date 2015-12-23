using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using System.Net.NetworkInformation;
using MusicPhone.App_Code;
using System.Windows.Media.Imaging;


namespace MusicPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        List<Novidades> novidades;
        Novidades novi;
        News news;

        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Load;
        }

        private void MainPage_Load(object sender, RoutedEventArgs e)
        {
            this.CarregarInformacoes();
        }

        private void CarregarInformacoes()
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    this.grdAvaliacaoNet.Visibility = Visibility.Collapsed;
                    this.ContentPanel.Visibility = Visibility.Visible;

                    news = new News();
                    news.BuscaCompleted += new EventHandler<News.BuscaEventArgs>(music_BuscaCompleta);//+= new EventHandler<News.BuscaEventArgs>(music_BuscaCompleta);
                    news.BuscaNewscaAsync();
                }
                else
                {
                    this.ContentPanel.Visibility = Visibility.Collapsed;
                    this.grdAvaliacaoNet.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao carregar Informações");
            }
        }
        

        public void music_BuscaCompleta(object sender, News.BuscaEventArgs e)
        {
            try
            {
                //double left = 6, top = 0, right = 300, bottom = 320;
                news.news = e.news;
                novidades = new List<Novidades>();
                int j = 0;
                int k = 0;
                for (int i = 0; i < 9; i++)
                {
                    BitmapImage btn = new BitmapImage(new Uri(news.news[i].pic_src, UriKind.RelativeOrAbsolute));
                    this.novi = new Novidades();
                    this.novi.imgFundo.Source = btn;
                    this.novi.txblTexto.Text = news.news[i].headline;
                    novidades.Add(novi);
                    if (j > 2)
                    {
                        j = 0; k = k + 1;
                    }

                    novidades[i].SetValue(Grid.RowProperty, k);
                    novidades[i].SetValue(Grid.ColumnProperty, j++);
                    this.ContentPanel.Children.Add(novidades[i]);
                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro na aplicação.");
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                if (!String.IsNullOrEmpty(this.txblNomeMusic.Text))
                {
                    App.nomeArtista = this.txblNomeMusic.Text;
                    if (App.nomeArtista.Contains(" & "))
                        App.nomeArtista = App.nomeArtista.Replace(" & ", "-");
                    else if (App.nomeArtista.Contains(" "))
                        App.nomeArtista = App.nomeArtista.Replace(" ", "-");
                    this.NavigationService.Navigate(new Uri("/Detalhes.xaml", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    MessageBox.Show("Digite o nome do artista");
                }
            }
            else
            {
                MessageBox.Show("Conecte à internet");
            }
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/About.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ContentPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            //Novidades entNovidades = new Novidades();
            //Grid n = (Grid)sender;
            
            //var nome = n.Parent;
            //var n1 = n.RowDefinitions;
            //var n3 = n.GetValue(Grid.RowProperty);

            //NewsPage.newPage = news;
            NewsPage.newPage = this.news;
            this.NavigationService.Navigate(new Uri("/NewsPage.xaml",UriKind.RelativeOrAbsolute));
        }

        void testando_LostMouse(object sender, MouseEventHandler e)
        {
            var novo = e;
            var novato = sender;
        }


    }
}