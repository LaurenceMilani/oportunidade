using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
//using System.ServicemODEL

//using System.Threading.Tasks;


namespace MinutoSeguros.Infrastructure
{
    public class RssFeedReader
    {

        public SyndicationFeed ListarFeed(string url)
        {
            var feeds = ReadSyndicationFeed(url);


            return feeds;
        }



        private SyndicationFeed ReadSyndicationFeed(string url)
        {
            
            Uri uri = new Uri(url);
            
            SyndicationFeed feed;
            using (var reader = XmlReader.Create(url))
            {
                feed = SyndicationFeed.Load(reader);                
            }

            return feed;
        }

       


    }

}
