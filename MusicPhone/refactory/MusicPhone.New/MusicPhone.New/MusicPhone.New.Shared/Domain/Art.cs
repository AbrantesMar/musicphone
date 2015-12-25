using MusicPhone.New.Rests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicPhone.Domain
{
    public class Period
    {
        public string year { get; set; }
        public string week { get; set; }
    }

    public class All
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string pic_small { get; set; }
        public string pic_medium { get; set; }
        public string uniques { get; set; }
        public string views { get; set; }
    }

    public class Week
    {
        public Period period { get; set; }
        public List<All> all { get; set; }
    }

    public class Art
    {
        public Week week { get; set; }

    }

    public class RootObject
    {
        public Art art { get; set; }
    }

}
