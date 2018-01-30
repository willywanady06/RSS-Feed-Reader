using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS_Feed_Reader
{
    class Feed
    {
        public string Title { set; get; }
        public string Link { set; get; }
        public string PubDate { set; get; }
        public string Desc { set; get; }

        public Feed (String title, String link, String publishedDate, String desc)
        {
            Title = title;
            Link = link;
            PubDate = publishedDate;
            Desc = desc;
          
        }
    }
}
