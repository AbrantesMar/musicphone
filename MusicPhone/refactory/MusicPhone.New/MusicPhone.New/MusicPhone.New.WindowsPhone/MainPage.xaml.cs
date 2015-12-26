using MusicPhone.Domain;
using MusicPhone.New.Rests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MusicPhone.New
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<All> ArtistDestaque;

        public MainPage()
        {
            this.InitializeComponent();          
            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.ArtistDestaque = new ObservableCollection<All>();
            this.listArtist.DataContext = ArtistDestaque;
            ListArtist(20);
        }

        private async void ListArtist(int quantidade)
        {
            try
            {
                RootObject a = await GetArt(quantidade);
                if (a == null)
                    return;
                foreach (var item in a.art.week.all)
                {
                    this.ArtistDestaque.Add(item);
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        public async Task<RootObject> GetArt(int quantidade)
        {
            RootObject a = await BasicRequests<RootObject>.GetJson(null, null, Url(quantidade));
            return a;
        }

        public string Url(int quantidade)
        {

            DateTime dateinit = new DateTime(DateTime.Now.Year, 01, 01);
            DateTime dateend = DateTime.Now;
            string semana = totalSemanas(dateinit, dateend).ToString();
            return "http://api.vagalume.com.br/rank.php?type=art&period=week&periodVal=" + DateTime.Now.Year + semana + "&scope=all&limit=" + quantidade;
        }

        public int totalSemanas(DateTime dataInicial, DateTime dataFim)
        {
            return (int)Math.Ceiling(((dataFim - dataInicial).TotalDays + 1) / 7d);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        //private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        //{
        //    Frame.GoBack();
        //    e.Handled = true;
        //}

        private void listLoads_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listArtist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var artist = ((sender as ListBox).SelectedItem as All);
            
            this.Frame.Navigate(typeof(Artists), artist.name);

        }

        private void btnAdicionarBar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtName.Text)){
                string name = this.txtName.Text;
                if (name.Contains(" & "))
                    name = name.Replace(" & ", "-");
                else if (name.Contains(" "))
                    name = name.Replace(" ", "-");
                this.Frame.Navigate(typeof(Artists), name);
            }
                
            
        }
    }
}
