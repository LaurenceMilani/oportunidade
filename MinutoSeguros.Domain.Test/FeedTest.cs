using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace MinutoSeguros.Domain.Test
{
    [TestClass]
    public class FeedTest
    {
        [TestMethod]
        [TestCategory("Excecao")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Obter_Quando_UrlNula_Deve_ArgumentNullException()
        {
            var feeds = new Feed();
            List<RssFeedItem> ret = feeds.Obter(null);
        }
                

        [TestMethod]
        [TestCategory("Integracao")]        
        public void Obter_Quando_UrlValidaExterna_Deve_RetornarFeed()
        {
            var feed = new Feed();
                        
            var result = feed.Obter(Parametro.UrlFeed);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        [TestCategory("Integracao")]
        public void Obter_Quando_UrlValidaLocal_Deve_RetornarFeed()
        {
            var feed = new Feed();            

            var result = feed.Obter(@"C:\Users\LaurenceM\Trabalho\teste\MinutoSeguros\MinutoSeguros.UI\" + Parametro.UrlFeedLocal);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("Integracao")]        
        public void Avaliar_Quando_FeedValido_Deve_RetornarAnalise()
        {
            var feed = new Feed();            
            var rss = feed.Obter(Parametro.UrlFeed);
            Assert.IsNotNull(rss);
            var result = new AvaliaFeed().Avaliar(rss);
            Assert.IsNotNull(result);



        }

    }
}
