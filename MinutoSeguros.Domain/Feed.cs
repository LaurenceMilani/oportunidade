using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinutoSeguros.Infrastructure;

namespace MinutoSeguros.Domain
{
    
    public class Feed
    {        

        public List<RssFeedItem> Obter(string url)
        {
            var feed = new RssFeedReader().ListarFeed(url);

            //Separei para manter o conceito de Single Responsability
            var listaFeedItem = new RssFeedItem().ConverterListaFeed(feed);

            return listaFeedItem;
        }




    }



}
