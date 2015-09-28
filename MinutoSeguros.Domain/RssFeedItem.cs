using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;

namespace MinutoSeguros.Domain
{
    public class RssFeedItem
    {
        public string Titulo { get; set; }
        public string Url { get; set; }
        public string Descricao { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataPublicacao { get; set; }




        public List<RssFeedItem> ConverterListaFeed(SyndicationFeed feed)
        {
            List<RssFeedItem> listaFeedItem = new List<RssFeedItem>();

            foreach (var item in feed.Items)
            {
                var feedItem = new RssFeedItem();

                feedItem.Titulo = item.Title.Text;
                feedItem.Url = item.Links.FirstOrDefault().Uri.ToString();
                feedItem.Descricao = item.Summary.Text;
                feedItem.DataPublicacao = item.PublishDate.DateTime;                
                feedItem.Conteudo = item.ElementExtensions.ReadElementExtensions<string>("encoded", "http://purl.org/rss/1.0/modules/content/").FirstOrDefault();
                listaFeedItem.Add(feedItem);

            }
            return listaFeedItem;

        }
        


    }
}
