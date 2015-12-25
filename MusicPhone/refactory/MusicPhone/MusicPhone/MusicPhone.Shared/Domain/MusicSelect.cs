namespace MusicPhone.Domain
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
