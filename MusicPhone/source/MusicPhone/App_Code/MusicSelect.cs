using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MusicPhone.App_Code
{
    public class MusicSelect
    {
        public string id { get; set; }
        public string desc { get; set; }
        public string url { get; set; }

        public MusicSelect(Item item)
        {
            id = item.id;
            desc = item.desc;
            url = item.url;
        }
    }
}
