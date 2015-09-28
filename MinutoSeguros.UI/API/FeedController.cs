using MinutoSeguros.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace MinutoSeguros.UI.API
{
    public class FeedController : ApiController
    {

        public string BasePath
        {
            get { return System.Web.HttpContext.Current.Server.MapPath("~/"); }
        }

        [HttpGet]
        public JsonResult<FeedInfo> AvaliarFeed()
        {
            var avaliacao = new AvaliaFeed();
            var feed = new Feed();
            var noticias = new List<RssFeedItem>();
            try
            {
                noticias = feed.Obter(BasePath + Parametro.UrlFeedLocal);                
            }
            catch (Exception)
            {
                noticias = feed.Obter(Parametro.UrlFeed);
            }
            

            var info = avaliacao.Avaliar(noticias);

            return Json(info);
        }
    }
}