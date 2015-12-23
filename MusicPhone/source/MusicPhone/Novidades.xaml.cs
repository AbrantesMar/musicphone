using System.Windows.Controls;
using System.Windows.Input;
using MusicPhone.App_Code;

namespace MusicPhone
{
    public partial class Novidades : UserControl
    {
        public static News IdItem { get; set; }


        public Novidades()
        {
            InitializeComponent();
        }

        private void LayoutRoot_MouseEnter(object sender, MouseEventArgs e)
        {
            NewsPage.n = new NewsPage();
            NewsPage.n.txblLetraMusica.Text = this.txblTexto.Text;
        }
    }
}

