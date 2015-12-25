using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using MusicPhone.Domain;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MusicPhone.Control
{
    public sealed partial class ListFeeds : UserControl
    {
        List<Feed> novidades;
        Feed novi;
        News news;
        public ListFeeds()
        {
            InitializeComponent();
        }

        private void ContentPanel_KeyDown(object sender, KeyRoutedEventArgs e)
        {

        }
    }
}
