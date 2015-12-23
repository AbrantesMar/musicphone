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
using Microsoft.Phone.Tasks;

namespace MusicPhone
{
    public partial class About : PhoneApplicationPage
    {
        public About()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception)
            {
                MessageBox.Show("Márcio Abrantes");
            }
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.ChamaBrowser("http://www.facebook.com/mabrantes10");
        }

        private void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.ChamaBrowser("https://www.facebook.com/micetepam");
        }

        void ChamaBrowser(string url)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.Uri = new Uri(url, UriKind.RelativeOrAbsolute);
            browser.Show();
        }
    }
}