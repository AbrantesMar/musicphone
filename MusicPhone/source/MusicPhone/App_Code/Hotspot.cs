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
using System.Collections.Generic;

namespace MusicPhone.App_Code
{
    public class HotspotC
    {
        public class Hotspot
        {
            public string title { get; set; }
            public string date { get; set; }
            public string date_fmt { get; set; }
            public string link { get; set; }
            public string descr { get; set; }
            public string pic_src { get; set; }
            public string pic_width { get; set; }
            public string pic_height { get; set; }
        }

        public class RootObject
        {
            public List<Hotspot> hotspots { get; set; }
        }
    }
}
